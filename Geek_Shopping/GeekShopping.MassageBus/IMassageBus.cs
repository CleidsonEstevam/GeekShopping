using System;
using System.Threading.Tasks;

namespace GeekShopping.MassageBus
{
    public interface IMassageBus
    {
        Task PublicManager(BaseMessage massage, string queueName);
    }
}
