﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace IIoTPlatform_E2E_Tests {
    using System;

    /// <summary>
    /// Contains constants using for End 2 End testing
    /// </summary>
    internal static class TestConstants {
        /// <summary>
        /// Character that need to be used when split value of "PLC_SIMULATION_URLS"
        /// </summary>
        public static char SimulationUrlsSeparator = ';';

        /// <summary>
        /// Name of the test assembly
        /// </summary>
        public const string TestAssemblyName = "IIoTPlatform-E2E-Tests";

        /// <summary>
        /// Default timeout of web calls
        /// </summary>
        public const int DefaultTimeoutInMilliseconds = 90000;

        /// <summary>
        /// Default timeout of loading edge modules
        /// </summary>
        public const int MaxDelayToEdgeModulesToBeLoadedInMilliseconds = 10 * 60 * 1000;

        /// <summary>
        /// Contains constants for all routes to Industrial IoT Platform
        /// </summary>
        internal static class APIRoutes {
            /// <summary>
            /// Route to enable an OPC UA endpoint
            /// </summary>
            public static string RegistryActivateEndpointsFormat = "/registry/v2/endpoints/{0}/activate";

            /// <summary>
            /// Route to publish single OPC UA node from OPC Publisher
            /// </summary>
            public static string PublisherStartFormat = "/publisher/v2/publish/{0}/start";

            /// <summary>
            /// Route to read all publishing jobs
            /// </summary>
            public static string PublisherJobs = "/publisher/v2/jobs";

            /// <summary>
            /// Route to read single publishing jobs
            /// </summary>
            public static string PublisherJobsFormat = "/publisher/v2/jobs/{0}";

            /// <summary>
            /// Route to applications within registry
            /// </summary>
            public const string RegistryApplications = "/registry/v2/applications";

            /// <summary>
            /// Route to endpoints within registry
            /// </summary>
            public const string RegistryEndpoints = "/registry/v2/endpoints";
        }

        /// <summary>
        /// Contains constants for all HTTP headers
        /// </summary>
        internal static class HttpHeaderNames {
            /// <summary>
            /// Name of header used for authentication
            /// </summary>
            public const string Authorization = "Authorization";
        }

        /// <summary>
        /// Contains constants for OPC PLC
        /// </summary>
        internal static class OpcSimulation {
            /// <summary>
            /// Default port of OPC UA Server endpoint of OPC PLC
            /// </summary>
            public const ushort Port = 50000;

            /// <summary>
            /// Name of Published Nodes Json file generated by OPC PLC, containing information
            /// of provided (simulated) OPC UA Nodes
            /// </summary>
            public const string PublishedNodesFile = "pn.json";
        }

        /// <summary>
        /// Contains names of Environment variables available for tests
        /// </summary>
        internal static class EnvironmentVariablesNames {
            /// <summary>
            /// Base URL of Industrial IoT Platform
            /// </summary>
            public const string PCS_SERVICE_URL = "PCS_SERVICE_URL";

            /// <summary>
            /// Tenant name used for authentication of Industrial IoT Platform
            /// </summary>
            public const string PCS_AUTH_TENANT = "PCS_AUTH_TENANT";

            /// <summary>
            /// Client App ID used for authentication of Industrial IoT Platform
            /// </summary>
            public const string PCS_AUTH_CLIENT_APPID = "PCS_AUTH_CLIENT_APPID";

            /// <summary>
            /// Client Secrete used for authentication of Industrial IoT Platform
            /// </summary>
            public const string PCS_AUTH_CLIENT_SECRET = "PCS_AUTH_CLIENT_SECRET";

            /// <summary>
            /// Name of Industrial IoT Platform instance
            /// </summary>
            public const string ApplicationName = "ApplicationName";

            /// <summary>
            /// Semicolon separated URLs to load published_nodes.json from OPC-PLCs
            /// </summary>
            public const string PLC_SIMULATION_URLS = "PLC_SIMULATION_URLS";

            /// <summary>
            /// Device identity of edge device at IoT Hub
            /// </summary>
            public const string IOT_EDGE_DEVICE_ID = "IOT_EDGE_DEVICE_ID";

            /// <summary>
            /// DNS name of edge device
            /// </summary>
            public const string IOT_EDGE_DEVICE_DNS_NAME = "IOT_EDGE_DEVICE_DNS_NAME";

            /// <summary>
            /// User name of vm that hosting edge device
            /// </summary>
            public const string PCS_SIMULATION_USER = "PCS_SIMULATION_USER";

            /// <summary>
            /// Password of vm that hosting edge device
            /// </summary>
            public const string PCS_SIMULATION_PASSWORD = "PCS_SIMULATION_PASSWORD";

            /// <summary>
            /// IoT Hub connection string
            /// </summary>
            public const string PCS_IOTHUB_CONNSTRING = "PCS_IOTHUB_CONNSTRING";

            /// <summary>
            /// The connection string of the event-hub compatible endpoint of IoT Hub.
            /// </summary>
            public const string IOTHUB_EVENTHUB_CONNECTIONSTRING = "IOTHUB_EVENTHUB_CONNECTIONSTRING";

            /// <summary>
            /// The connection string of the storage account that will be used for checkpointing (when monitoring IoT Hub)
            /// </summary>
            public const string STORAGE_CONNECTIONSTRING = "STORAGE_CONNECTIONSTRING";

            /// <summary>
            /// The service base url of the TestEventProcessor
            /// </summary>
            public const string TESTEVENTPROCESSOR_BASEURL = "TESTEVENTPROCESSOR_BASEURL";

            /// <summary>
            /// The username to authenticate against the TestEventProcessor (Basic Auth)
            /// </summary>
            public const string TESTEVENTPROCESSOR_USERNAME = "TESTEVENTPROCESSOR_USERNAME";

            /// <summary>
            /// The password to authenticate against the TestEventProcessor (Basic Auth)
            /// </summary>
            public const string TESTEVENTPROCESSOR_PASSWORD = "TESTEVENTPROCESSOR_PASSWORD";

            /// <summary>
            /// Container Registry server
            /// </summary>
            public const string PCS_CONTAINER_REGISTRY_SERVER = "PCS_CONTAINER_REGISTRY_SERVER";

            /// <summary>
            /// Container Registry user name
            /// </summary>
            public const string PCS_CONTAINER_REGISTRY_USER = "PCS_CONTAINER_REGISTRY_USER";

            /// <summary>
            /// Container Registry password
            /// </summary>
            public const string PCS_CONTAINER_REGISTRY_PASSWORD = "PCS_CONTAINER_REGISTRY_PASSWORD";

            /// <summary>
            ///Images namespace
            /// </summary>
            public const string PCS_IMAGES_NAMESPACE = "PCS_IMAGES_NAMESPACE";

            /// <summary>
            /// Images tag
            /// </summary>
            public const string PCS_IMAGES_TAG = "PCS_IMAGES_TAG";
        }
    }
}
