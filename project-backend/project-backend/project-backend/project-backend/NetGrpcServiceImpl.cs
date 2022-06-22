using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using project_backend.Protos;

namespace PrimerWebApi
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            Console.WriteLine("Enter the number of medicine");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of medicine");
            string s = Console.ReadLine();
            
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = "STATUS OK";
            Console.WriteLine("alooo");
            return Task.FromResult(response);
        }
    }
}
