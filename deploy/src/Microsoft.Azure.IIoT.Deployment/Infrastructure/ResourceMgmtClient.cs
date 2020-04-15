﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Deployment.Infrastructure {

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using Newtonsoft.Json;
    using Serilog;

    class ResourceMgmtClient : IDisposable {

        public const string MICROSOFT_DEVICES = "Microsoft.devices";
        public const string MICROSOFT_DOCUMENT_DB = "Microsoft.documentdb";
        public const string MICROSOFT_SIGNALR_SERVICE = "Microsoft.signalrservice";
        public const string MICROSOFT_SERVICE_BUS = "Microsoft.servicebus";
        public const string MICROSOFT_EVENT_HUB = "Microsoft.eventhub";
        public const string MICROSOFT_STORAGE = "Microsoft.storage";
        public const string MICROSOFT_KEY_VAULT = "Microsoft.keyvault";
        public const string MICROSOFT_AUTHORIZATION = "Microsoft.authorization";
        public const string MICROSOFT_INSIGHTS = "Microsoft.insights";
        public const string MICROSOFT_CONTAINER_SERVICE = "Microsoft.ContainerService";
        public const string MICROSOFT_DOMAIN_REGISTRATION = "Microsoft.DomainRegistration";
        public const string MICROSOFT_OPERATIONS_MANAGEMENT = "Microsoft.OperationsManagement";
        public const string MICROSOFT_NETWORK = "Microsoft.Network";
        public const string MICROSOFT_OPERATIONAL_INSIGHTS = "Microsoft.OperationalInsights";
        public const string MICROSOFT_WEB = "Microsoft.Web";

        private const string STATE_NOT_REGISTERED = "notregistered";
        private const string STATE_REGISTERING = "registering";
        private const string STATE_REGISTERED = "registered";

        private readonly ResourceManagementClient _resourceManagementClient;

        public ResourceMgmtClient(
            string subscriptionId,
            RestClient restClient
        ) {
            _resourceManagementClient = new ResourceManagementClient(restClient) {
                SubscriptionId = subscriptionId
            };
        }

        public async Task<ProviderInner> RegisterResourceProviderAsync(
            string resourceProviderNamespace,
            CancellationToken cancellationToken = default
        ) {
            var provider = await _resourceManagementClient
                .Providers
                .RegisterAsync(
                    resourceProviderNamespace,
                    cancellationToken
                );

            while (provider.RegistrationState.ToLower().Equals(STATE_REGISTERING)) {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(5000, cancellationToken);

                provider = await _resourceManagementClient
                    .Providers
                    .GetAsync(
                        resourceProviderNamespace,
                        null,
                        cancellationToken
                    );
            }

            return provider;
        }

        public async Task RegisterRequiredResourceProvidersAsync(
            CancellationToken cancellationToken = default
        ) {
            try {
                Log.Information("Registering resource providers ...");

                var devicesCreationTask = RegisterResourceProviderAsync(MICROSOFT_DEVICES, cancellationToken);
                var documentDBCreationTask = RegisterResourceProviderAsync(MICROSOFT_DOCUMENT_DB, cancellationToken);
                var signalrServiceCreationTask = RegisterResourceProviderAsync(MICROSOFT_SIGNALR_SERVICE, cancellationToken);
                var serviceBusCreationTask = RegisterResourceProviderAsync(MICROSOFT_SERVICE_BUS, cancellationToken);
                var eventHubCreationTask = RegisterResourceProviderAsync(MICROSOFT_EVENT_HUB, cancellationToken);
                var storageCreationTask = RegisterResourceProviderAsync(MICROSOFT_STORAGE, cancellationToken);
                var keyVaultCreationTask = RegisterResourceProviderAsync(MICROSOFT_KEY_VAULT, cancellationToken);
                var authorizationCreationTask = RegisterResourceProviderAsync(MICROSOFT_AUTHORIZATION, cancellationToken);
                var insightsCreationTask = RegisterResourceProviderAsync(MICROSOFT_INSIGHTS, cancellationToken);
                var containerServiceCreationTask = RegisterResourceProviderAsync(MICROSOFT_CONTAINER_SERVICE, cancellationToken);
                var domainRegistrationCreationTask = RegisterResourceProviderAsync(MICROSOFT_DOMAIN_REGISTRATION, cancellationToken);
                var operationsManagementCreationTask = RegisterResourceProviderAsync(MICROSOFT_OPERATIONS_MANAGEMENT, cancellationToken);
                var networkCreationTask = RegisterResourceProviderAsync(MICROSOFT_NETWORK, cancellationToken);
                var operationalInsightsCreationTask = RegisterResourceProviderAsync(MICROSOFT_OPERATIONAL_INSIGHTS, cancellationToken);
                var webCreationTask = RegisterResourceProviderAsync(MICROSOFT_WEB, cancellationToken);

                await devicesCreationTask;
                await documentDBCreationTask;
                await signalrServiceCreationTask;
                await serviceBusCreationTask;
                await eventHubCreationTask;
                await storageCreationTask;
                await keyVaultCreationTask;
                await authorizationCreationTask;
                await insightsCreationTask;
                await containerServiceCreationTask;
                await domainRegistrationCreationTask;
                await operationsManagementCreationTask;
                await networkCreationTask;
                await operationalInsightsCreationTask;
                await webCreationTask;

                Log.Information("Registered resource providers");
            }
            catch (Exception) {
                Log.Error($"Failed to register resource providers");
                throw;
            }
        }

        /// <summary>
        /// Create a deployment.
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="deploymentName"></param>
        /// <param name="template"></param>
        /// <param name="parameters"></param>
        /// <param name="deploymentMode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentExtendedInner> CreateDeploymentAsync(
            IResourceGroup resourceGroup,
            string deploymentName,
            object template,
            object parameters,
            DeploymentMode deploymentMode,
            CancellationToken cancellationToken = default
        ) {
            if (resourceGroup is null) {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (string.IsNullOrWhiteSpace(deploymentName)) {
                throw new ArgumentNullException(nameof(deploymentName));
            }
            if (template is null) {
                throw new ArgumentNullException(nameof(template));
            }
            if (parameters is null) {
                throw new ArgumentNullException(nameof(parameters));
            }

            var deploymentDefinition = new DeploymentInner {
                Location = resourceGroup.RegionName,
                Properties = new DeploymentProperties {
                    Template = template,
                    Parameters = parameters,
                    Mode = deploymentMode,
                }
            };

            deploymentDefinition.Validate();

            var deployment = await _resourceManagementClient
                .Deployments
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    deploymentName,
                    deploymentDefinition,
                    cancellationToken
                );

            return deployment;
        }

        /// <summary>
        /// Create a deployment.
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="deploymentName"></param>
        /// <param name="templateJson"></param>
        /// <param name="parametersJson"></param>
        /// <param name="deploymentMode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentExtendedInner> CreateDeploymentAsync(
            IResourceGroup resourceGroup,
            string deploymentName,
            string templateJson,
            string parametersJson,
            DeploymentMode deploymentMode,
            CancellationToken cancellationToken = default
        ) {
            if (string.IsNullOrWhiteSpace(templateJson)) {
                throw new ArgumentNullException(nameof(templateJson));
            }
            if (string.IsNullOrWhiteSpace(parametersJson)) {
                throw new ArgumentNullException(nameof(parametersJson));
            }

            var template = JsonConvert.DeserializeObject(templateJson);
            var parameters = JsonConvert.DeserializeObject(parametersJson);

            var deployment = await CreateDeploymentAsync(
                resourceGroup,
                deploymentName,
                template,
                parameters,
                deploymentMode,
                cancellationToken
            );

            return deployment;
        }

        public void Dispose() {
            if (null != _resourceManagementClient) {
                _resourceManagementClient.Dispose();
            }
        }
    }
}
