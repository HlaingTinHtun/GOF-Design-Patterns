<?php

/**
 * This is the original application interface 
 * where we place the methods need to develop from its concrete sub classes
 */
interface ApplicationInterface
{
    public function setDbDriver(DbDriver $dbDriver);
 
    public function query($query);
}

/**
 * This abstract class will implements the interface as we have to reference the next hierarchy object here.
 * After that we can access the methods of their sub concrete classes in our sub classes. see below.
 */
abstract class Application implements ApplicationInterface
{
   protected $dbDriver;
 
   public function setDbDriver(DbDriver $dbDriver)
   {
       $this->dbDriver = $dbDriver;
   }
}

/**
* Concrete sub classes of the original class working with the reference object's method.
*/
class android extends Application
{
    public function query($query)
    {
        $query .= "\n\n running android app query\n";
 
        return $this->dbDriver->handleQuery($query);
    }
}
 
class ios extends Application
{
    public function query($query)
    {
        $query .= "\n\n running ios app query\n";
 
        return $this->dbDriver->handleQuery($query);
    }
}


/**
* This is the interface that need to be referenced by original class instead of inheritance.
*/
interface DbDriver
{
    public function handleQuery($query);
}

/**
* Concrete classes that will have the detail implementations of the interface.
*/
class MysqlDriver implements DbDriver
{
    public function handleQuery($query)
    {
        echo "\nUsing the mysql driver: ".$query;
    }
}
 
 
class OracleDriver implements DbDriver
{
    public function handleQuery($query)
    {
        echo "\nUsing the oracle driver: ".$query;
    }
}


//client code
// client doesn't need to know any implementation details. 
// Just build the original concrete class and inject the concrete object that will be referenced.
 
$android = new android();
$android->setDbDriver(new MysqlDriver());
echo $android->query("select * from table");
 
$android->setDbDriver(new OracleDriver());
echo $android->query("select * from table");
 

$ios = new ios();
$ios->setDbDriver(new MysqlDriver());
echo $ios->query("select * from table");

$ios->setDbDriver(new OracleDriver());
echo $ios->query("select * from table");
 