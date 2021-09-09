using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoEChallenge.Enums;

namespace CoEChallenge.Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ItemCategory Category { get; set; } = ItemCategory.Regular;
    }
}
