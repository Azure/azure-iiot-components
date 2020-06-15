// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Services.OpcUa.Twin.History.Controllers {
    using Microsoft.Azure.IIoT.OpcUa.Core.Models;
    using Microsoft.Azure.IIoT.OpcUa.Api.History;
    using Microsoft.Azure.IIoT.OpcUa.Api.History.Clients;
    using Microsoft.Azure.IIoT.OpcUa.History.Clients;
    using Microsoft.Azure.IIoT.OpcUa.Protocol.Services;
    using Microsoft.Azure.IIoT.OpcUa.Testing.Fixtures;
    using Microsoft.Azure.IIoT.OpcUa.Testing.Tests;
    using Microsoft.Azure.IIoT.Http.Default;
    using Microsoft.Azure.IIoT.Serializers;
    using Serilog;
    using Opc.Ua;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Net.Sockets;
    using Xunit;

    [Collection(ReadCollection.Name)]
    public class ReadControllerValuesTests : IClassFixture<WebAppFixture> {

        public ReadControllerValuesTests(WebAppFixture factory, HistoryServerFixture server) {
            _factory = factory;
            _server = server;
        }

        private HistoryReadValuesTests<string> GetTests() {
            var client = _factory.CreateClient(); // Call to create server
            var module = _factory.Resolve<ITestModule>();
            module.Endpoint = Endpoint;
            var log = _factory.Resolve<ILogger>();
            var serializer = _factory.Resolve<IJsonSerializer>();
            return new HistoryReadValuesTests<string>(() => // Create an adapter over the api
                new HistoricAccessAdapter<string>(
                    new HistoryRawAdapter(
                        new HistoryServiceClient(new HttpClient(_factory, log),
                            new TestConfig(client.BaseAddress), serializer)),
                    new VariantEncoderFactory()), "fakeid");
        }

        public EndpointModel Endpoint => new EndpointModel {
            Url = $"opc.tcp://{Utils.GetHostName()}:{_server.Port}/UA/SampleServer",
            AlternativeUrls = Utils.GetHostAddresses(Utils.GetHostName())
                .Result?.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                    .Select(ip => $"opc.tcp://{ip}:{_server.Port}/UA/SampleServer").ToHashSet(),
            Certificate = _server.Certificate?.RawData?.ToThumbprint()
        };

        private readonly WebAppFixture _factory;
        private readonly HistoryServerFixture _server;

        [Fact]
        public async Task HistoryReadInt64ValuesTest1Async() {
            await GetTests().HistoryReadInt64ValuesTest1Async();
        }

        [Fact]
        public async Task HistoryReadInt64ValuesTest2Async() {
            await GetTests().HistoryReadInt64ValuesTest2Async();
        }

        [Fact]
        public async Task HistoryReadInt64ValuesTest3Async() {
            await GetTests().HistoryReadInt64ValuesTest3Async();
        }

        [Fact]
        public async Task HistoryReadInt64ValuesTest4Async() {
            await GetTests().HistoryReadInt64ValuesTest4Async();
        }
    }
}
