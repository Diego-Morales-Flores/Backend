using System;
using System.Reflection.Metadata.Ecma335;

namespace BarConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BAR");
            Bar bar= new Bar();
            Enum[] enums = new Enum[] { Type.Beer, Type.Martini, Type.Manhattan };
            bar.MakeOrder(enums, 3);
            Order order1 = new Order(enums, 3,bar);          
        }
    }
        public class Bar
        {
            public delegate void MakeOrderDelegate(Enum[] products, int table);
            private event MakeOrderDelegate _makeOrderEvent;
            private MakeOrderDelegate _makeOrderDelegate;

            public MakeOrderDelegate MakingOrderDelegate { get { return _makeOrderDelegate; } set { _makeOrderDelegate += value; } }
            public event MakeOrderDelegate MakeOrderEvent { add { _makeOrderEvent += value; } remove { _makeOrderEvent -= value; } }

            public Bar()
            {
                MakeOrderDelegate del1 = new MakeOrderDelegate(MakeOrderHandlerDefault);
                _makeOrderEvent = del1;
                
            }


            public void MakeOrder(Enum[] products, int table)
            {
                Console.WriteLine("Makeing Order");
                _makeOrderEvent(products,table);
            }

            public void MakeOrderHandlerDefault(Enum[] products, int table)
            {
                Console.WriteLine("Starting");
            }
        }

        public class Order
        {
            Bar _makeOrder;
            Enum[] _products;
            int _table;
            public Order(Enum[] products, int table, Bar makeOrder)
            {
                _products = products;
                _makeOrder = makeOrder;
                _table = table;
                _makeOrder.MakeOrderEvent += new Bar.MakeOrderDelegate(MakeOrderHandlerOrder);
            }
            public void MakeOrderHandlerOrder(Enum[] products, int table)
            {
            Console.WriteLine("Creating a Order");
            Console.WriteLine(products);
            Console.WriteLine("for the table: "+table);
            }
        }

        public enum Type
    {
            Margarita,
            Mojito,
            Gintonic,
            Caipirinha,
            Manhattan,
            PiñaColada,
            Daiquiri,
            Cosmopolitan,
            Martini,
            Beer
        }


}
