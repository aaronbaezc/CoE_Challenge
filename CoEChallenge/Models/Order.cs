using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Models
{
    public class Order
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public List<OrderLine> Lines { get; set; }

    }
}
