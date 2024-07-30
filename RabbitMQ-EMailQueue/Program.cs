using RabbitMQ.Client;
using RabbitMQ_EMailQueue;
using System.Text;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            Port = 5672
        };

        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("mail-kuyruk",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);


                List<string> emailAddresses = new List<string>()
            {
                "e.sude.clk00@gmail.com",
                "kkbra.celik92@gmail.com"
            };

                List<MessageModel> messageModels = new List<MessageModel>();

                MessageModel model = new MessageModel();
                model.mail = "kkbra.celik92@gmail.com";
                messageModels.Add(model);

                foreach (var mail in emailAddresses)
                {
                    MessageModel model2 = new MessageModel();
                    model2.mail = mail;
                    model2.message = $"{model2.message} - {Guid.NewGuid()}";
                    messageModels.Add(model2);
                }

                foreach (var messages in messageModels)
                {
                    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(messages));
                    channel.BasicPublish(string.Empty, "mail-kuyruk", null, body);
                }
            }
        }
    }
}