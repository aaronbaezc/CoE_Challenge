using CoEChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Promotions
{
    public class FreeDipOrderPromotion : OrderPromotion
    {
        public FreeDipOrderPromotion(Order order) : base(order)
        {
        }

        public override void Apply()
        {
            this._order.Lines.Add(new OrderLine() { 
                Item = new Item { Name = "Dip", Price = 0 }, 
                Quantity = 1, 
                Promotion = true 
            });
        }

        public override bool IsValid()
        {
            var nachosCount = this._order.Lines.Where(l => !l.Promotion && l.Item.Name == "Nachos").Sum(l => l.Quantity);
            return nachosCount >= 2;
        }
    }
}
