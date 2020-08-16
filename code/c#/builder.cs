using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * Builder interface with different methods.
     */
    public interface Builder
    {
        void addVege();

        void addNoodle();

        void addMeat();
    }

    /**
     * Implementing the builder and interface with different implementations
     */
    public class MalaBuilder : Builder
    {
        private Mala _mala = new Mala();

        /**
         * To rest the Mala Object as a new one.
         */
        public MalaBuilder()
        {
            this._mala = new Mala();
        }

        public void addVege()
        {
            this._mala.Add("vegetable");
        }

        public void addNoodle()
        {
            this._mala.Add("noodle");
        }

        public void addMeat()
        {
            this._mala.Add("meat");
        }

        /**
         * returning results for each different implementatins.
         */
        public Mala FinalMala()
        {
            Mala result = this._mala;

            this._mala = new Mala();

            return result;
        }
    }

    /**
     * add function to the list object of ingredients.
     * return the final results of Malabuilder.
     */
    public class Mala
    {
        private List<object> incredigents = new List<object>();

        public void Add(string part)
        {
            this.incredigents.Add(part);
        }

        public string ReturnMala()
        {
            string str = string.Empty;

            for (int i = 0; i < this.incredigents.Count; i++)
            {
                str += this.incredigents[i] + ", ";
            }

            str = str.Remove(str.Length - 2); //removing last comma and space.

            return + str + "\n";
        }
    }

    /**
     * A sample MalaDirector to create a few ready made implementations.
     */
    public class Director
    {
        private Builder _builder;

        public Builder Builder
        {
            set { _builder = value; }
        }

        public void addVegeNoodle()
        {
            this._builder.addVege();
        }

        public void addVegeMeatNoodle()
        {
            this._builder.addVege();
            this._builder.addNoodle();
            this._builder.addMeat();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new MalaBuilder();
            director.Builder = builder;

            Console.WriteLine("Vegetable Mala:");
            director.addVegeNoodle();
            Console.WriteLine(builder.FinalMala().ReturnMala());

            Console.WriteLine("Full Ingredients Mala:");
            director.addVegeMeatNoodle();
            Console.WriteLine(builder.FinalMala().ReturnMala());

            // This time with no MalaDirector usage.
            Console.WriteLine("Custom Mala:");
            builder.addNoodle();
            builder.addMeat();
            Console.Write(builder.FinalMala().ReturnMala());
        }
    }

}
