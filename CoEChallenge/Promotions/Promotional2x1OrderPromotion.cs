using CoEChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoEChallenge.Enums;

namespace CoEChallenge.Promotions
{
    public class Promotional2x1OrderPromotion : OrderPromotion
    {
        Dictionary<string, OrderLine[]> groups = new Dictionary<string, OrderLine[]>();
        public Promotional2x1OrderPromotion(Order order) : base(order)
        {

        }

        public override void Apply()
        {
            var lines = groups.Where(g => g.Value.Sum(l => l.Quantity) > 1).Select(g => new OrderLine { Item = g.Value.First().Item, Quantity = g.Value.Sum(l => l.Quantity)});
            var linesToAdd = new List<OrderLine>();
            foreach(var l in lines)
            {
                linesToAdd.Add(new OrderLine { Item = l.Item, Quantity = -(l.Quantity / 2), Promotion = true });
            }
            this._order.Lines.AddRange(linesToAdd);
        }

        public override bool IsValid()
        {
            groups = this._order.Lines
                        .Where(l => !l.Promotion && l.Item.Category != ItemCategory.Snack)
                        .GroupBy(l => l.Item.Name).ToDictionary(x => x.Key, x => x.ToArray());

            return groups.Any(g => g.Value.Sum(l => l.Quantity) > 1);       
        }
    }
}
