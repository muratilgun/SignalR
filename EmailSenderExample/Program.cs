using Microsoft.AspNetCore.SignalR.Client;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmailSenderExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HubConnection con = new HubConnectionBuilder().WithUrl("https://localhost:5001/messagehub").Build();
            await con.StartAsync();
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tyttpfys:ItXhh4TU7tIp2LhlIWCyXQCOZt71i5Wb@clam.rmq.cloudamqp.com/tyttpfys");
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("messagequeue", true, consumer);
            consumer.Received += async (s, e) =>
            {
                //Email gönderme işlemleri
                //e.Body.Span
                string serializeData = Encoding.UTF8.GetString(e.Body.Span);
                InfoModel model = JsonSerializer.Deserialize<InfoModel>(serializeData);
                EmailSender.Send(model.Email, model.Message);
                Console.WriteLine($"{model.Email} adresine mail gönderilmiştir.");
                await con.InvokeAsync("SendMessageAsync", $"{model.Email} adresine mail gönderilmiştir.");
            };
            Console.Read();
        }
    }
}
