using CoEChallenge.Models;
using CoEChallenge.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge
{
    public class OrderManager
    {
        public IEnumerable<Type> GetImplementations()
        {
            var type = typeof(OrderPromotion);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);

            return types;
        }
        public void ApplyPromotions(Order order)
        {
            foreach(var p in GetImplementations())
            {
                var oPromotion = Activator.CreateInstance(p, order) as OrderPromotion;
                oPromotion.Evaluate();
            }
        }
        public void ApplyPromotion<T>(Order order) where T : OrderPromotion
        {
            var oPromotion = Activator.CreateInstance(typeof(T), order) as OrderPromotion;
            oPromotion.Evaluate();
        }
    }
}
