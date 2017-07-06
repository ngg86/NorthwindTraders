using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderClasses
{
    public class Orders
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime shippedDate { get; set; }
        public DateTime requiredDate { get; set; }
    }
}
