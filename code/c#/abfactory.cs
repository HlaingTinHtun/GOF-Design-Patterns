using System;

namespace HelloWorld
{
    /**
 * Define the Factory interface first.
 */
    abstract class TvSetFactory
    {
        public abstract Tv createTv();
        public abstract CdPlayer createCdPlayer();
    }

    /**
     * Then I will create related factory classes and implements the interface
     * Panasonic  Factory & SamsaungFactory in this scenario.
     */
    class PanasonicFactory : TvSetFactory
    {
        public override Tv createTv()
        {
            return new PanasonicTv();
        }

        public override CdPlayer createCdPlayer()
        {
            return new PanasonicCdPlayer();
        }
    }

    class SamsaungFactory : TvSetFactory
    {
        public override Tv createTv()
        {
            return new SamsaungTv();
        }

        public override CdPlayer createCdPlayer()
        {
            return new SamsaungCdPlayer();
        }

    }

    /**
     * Now lets build family of object classes.
     * Tv & CdPlayer in this scenario.
     */
    abstract class Tv
    {
        public abstract string getTv();
    }

    /**
     * These classes have to be implemented by their relative factory.
     */
    class PanasonicTv : Tv
    {
        public override string getTv()
        {
            return "PanasonicTv";
        }
    }

    class SamsaungTv : Tv
    {
        public override string getTv()
        {
            return "SamsaungTv";
        }
    }

    abstract class CdPlayer
    {
        public abstract string getCdPlayer();
    }

    class PanasonicCdPlayer : CdPlayer
    {
        public override string getCdPlayer()
        {
            return "PanasonicCdPlayer";
        }
    }

    class SamsaungCdPlayer : CdPlayer
    {
        public override string getCdPlayer()
        {
            return "SamsaungCdPlayer";
        }
    }


    // client code
    /**
     * Now you can call the specific factory to return family of objects without knowing their own detail implementations.
     * if you want to get samsaung products, you just need to change the Factory class to samsaung factory.
     */

    class Program
    {
        static void Main(string[] args)
        {
            var tv = new PanasonicFactory();
            Console.WriteLine(tv.createTv().getTv());

            var cdPlayer = new PanasonicFactory();
            Console.WriteLine(cdPlayer.createCdPlayer().getCdPlayer());

        }
    }

}
