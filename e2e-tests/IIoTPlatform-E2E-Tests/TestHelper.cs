﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace IIoTPlatform_E2E_Tests {
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TestModels;
    using Xunit;
    using System.IO;
    using Renci.SshNet;
    using TestExtensions;

    internal static class TestHelper {

        /// <summary>
        /// Request OAuth token using Http basic authentication from environment variables
        /// </summary>
        /// <returns>Return content of request token or empty string</returns>
        public static async Task<string> GetTokenAsync(IIoTPlatformTestContext context) {
            return await GetTokenAsync(
                context.IIoTPlatformConfigHubConfig.AuthTenant,
                context.IIoTPlatformConfigHubConfig.AuthClientId,
                context.IIoTPlatformConfigHubConfig.AuthClientSecret,
                context.IIoTPlatformConfigHubConfig.ApplicationName
            );
        }

        /// <summary>
        /// Request OAuth token using Http basic authentication
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="clientId">User name for HTTP basic authentication</param>
        /// <param name="clientSecret">Password for HTTP basic authentication</param>
        /// <param name="applicationName">Name of deployed Industrial IoT</param>
        /// <returns>Return content of request token or empty string</returns>
        public static async Task<string> GetTokenAsync(string tenantId, string clientId, string clientSecret, string applicationName) {

            Assert.True(!string.IsNullOrWhiteSpace(tenantId), "tenantId is null");
            Assert.True(!string.IsNullOrWhiteSpace(clientId), "clientId is null");
            Assert.True(!string.IsNullOrWhiteSpace(clientSecret), "clientSecret is null");
            Assert.True(!string.IsNullOrWhiteSpace(applicationName), "applicationName is null");

            var client = new RestClient($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token") {
                Timeout = 30000,
                Authenticator = new HttpBasicAuthenticator(clientId, clientSecret)
            };

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", $"https://{tenantId}/{applicationName}-service/.default");

            var response = await client.ExecuteAsync(request);
            Assert.True(response.IsSuccessful, $"Request OAuth2.0 failed, Status {response.StatusCode}, ErrorMessage: {response.ErrorMessage}");
            dynamic json = JsonConvert.DeserializeObject(response.Content);
            Assert.NotNull(json);
            Assert.NotEmpty(json);
            return $"{json.token_type} {json.access_token}";
        }

        /// <summary>
        /// Read PublishedNodes json from OPC-PLC and provide the data to the tests
        /// </summary>
        /// <param name="context">Shared Context for E2E testing Industrial IoT Platform</param>
        /// <returns>Dictionary with URL of PLC-PLC as key and Content of Published Nodes files as value</returns>
        public static async Task<IDictionary<string, PublishedNodesEntryModel>> GetSimulatedOpcUaNodesAsync(IIoTPlatformTestContext context) {
            var result = new Dictionary<string, PublishedNodesEntryModel>();

            var opcPlcUrls = context.OpcPlcConfig.Urls;
            context.OutputHelper?.WriteLine($"SimulatedOpcPlcUrls {opcPlcUrls}");
            var listOfUrls = opcPlcUrls.Split(TestConstants.SimulationUrlsSeparator);

            foreach (var url in listOfUrls.Where(s => !string.IsNullOrWhiteSpace(s))) {
                context.OutputHelper?.WriteLine($"Load pn.json from {url}");
                using (var client = new HttpClient()) {
                    var ub = new UriBuilder {Host = url};
                    var baseAddress = ub.Uri;

                    client.BaseAddress = baseAddress;

                    using (var response = await client.GetAsync(TestConstants.OpcSimulation.PublishedNodesFile)) {
                        Assert.NotNull(response);
                        Assert.True(response.IsSuccessStatusCode, $"http GET request to load pn.json failed, Status {response.StatusCode}");
                        var json = await response.Content.ReadAsStringAsync();
                        Assert.NotEmpty(json);
                        var entryModels = JsonConvert.DeserializeObject<PublishedNodesEntryModel[]>(json);

                        Assert.NotNull(entryModels);
                        Assert.NotEmpty(entryModels);
                        Assert.NotNull(entryModels[0].OpcNodes);
                        Assert.NotEmpty(entryModels[0].OpcNodes);

                        result.Add(url, entryModels[0]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Switch to publisher standalone mode
        /// </summary>
        public static void SwitchToStandaloneMode(IIoTPlatformTestContext context) {
            var patch =
                @"{
                    tags: {
                        unmanaged: null
                    }
                }";

            UpdateTagAsync(patch, context).Wait();
        }

        /// <summary>
        /// Switch to publisher orchestrated mode
        /// </summary>
        /// <param name="destinationFilePath">Path of the PublishedNodesFile.json file to be deleted</param>
        /// <param name="context">Shared Context for E2E testing Industrial IoT Platform</param>
        public static void SwitchToOrchestratedMode(string destinationFilePath, IIoTPlatformTestContext context) {
            var patch =
               @"{
                    tags: {
                        unmanaged: true
                    }
                }";

            DeletePublishedNodesFile(destinationFilePath, context);
            UpdateTagAsync(patch, context).Wait();
        }

        /// <summary>
        /// Switch to publisher orchestrated mode
        /// </summary>       
        /// <param name="patch">Name of deployed Industrial IoT</param>
        /// <param name="context">Shared Context for E2E testing Industrial IoT Platform</param>
        private static async Task UpdateTagAsync(string patch, IIoTPlatformTestContext context) {
            var registryManager = context.RegistryHelper.RegistryManager;
            var deviceId = Environment.GetEnvironmentVariable(TestConstants.EnvironmentVariablesNames.IOT_EDGE_DEVICE_ID);
            Assert.True(!string.IsNullOrWhiteSpace(deviceId), "deviceId string is null");

            var twin = await registryManager.GetTwinAsync(deviceId);
            await registryManager.UpdateTwinAsync(twin.DeviceId, patch, twin.ETag);
        }

        /// <summary>
        /// transfer the content of published_nodes.json file into the OPC Publisher edge module
        /// </summary>
        /// <param name="sourceFilePath">Source file path</param>
        /// <param name="destinationFilePath">Destination file path</param>
        /// <param name="context">Shared Context for E2E testing Industrial IoT Platform</param>
        public static void LoadPublishedNodesFile(string sourceFilePath, string destinationFilePath, IIoTPlatformTestContext context) {
            Assert.True(File.Exists(sourceFilePath), "source file does not exist");

            using (var client = new ScpClient(
                context.SshConfig.Host,
                context.SshConfig.Username,
                context.SshConfig.Password)) {
                client.Connect();

                if (string.IsNullOrEmpty(sourceFilePath)) {
                    DeletePublishedNodesFile(destinationFilePath, context);
                }
                using (Stream localFile = File.OpenRead(sourceFilePath)) {
                    client.Upload(localFile, destinationFilePath);
                }
                client.Disconnect();
            }
        }

        /// <summary>
        /// Delete published_nodes.json file into the OPC Publisher edge module
        /// </summary>
        /// <param name="destinationFilePath">Destination file path</param>
        /// <param name="context">Shared Context for E2E testing Industrial IoT Platform</param>
        public static void DeletePublishedNodesFile(string destinationFilePath, IIoTPlatformTestContext context) {
            
            Assert.True(File.Exists(destinationFilePath), "file does not exist");

            var isSuccessful = false;
            using (SshClient client = new SshClient(
                context.SshConfig.Host,
                context.SshConfig.Username,
                context.SshConfig.Password)) {
                client.Connect();

                var terminal = client.RunCommand("rm " + destinationFilePath);
                if (string.IsNullOrEmpty(terminal.Error)) {
                    isSuccessful = true;
                }
                client.Disconnect();
            }
            Assert.True(isSuccessful, "Delete file was not successfull");
        }
    }
}