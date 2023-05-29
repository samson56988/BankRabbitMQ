using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class Reciever
{
    public static void Main(string[] args)
    {
        ConnectionFactory factory = new();
        factory.Uri = new Uri(uriString: "amqp://guest:guest@localhost:5672");

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Recieved message {0}.....",message);
            };

            channel.BasicConsume("BasicTest", true, consumer);

            Console.WriteLine("Press enter to exit Consumer");
            Console.ReadLine();
        }
        
    }
}
