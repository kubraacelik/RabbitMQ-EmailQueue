using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_EMailQueue;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

internal class Program
{
    public static void Main(string[] args)
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

                var consumer = new EventingBasicConsumer(channel);

                channel.BasicConsume("mail-kuyruk", true, consumer);

                consumer.Received += Consumer_Received;

                Console.WriteLine("Mesaj gönderildi. Kuyruk dinleniyor...");
                Console.ReadLine(); // Kuyruk dinlemeyi sürdürebilmek için eklenmiştir.
            }
        }
    }

    private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        try
        {
            var kuyruktanGelenMesaj = Encoding.UTF8.GetString(e.Body.ToArray());
            var mesaj = JsonSerializer.Deserialize<MessageModel>(kuyruktanGelenMesaj);
            SendEmail(mesaj);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }

    }

    static void SendEmail(MessageModel emailContent)
    {
        var smtpClient = new SmtpClient
        {
            Host = "smtp.office365.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential("Nkubracelik@outlook.com", "kubracelik34")
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("Nkubracelik@outlook.com"),
            Subject = emailContent.subject,
            Body = emailContent.message
        };
        mailMessage.To.Add(emailContent.mail); 

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine($"E-posta başarıyla gönderildi: {emailContent.mail}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
        }
    }
}