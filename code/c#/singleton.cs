using System;

namespace HelloWorld
{
    class LogSingleton
    {
        /**
         * I kept this attributes as private so that other sub class can't instantiate
         * it can also be protected if you want to allow sub classes to be instantiated
         */
        private static LogSingleton instance;

        /**
         * for the first use for this class, s_lock will have a object.
         * This will later use along with lock function to protect from multi thread base.
         */
        private static readonly object s_lock = new object();

        public static LogSingleton log()
        {
            if (instance == null)
            {
                /**
                 * The client who has s_lock will proceed this condition.
                 */
                lock (s_lock)
                {
                    /**
                     * I will assign the singleton instance if instance is null.
                     * otherwise will return directly.
                     */
                    if (instance == null)
                    {
                        instance = new LogSingleton();
                    }
                }
            }
            return instance;
        }

        //can also declare other public functions below.
        public string debugLog()
        {
            return "debug log";
        }

        //client code
        class Program
        {
            static void Main(string[] args)
            {
                var client = LogSingleton.log(); // this is the singleton instance.
                Console.WriteLine(client.debugLog());

            }
        }
    }
}
