using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * This is the common interface of the composite pattern, declares the necessary operations here.
     * this might be a set of complex operations under here in a real world application.
     */
    interface Component
    {
        string report();
    }

    /**
     * Leaf class where there is no any children under this.
     */
    class Individual : Component
    {
       
        private string _name;
        private int _total;

        public Individual(string name,int total)
        {
            this._name = name;
            this._total = total;
        }
        public string report()
        {
            return _name + " got " + _total;
        }
    }

    /**
     * composite class where has complex component structure.
     * getting to each target children to get the final result
     */
    class Composition : Component
    {
        protected List<Component> _lists = new List<Component>();

        public string report()
        {
            int i = 0;
            string result = "";

            foreach (Component component in this._lists)
            {
                result += component.report();
                if (i != this._lists.Count - 1)
                {
                    result += "\n";
                }
                i++;
            }

            return result;
        }

        public void Add(Component component)
        {
            this._lists.Add(component);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            /**
             * client code can now access both individual and composite class without acknowleding the concrete implementations.
             */
            var p1 = new Individual("Mg Mg", 100);
            var p2 = new Individual("Hla Hla", 200);

            var list = new Composition();
            list.Add(p1);
            list.Add(p2);
            Console.Write(list.report());
        }
    }

}
