using CoEChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEChallenge.Promotions
{
    public abstract class OrderPromotion
    {
        public Order _order = null;
        public OrderPromotion(Order order)
        {
            _order = order;
        }

        public void Evaluate()
        {
            if (IsValid()) Apply();
        }
        public abstract bool IsValid();
        public abstract void Apply();
    }
}
