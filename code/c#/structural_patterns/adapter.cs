using System;
namespace HelloWorld
{
    /**
     * The original interface that is working as normal
     */
    public interface Socket
    {
        string input();
    }
    /**
     * This is the simple class that follows the existing target interface `Socket`
     */
    class TwoPinSocket : Socket
    {
        public string input()
        {
            return "two pin input";
        }
    }
    /**
     * This is the conversion class (might be 3rd party service code as well) that will be used later in adapter class.
     */
    class Conversion
    {
        public string change()
        {
            return "changed 2pin to 3pin";
        }
    }
    /**
     * This is the adapter class implementing the original target interface linking with conversion class.
     * this will product the format that is second object want.
     */
    class ThreePinSocket : Socket
    {
        private readonly Conversion _conversion;
        public ThreePinSocket(Conversion conversion)
        {
            this._conversion = conversion;
        }
        public string input()
        {
            return this._conversion.change();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             * The existing twoPinSocket class that follows the target interface.
             */
            Socket socket = new TwoPinSocket();
            Console.WriteLine(socket.input());
            /**
             * threePinSocket conversion that follows target interface using conversion adapter
             */
            Conversion conversion = new Conversion();
            Socket socket = new ThreePinSocket(conversion);
            Console.WriteLine(socket.input());
        }
    }
}