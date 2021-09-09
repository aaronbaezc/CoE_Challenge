using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Models
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public bool Promotion { get; set; }

        public decimal Total => Quantity * (Item?.Price ?? 0);
    }
}
