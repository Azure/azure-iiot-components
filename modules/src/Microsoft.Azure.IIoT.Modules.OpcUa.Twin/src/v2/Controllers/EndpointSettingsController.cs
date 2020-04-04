// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Modules.OpcUa.Twin.v2.Supervisor {
    using Microsoft.Azure.IIoT.OpcUa.Registry.Models;
    using Microsoft.Azure.IIoT.OpcUa.Core.Models;
    using Microsoft.Azure.IIoT.OpcUa.Edge;
    using Microsoft.Azure.IIoT.Module.Framework;
    using Microsoft.Azure.IIoT.Hub;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using Prometheus;

    /// <summary>
    /// Endpoint settings controller
    /// </summary>
    [Version(1)]
    [Version(2)]
    public class EndpointSettingsController : ISettingsController {

        /// <summary>
        /// Endoint url for direct server access
        /// </summary>
        public string EndpointUrl {
            get => _endpointUrl;
            set => _endpointUrl = string.IsNullOrEmpty(value) ? null : value;
        }

        /// <summary>
        /// Endoint url for direct server access
        /// </summary>
        public Dictionary<string, string> AlternativeUrls {
            get => _alternativeUrls;
            set => _alternativeUrls = value;
        }

        /// <summary>
        /// Endpoint security policy to use.
        /// </summary>
        public string SecurityPolicy {
            get => _securityPolicy;
            set => _securityPolicy = string.IsNullOrEmpty(value) ? null : value;
        }

        /// <summary>
        /// Security mode to use for communication
        /// </summary>
        public JToken SecurityMode {
            get => JToken.FromObject(_securityMode);
            set => _securityMode = value?.ToObject<SecurityMode>();
        }

        /// <summary>
        /// Endpoint certificate thumbprint to validate
        /// </summary>
        public Dictionary<string, string> Certificate {
            get => _certificate.EncodeAsDictionary();
            set => _certificate = value.DecodeAsByteArray();
        }

        /// <summary>
        /// State of the endpoint
        /// </summary>
        public EndpointConnectivityState State {
            get => _twin.State;
            set { /* Only reporting */ }
        }

        /// <summary>
        /// Create controller with service
        /// </summary>
        /// <param name="twin"></param>
        public EndpointSettingsController(ITwinServices twin) {
            _twin = twin ?? throw new ArgumentNullException(nameof(twin));
        }

        /// <summary>
        /// Apply endpoint update
        /// </summary>
        /// <returns></returns>
        public Task ApplyAsync() {
            _applyAsync.Inc();
            return _twin.SetEndpointAsync(
                new EndpointModel {
                    SecurityMode = _securityMode,
                    SecurityPolicy = _securityPolicy,
                    Url = _endpointUrl,
                    AlternativeUrls = _alternativeUrls?.DecodeAsList().ToHashSetSafe(),
                    Certificate = _certificate
                });
        }

        private string _endpointUrl;
        private string _securityPolicy;
        private SecurityMode? _securityMode;
        private byte[] _certificate;
#pragma warning disable IDE0032 // Use auto property
        private Dictionary<string, string> _alternativeUrls;
#pragma warning restore IDE0032 // Use auto property
        private readonly ITwinServices _twin;
        private static readonly String _PREFIX = "iiot_edge_twin_";
        private static readonly Counter _applyAsync = Metrics.CreateCounter(_PREFIX + "apply_async", "call to applyAsync");
    }
}
