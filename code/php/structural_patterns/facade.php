<?php

// 3rd party module classes
class Kitchen
{
    public function cook()
    {
        echo "cooking order";
    }
}

class Cashier
{
    public function bill()
    {
        echo "printing bill";
    }
}


//Waiter facade hiding the complexity of other 3rd party classes.
//wrapper class of our all third party packages.
class Waiter
{
    public $kitchen;
    public $cashier;

    public function __construct()
    {
        $this->kitchen = new Kitchen();
        $this->cashier = new Cashier();
    }

    //providing a simple method called order for client
    public function order()
    {
        $this->kitchen->cook();
        $this->cashier->bill();
    }
}


$waiter = new Waiter();
$waiter->order();
