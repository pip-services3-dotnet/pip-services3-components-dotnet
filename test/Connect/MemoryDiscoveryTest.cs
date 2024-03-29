﻿using Xunit;

using PipServices3.Commons.Config;

namespace PipServices3.Components.Connect
{
    public sealed class MemoryDiscoveryTest
    {
        private ConfigParams config = ConfigParams.FromTuples(
            "key1.host", "10.1.1.100",
            "key1.port", "8080",
            "key2.host", "10.1.1.101",
            "key2.port", "8082"
        );

        [Fact]
        public async void TestResolveConnections()
        {
            var discovery = new MemoryDiscovery();
            discovery.Configure(config);

            // Resolve one
            var connection = await discovery.ResolveOneAsync("123", "key1");

            Assert.Equal("10.1.1.100", connection.Host);
            Assert.Equal(8080, connection.Port);

            connection = await discovery.ResolveOneAsync("123", "key2");

            Assert.Equal("10.1.1.101", connection.Host);
            Assert.Equal(8082, connection.Port);


            // Resolve all
            await discovery.RegisterAsync(null, "key1",
                ConnectionParams.FromTuples("host", "10.3.3.151")
            );

            var connections = await discovery.ResolveAllAsync("123", "key1");

            Assert.True(connections.Count > 1);
        }
    }
}
