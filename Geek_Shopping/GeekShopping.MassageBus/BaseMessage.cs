using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekShopping.MassageBus
{
    public class BaseMessage
    {
        public long id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
