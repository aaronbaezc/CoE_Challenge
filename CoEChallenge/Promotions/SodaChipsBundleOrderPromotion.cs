using CoEChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Promotions
{
    public class SodaChipsBundleOrderPromotion : OrderPromotion
    {
        public SodaChipsBundleOrderPromotion(Order order) : base(order)
        {

        }
        public override void Apply()
        {
            var sodaCount = this._order.Lines.Where(l => !l.Promotion && l.Item.Name == "Soda (2 lts)").Sum(l => l.Quantity);
            var chipsCount = this._order.Lines.Where(l => !l.Promotion && l.Item.Name == "Potato chips").Sum(l => l.Quantity);

            var chipsToAdd = Math.Min(sodaCount, chipsCount);
            var chipsItem = new Item() { Name = "Potato chips", Price = 0 };

            this._order.Lines.Add(new OrderLine() { Item = chipsItem, Quantity = chipsToAdd, Promotion = true });
        }

        public override bool IsValid()
        {
            var sodas = this._order.Lines.Where(l => !l.Promotion &&  l.Item.Name == "Soda (2 lts)" && l.Quantity > 0);
            var chips = this._order.Lines.Where(l => !l.Promotion &&  l.Item.Name == "Potato chips" && l.Quantity > 0);

            return sodas.Any() && chips.Any();
        }
    }
}
