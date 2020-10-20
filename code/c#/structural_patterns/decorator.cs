using System;

namespace HelloWorld
{

    /**
     * The interface that must be implemented by concrete class or decorator class
     * Many methods might exist in a real world application.
     */
    abstract class Home
    {
        public abstract string setup();
    }

    /**
     * An example simple concrete class implementing the interface through the setup method.
     */
    class ModernHome : Home
    {
        public override string setup()
        {
            return "ModernHome";
        }
    }

    /**
     * Here is the base decorator class referncing the home interface.
     * Implementations don't exist here as this is the scheme of the concrete classes that will extend to it.
     * we have a condition here to do the wrapping process.
     */
    abstract class Decorator : Home
    {
        protected Home _Home;

        public Decorator(Home Home)
        {
            this._Home = Home;
        }


        public override string setup()
        {
            if (this._Home != null)
            {
                return this._Home.setup();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /**
     * Concrete decorator classes extending the  basedecorator(wrapping the original ModernHome Instance).
     */
    class CinemaDecorator : Decorator
    {
        public CinemaDecorator(Home comp) : base(comp){}

        
        public override string setup()
        {
            return $"CinemaDecorator({base.setup()})";
        }
    }

    class PoolDecorator : Decorator
    {
        public PoolDecorator(Home comp) : base(comp){}

        public override string setup()
        {
            return $"PoolDecorator({base.setup()})";
        }
    }


    /**
     * Clients just have to pass the modernhome instance to each decorator class that they want.
     * We can see here it is wrapping step by step. ModenHome is wrapped by cinema. Afterwards, cinema is wrapped by pool.
     * PoolDecorator(CinemaDecorator(ModernHome))
     */
    class Program
    {
        static void Main(string[] args)
        {

            var moden = new ModernHome();
            CinemaDecorator cinema = new CinemaDecorator(moden);
            PoolDecorator pool = new PoolDecorator(cinema);
            Console.WriteLine(pool.setup());
            
        }
    }

}
