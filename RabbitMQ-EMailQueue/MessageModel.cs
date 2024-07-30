using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_EMailQueue
{
    public class MessageModel
    {
        public string mail {  get; set; }
        public string message { get; set; } = "Rabbitmq Dersi";
        public string subject { get; set; } = "Rabbitmq 2024";
    }
}
