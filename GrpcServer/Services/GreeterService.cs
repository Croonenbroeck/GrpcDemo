using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }

    public class SHPService : SHPTransmitter.SHPTransmitterBase
    {
        public override Task<SHPStatus> TransmitSHP(SHPObj request, ServerCallContext context)
        {
            return Task.FromResult(new SHPStatus
            {
                SendOk = true
            });
        }
    }
}
