using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProxyPatternTests.RemoteProxy
{
    public class GreeterTests
    {
        [Fact]
        public async Task GreetReturnsResponseAsync()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new GreeterService.Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new GreeterService.HelloRequest
            { Name = "GreeterClient" });

            Assert.Equal("Hello GreeterClient", reply.Message);
        }
    }
}
