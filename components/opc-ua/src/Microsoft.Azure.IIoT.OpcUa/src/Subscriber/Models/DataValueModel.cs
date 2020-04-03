﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Subscriber.Models {
    using Microsoft.Azure.IIoT.Serializers;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Publisher monitored item sample model
    /// </summary>
    [DataContract]
    public class DataValueModel{

        /// <summary>
        /// Value
        /// </summary>
        [DataMember(Name = "value", Order = 0,
            EmitDefaultValue = false)]
        public VariantValue Value {get; set; }

        /// <summary>
        /// Type id
        /// </summary>
        [DataMember(Name = "typeId", Order = 1,
            EmitDefaultValue = false)]
        public string TypeId { get; set; }

        /// <summary>
        /// Status of the value (Quality)
        /// </summary>
        [DataMember(Name = "status", Order = 2,
            EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// Source Timesamp
        /// </summary>
        [DataMember(Name = "sourceTimestamp", Order = 3,
            EmitDefaultValue = false)]
        public DateTime? SourceTimestamp { get; set; }

        /// <summary>
        /// Server Timestamp
        /// </summary>
        [DataMember(Name = "serverTimestamp", Order = 4,
            EmitDefaultValue = false)]
        public DateTime? ServerTimestamp { get; set; }
    }
}