//The following code belongs to an online shopping cart
//Your job is to make the code able to handle the following business rules:

//add a promotional 2X1 discount for every product but any snack
//for each bundle of 1 shampoo and 1 soap you get another free soap
//when you buy 2 bags of nachos or more you get 1 dip for free
//for each bundle of 1 2 lts soda and 1 bag of chips, you get another bag of chips for free

//restrictions: 
//no more than 5 lines per method

//Please apply the OOP tenets: Encapsulation, Polymorphism, 
//Abstraction and Inheritance as you see fit to make this code
//object oriented


using CoEChallenge.Models;
using CoEChallenge.Promotions;
using System;
using System.Collections.Generic;
using static CoEChallenge.Enums;

namespace CoEChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var shampoo = new Item { Name = "Shampoo", Price = 12.95m };
            var soap = new Item { Name = "Soap", Price = 8m };
            var nachos = new Item{Name ="Nachos", Price = 7m, Category = ItemCategory.Snack};
            var soda = new Item{Name ="Soda (2 lts)", Price = 13.50m};
            var chips = new Item{Name ="Potato chips", Price = 10m, Category = ItemCategory.Snack };
            var dip = new Item { Name = "Dip", Price = 10m };
            
            var order = new Order();
            order.Lines.Add(new OrderLine { Item = shampoo, Quantity = 2 });
            order.Lines.Add(new OrderLine { Item = shampoo, Quantity = 2 });
            order.Lines.Add(new OrderLine { Item = soap, Quantity = 5 });
            order.Lines.Add(new OrderLine{Item = nachos, Quantity = 2});
            order.Lines.Add(new OrderLine{Item = soda, Quantity = 1});
            order.Lines.Add(new OrderLine{Item = chips, Quantity = 1});

            OrderManager oManager = new OrderManager();
            oManager.ApplyPromotions(order);
            //oManager.ApplyPromotion<FreeDipOrderPromotion>(order);

            decimal total = 0;
            foreach (var line in order.Lines)
            {
                var promoTag = line.Promotion ? "(PROMO) " : "";
                Console.WriteLine($"{line.Total.ToString("C").PadLeft(8)} - {line.Quantity.ToString().PadLeft(5)} - {promoTag}{line.Item.Name}");
                total += line.Total;
            }


            decimal tax = total * 0.16m;
            Console.WriteLine($"the expected cost is 101.3840. The actual cost is {total + tax}");
            
        }
    }
}