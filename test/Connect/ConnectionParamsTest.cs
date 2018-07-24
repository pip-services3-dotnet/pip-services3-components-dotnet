using Xunit;

namespace PipServices.Components.Connect
{
    //[TestClass]
    public sealed class ConnectionParamsTest
    {
        [Fact]
        public void TestDiscovery()
        {
            var connection = new ConnectionParams();
            connection.DiscoveryKey = null;
            Assert.Null(connection.DiscoveryKey);

            connection.DiscoveryKey = "Discovery key value";
            Assert.Equal(connection.DiscoveryKey, "Discovery key value");
            Assert.True(connection.UseDiscovery);
        }

        [Fact]
        public void TestProtocol()
        {
            var connection = new ConnectionParams();
            connection.Protocol = null;
            Assert.Equal(connection.Protocol, "http");
            Assert.Null(connection.GetProtocol(null));
            Assert.Equal(connection.GetProtocol("https"), "https");
            connection.Protocol = "https";

            Assert.Equal(connection.Protocol, "https");
        }

        [Fact]
        public void TestHost()
        {
            var connection = new ConnectionParams();
            Assert.Equal(connection.Host, "localhost");

            connection.Host = null;
            Assert.Equal(connection.Host, "localhost");

            connection.Host = "localhost1";
            Assert.Equal(connection.Host, "localhost1");
        }

        [Fact]
        public void TestPort()
        {
            var connection = new ConnectionParams();
            Assert.Equal(connection.Port, 8080);

            connection.Port = 3000;
            Assert.Equal(connection.Port, 3000);
        }

        [Fact]
        public void TestUri()
        {
            var connection = new ConnectionParams();
            Assert.Null(connection.Uri);

            connection.Protocol = "https";
            connection.Port = 3000;
            connection.Host = "pipgoals";
            Assert.Null(connection.Uri);
        }
    }
}
