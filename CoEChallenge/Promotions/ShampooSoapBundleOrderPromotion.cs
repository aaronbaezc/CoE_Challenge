using CoEChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Promotions
{
    public class ShampooSoapBundleOrderPromotion : OrderPromotion
    {
        public ShampooSoapBundleOrderPromotion(Order order) : base(order)
        {

        }
        public override void Apply()
        {
            var shampoosCount = this._order.Lines.Where(l => !l.Promotion && l.Item.Name == "Shampoo").Sum(l => l.Quantity);
            var soapsCount = this._order.Lines.Where(l => !l.Promotion && l.Item.Name == "Soap").Sum(l => l.Quantity);

            var soapsToAdd = Math.Min(shampoosCount, soapsCount);
            var soapItem = new Item() { Name = "Soap", Price = 0 };

            this._order.Lines.Add(new OrderLine() { Item = soapItem, Quantity = soapsToAdd, Promotion = true });
        }

        public override bool IsValid()
        {
            var shampoos = this._order.Lines.Where(l => !l.Promotion &&  l.Item.Name == "Shampoo" && l.Quantity > 0);
            var soaps = this._order.Lines.Where(l => !l.Promotion &&  l.Item.Name == "Soap" && l.Quantity > 0);

            return shampoos.Any() && soaps.Any();
        }
    }
}
