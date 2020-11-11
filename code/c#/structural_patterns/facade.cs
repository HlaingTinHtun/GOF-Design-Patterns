using System;

namespace HelloWorld
{

    //Waiter facade hiding the complexity of other 3rd party classes.
    //wrapper class of our all third party packages.
    public class Facade
    {
        protected Kitchen _kitchen;

        protected Cashier _cashier;

        public Facade()
        {
            this._kitchen = new Kitchen();
            this._cashier = new Cashier();
        }

        //providing a simple method called order for client
        public string order()
        {
            string result = "";
            result += this._kitchen.cook();
            result += this._cashier.bill();
            return result;
        }
    }

    // 3rd party module classes
    public class Kitchen
    {
        public string cook()
        {
            return "cook order";
        }
    }

    public class Cashier
    {
        public string bill()
        {
            return "print bill";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            Console.Write(facade.order());
        }
    }

}
