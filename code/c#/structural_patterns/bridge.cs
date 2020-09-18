using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * Two Original classes referencing the same DbDriver which is the next hierarchy object
     * After that we can access the methods of their sub concrete classes in our sub classes. query method in this case
     */
    class ApplicationInterface
    {
        protected DbDriver  _dbdriver;

        public ApplicationInterface(DbDriver  dbdriver)
        {
            this._dbdriver = dbdriver;
        }

        public virtual string setDbDriver()
        {
            return "Base DB Driver:" +
                _dbdriver.query();
        }
    }

    class RefinedAbstraction : ApplicationInterface
    {
        public RefinedAbstraction(DbDriver  dbdriver) : base(dbdriver)
        {
        }

        public override string setDbDriver()
        {
            return "Refined DB Driver:" +
                base._dbdriver.query();
        }
    }


    /**
    * This is the interface that need to be referenced by original class instead of inheritance.
    */
    public interface DbDriver 
    {
        string query();
    }

    /**
    * Concrete classes that will have the detail implementations of the interface.
    */
    class MysqlDriver : DbDriver 
    {
        public string query()
        {
            return "Using the mysql driver:\n";
        }
    }

    class OracleDriver : DbDriver 
    {
        public string query()
        {
            return "Using the oracle driver:.\n";
        }
    }

    // client doesn't need to know any implementation details. 
    // Just build the original class and inject the concrete object that will be referenced.
    class Client
    {
        public void ClientCode(ApplicationInterface applicationInterface)
        {
            Console.Write(applicationInterface.setDbDriver());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            ApplicationInterface applicationInterface;

            applicationInterface = new ApplicationInterface(new MysqlDriver());
            client.ClientCode(applicationInterface);

            Console.WriteLine();

            applicationInterface = new RefinedAbstraction(new OracleDriver());
            client.ClientCode(applicationInterface);
        }
    }

}
