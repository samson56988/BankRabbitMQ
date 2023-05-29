// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using System.Text;

public class Sender
{
    public static void Main(string[] args)
    {
        ConnectionFactory factory = new();
        factory.Uri = new Uri(uriString: "amqp://guest:guest@localhost:5672");

        using (var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicTest",false,false,false,null);

            string message = "Getting started with .Net Core RabbitMQ";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
        Console.WriteLine("Hello, World!");
    }
}


