// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.IIoT.Opc.Vault.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Signing request response
    /// </summary>
    public partial class StartSigningRequestResponseApiModel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// StartSigningRequestResponseApiModel class.
        /// </summary>
        public StartSigningRequestResponseApiModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// StartSigningRequestResponseApiModel class.
        /// </summary>
        /// <param name="requestId">Request id</param>
        public StartSigningRequestResponseApiModel(string requestId = default(string))
        {
            RequestId = requestId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets request id
        /// </summary>
        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }

    }
}
