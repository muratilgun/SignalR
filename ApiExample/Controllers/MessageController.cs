using ApiExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost("Post")]
        public IActionResult Post([FromForm]InfoModel model)
        {
            // https://api.cloudamqp.com/
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tyttpfys:ItXhh4TU7tIp2LhlIWCyXQCOZt71i5Wb@clam.rmq.cloudamqp.com/tyttpfys");
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            string serializeData  =JsonSerializer.Serialize(model);
            byte[] data = Encoding.UTF8.GetBytes(serializeData);
            channel.BasicPublish("", "messagequeue", body : data);


            return Ok();
        }
    }
}
