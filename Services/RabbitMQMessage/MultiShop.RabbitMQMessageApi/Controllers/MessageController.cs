using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            
            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, false, null);

            var messageContent = "Merhaba bugün hava çok soğuk";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish("", "Kuyruk2", null, byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        private static string message;

        [HttpGet]
        public async Task <IActionResult> ReadMessage()
        {
            string message = "";
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            var tcs = new TaskCompletionSource<string>();

            consumer.Received += (model, ea) =>
            {
                var byteMessage = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
                tcs.SetResult(message); //Mesajı swagger'da görebilmek için kullanıdk.
            };

            channel.BasicConsume("Kuyruk1", false, consumer);

            var receivedMessage = await tcs.Task;


            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(receivedMessage);
            }
        }
    }
}
