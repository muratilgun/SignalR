using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace EmailSenderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tyttpfys:ItXhh4TU7tIp2LhlIWCyXQCOZt71i5Wb@clam.rmq.cloudamqp.com/tyttpfys");
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("messagequeue", true, consumer);
            consumer.Received += (s, e) =>
            {
                //Email gönderme işlemleri
                //e.Body.Span
                string serializeData = Encoding.UTF8.GetString(e.Body.Span);
                InfoModel model = JsonSerializer.Deserialize<InfoModel>(serializeData);
                EmailSender.Send(model.Email, model.Message);
                Console.WriteLine($"{model.Email} adresine mail gönderilmiştir.");
            };
            Console.Read();
        }
    }
}
