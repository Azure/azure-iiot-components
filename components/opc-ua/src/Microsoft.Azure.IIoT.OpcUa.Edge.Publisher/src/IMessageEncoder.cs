﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Edge.Publisher {
    using Microsoft.Azure.IIoT.OpcUa.Edge.Publisher.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Encoder to encode data set writer messages
    /// </summary>
    public interface IMessageEncoder {

        /// <summary>
        /// Encodes the message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<IEnumerable<NetworkMessageModel>> EncodeAsync(
            IEnumerable<DataSetMessageModel> message);

        /// <summary>
        /// Encode a list of messages
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        Task<IEnumerable<NetworkMessageModel>> EncodeBatchAsync
            (IEnumerable<DataSetMessageModel> messages);
    }
}