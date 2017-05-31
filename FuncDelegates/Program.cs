using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegates
{
    public class Order
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }

    }



    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order()
            {
                Name = "Widget A",
                Price = 3.14m,
                Quantity = 100,
                Paid = false,
            };
           
            List<Action> actions = new List<Action>();

            //actions.Add( );


}
}
}
