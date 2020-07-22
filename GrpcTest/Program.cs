using Grpc.Net.Client;
using SandBoxGrpc;
using System;
using System.Linq;

namespace GrpcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            string name = "Тест 1";
            foreach (var i in Enumerable.Range(0 , 10))
            {
                var reply = client.SayHelloAsync(new HelloRequest { Name = $"{name} {i}" , TestField = i }).ResponseAsync.Result;
                Console.WriteLine();
                Console.WriteLine(new String('-', 10));
                Console.WriteLine("Message: " + reply.Message);
                Console.WriteLine("TestField: " + reply.TestField);
                Console.WriteLine(new String('-', 10));
            }
        }
    }
}
