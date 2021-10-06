using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost("{message}")]
        public IActionResult Post(string message)
        {
            // https://api.cloudamqp.com/
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tyttpfys:ItXhh4TU7tIp2LhlIWCyXQCOZt71i5Wb@clam.rmq.cloudamqp.com/tyttpfys");
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            byte[] data = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "messagequeue", body : data);


            return Ok();
        }
    }
}
