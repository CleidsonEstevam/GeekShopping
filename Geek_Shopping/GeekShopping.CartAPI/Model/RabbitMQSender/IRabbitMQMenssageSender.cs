using System.Collections;

namespace GeekShopping.CartAPI.Model.RabbitMQSender
{
    public interface IRabbitMQMenssageSender
    {
        void SendMassage(BaseMessage baseMessage, string queueName);
    }
}
