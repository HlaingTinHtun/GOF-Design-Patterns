<?php

// I made a common prototype interface for cloning purpose.
// has a single function called _clone
abstract class Person {

    protected $name;

    abstract function __clone();

    function getName() {
        return $this->name;
    }
    function setName($name) {
        $this->name = $name;
    }
}

// Here is a concrete class extending the person prototype.
// we will implement the _clone method to support object cloning.
//This may contain a lot of fields and implementations but I will keep this simple for now.
class Boy extends Person {
    function __clone() {

    }
}


//here is our first time instantiation of boy concrete class
$person = new Boy();

//next time we will clone that object by using clone.
// we will also pass the name param dynamically.
// clone1
$person1 = clone $person;
$person1->setName('Hlaing');
$person1->getName();

// clone2
$person2 = clone $boy;
$person2->setName('Tin');
$person2->getName();

print_r($person1);
print_r($person2);
 


?>