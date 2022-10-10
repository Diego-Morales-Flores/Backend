using System;
using System.Security.Policy;

namespace BarProyect.Utils
{
    public class Bar
    {
        public delegate void MakeOrderDelegate(TypeProducts[] products, int table);
        private event MakeOrderDelegate _makeOrderEvent;
        private MakeOrderDelegate _makeOrderDelegate;

        public MakeOrderDelegate MakingOrderDelegate { get { return _makeOrderDelegate; } set { _makeOrderDelegate += value; } }
        public event MakeOrderDelegate MakeOrderEvent { add { _makeOrderEvent += value; } remove { _makeOrderEvent -= value; } }

        public Bar() {
            MakeOrderDelegate del1 = new MakeOrderDelegate(MakeOrderHandlerDefault);
            _makeOrderDelegate = del1;
        }


        public void MakeOrder(TypeProducts[] products, int table)
        {
            Console.WriteLine("Makeing Order");
            _makeOrderDelegate(products,table);
        }

        public void MakeOrderHandlerDefault(TypeProducts[] products, int table) {
            Console.WriteLine("Starting");
        }
    }

    public class Order{
        Bar _makeOrder;
        TypeProducts[] _products;
        int _table;
        Order(TypeProducts[] products, int table, Bar makeOrder) {
            _products = products;
            _makeOrder = makeOrder;
            _table = table;
            _makeOrder.MakingOrderDelegate += new Bar.MakeOrderDelegate(MakeOrderHandlerOrder);
        }
        public void MakeOrderHandlerOrder(TypeProducts[] products, int table)
        {
            
        }
    }

    public enum TypeProducts
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
