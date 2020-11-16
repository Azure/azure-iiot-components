﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace IIoTPlatform_E2E_Tests.TestExtensions {
    using Microsoft.Azure.IIoT;
    using Microsoft.Azure.IIoT.Deploy;
    using Microsoft.Azure.IIoT.Hub;
    using Microsoft.Azure.IIoT.Hub.Models;
    using Microsoft.Azure.IIoT.Serializers;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IoTHubPublisherDeploymentTest : IHostProcess {

        public static readonly string TargetConditionStandalone =
            $"(tags.__type__ = '{IdentityType.Gateway}' AND tags.unmanage = 'true')";

        /// <summary>
        /// Create deployer
        /// </summary>
        /// <param name="service"></param>
        /// <param name="config"></param>
        /// <param name="serializer"></param>
        /// <param name="logger"></param>
        public IoTHubPublisherDeploymentTest(IIoTHubConfigurationServices service,
            IContainerRegistryConfig config, IJsonSerializer serializer, ILogger logger) {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _config = config ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task StartAsync() {
            await _service.CreateOrUpdateConfigurationAsync(new ConfigurationModel {
                Id = "__default-opcpublisher-standalone",
                Content = new ConfigurationContentModel {
                    ModulesContent = CreateLayeredDeployment(true, true)
                },
                SchemaVersion = kDefaultSchemaVersion,
                TargetCondition = TargetConditionStandalone +
                    " AND tags.os = 'Linux'",
                Priority = 1
            }, true);
        }

        /// <inheritdoc/>
        public Task StopAsync() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Get base edge configuration
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, IDictionary<string, object>> CreateLayeredDeployment(bool isLinux, bool isStandalone) {

            var registryCredentials = "";
            if (!string.IsNullOrEmpty(_config.DockerServer) &&
                _config.DockerServer != "mcr.microsoft.com") {
                var registryId = _config.DockerServer.Split('.')[0];
                registryCredentials = @"
                    ""properties.desired.runtime.settings.registryCredentials." + registryId + @""": {
                        ""address"": """ + _config.DockerServer + @""",
                        ""password"": """ + _config.DockerPassword + @""",
                        ""username"": """ + _config.DockerUser + @"""
                    },
                ";
            }

            // Configure create options per os specified
            string createOptions;
            if (isLinux) {
                if (isStandalone) {
                    createOptions = _serializer.SerializeToString(new {
                        Hostname = "publisher",
                        Cmd = new[] {
                        "PkiRootPath=/mount/pki",
                        "--aa",
                        "--pf=/mount/published_nodes.json"
                    },
                        HostConfig = new {
                            Binds = new[] {
                            "/mount:/mount"
                            }
                        }
                    }).Replace("\"", "\\\"");
                }
                else {
                    createOptions = _serializer.SerializeToString(new {
                        Hostname = "publisher",
                        Cmd = new[] {
                        "PkiRootPath=/mount/pki",
                        "--aa"
                    },
                        HostConfig = new {
                            Binds = new[] {
                            "/mount:/mount"
                            }
                        }
                    }).Replace("\"", "\\\"");
                }
            }
            else {
                if (isStandalone) {
                    createOptions = _serializer.SerializeToString(new {
                        User = "ContainerAdministrator",
                        Hostname = "publisher",
                        Cmd = new[] {
                        "PkiRootPath=/mount/pki",
                        "--aa",
                        "--pf=C:\\\\mount\\\\published_nodes.json"
                    },
                        HostConfig = new {
                            Mounts = new[] {
                            new {
                                Type = "bind",
                                Source = "C:\\\\ProgramData\\\\iotedge",
                                Target = "C:\\\\mount"
                                }
                            }
                        }
                    }).Replace("\"", "\\\"");
                }
                else {
                    createOptions = _serializer.SerializeToString(new {
                        User = "ContainerAdministrator",
                        Hostname = "publisher",
                        Cmd = new[] {
                        "PkiRootPath=/mount/pki",
                        "--aa"
                    },
                        HostConfig = new {
                            Mounts = new[] {
                            new {
                                Type = "bind",
                                Source = "C:\\\\ProgramData\\\\iotedge",
                                Target = "C:\\\\mount"
                                }
                            }
                        }
                    }).Replace("\"", "\\\"");
                }
            }

            var server = string.IsNullOrEmpty(_config.DockerServer) ?
                "mcr.microsoft.com" : _config.DockerServer;
            var ns = string.IsNullOrEmpty(_config.ImagesNamespace) ? "" :
                _config.ImagesNamespace.TrimEnd('/') + "/";
            var version = _config.ImagesTag ?? "latest";
            var image = $"{server}/{ns}iotedge/opc-publisher:{version}";

            _logger.Information("Updating opc publisher module deployment with image {image}", image);

            // Return deployment modules object
            var content = @"
            {
                ""$edgeAgent"": {
                    " + registryCredentials + @"
                    ""properties.desired.modules." + kModuleName + @""": {
                        ""settings"": {
                            ""image"": """ + image + @""",
                            ""createOptions"": """ + createOptions + @"""
                        },
                        ""type"": ""docker"",
                        ""status"": ""running"",
                        ""restartPolicy"": ""always"",
                        ""version"": """ + (version == "latest" ? "1.0" : version) + @"""
                    }
                },
                ""$edgeHub"": {
                    ""properties.desired.routes." + kModuleName + @"ToUpstream"": ""FROM /messages/modules/" + kModuleName + @"/* INTO $upstream"",
                    ""properties.desired.routes.leafToUpstream"": ""FROM /messages/* WHERE NOT IS_DEFINED($connectionModuleId) INTO $upstream""
                }
            }";
            return _serializer.Deserialize<IDictionary<string, IDictionary<string, object>>>(content);
        }

        private const string kDefaultSchemaVersion = "1.0";
        private const string kModuleName = "publisher";
        private readonly IJsonSerializer _serializer;
        private readonly IIoTHubConfigurationServices _service;
        private readonly IContainerRegistryConfig _config;
        private readonly ILogger _logger;
    }
}
