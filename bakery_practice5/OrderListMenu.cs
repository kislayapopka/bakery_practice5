using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery_practice5
{
    internal class OrderListMenu
    {
        public string Description;
        public int Price;

        public static List<int> Cost = new List<int>();
        public static int supCost;

        public static List<string> Order = new List<string>();
        public static string OrderList = Convert.ToString(Order);

        public OrderListMenu(string description, int price)
        { 
            Description = description;
            Price = price;
        }
    }
}
