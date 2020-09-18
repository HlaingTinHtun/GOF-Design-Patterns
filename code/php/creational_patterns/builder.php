<?php

/**
 * Builder interface with different methods.
 */
interface Builder
{
    public function addVege();

    public function addNoodle();

    public function addMeat();
}

/**
 * Implementing the builder and interface with different implementations
 */
class MalaBuilder implements Builder
{
    private $product;

    /**
     * To rest the Mala Object as a new one.
     */
    public function __construct()
    {
        $this->product = new Mala;
    }

    /**
     * All production steps work with the same product instance.
     */
    public function addVege()
    {
        $this->product->ingredients[] = "Vegetable";
    }

    public function addNoodle()
    {
        $this->product->ingredients[] = "Noodle";
    }

    public function addMeat()
    {
        $this->product->ingredients[] = "Meat";
    }

    /**
     * returning results for each different implementatins.
     */
    public function add()
    {
        $result = $this->product;

         /**
         * To rest the Mala Object as a new one.
         */
        $this->product = new Mala;

        return $result;
    }
}

/**
 * display the final results of Malabuilder
 */
class Mala
{
    public $ingredients = [];

    public function returnMala()
    {
        echo implode(', ', $this->ingredients) . "<br>";
    }
}

/**
 * I added a sample MalaDirector to create a few ready made implementations.
 */
class MalaDirector
{
    private $builder;

    public function setBuilder(Builder $builder)
    {
        $this->builder = $builder;
    }

    public function addVegeNoodle()
    {
        $this->builder->addVege();
        $this->builder->addNoodle();
    }

    public function addVegeMeatNoodle()
    {
        $this->builder->addVege();
        $this->builder->addNoodle();
        $this->builder->addMeat();
    }
}


function clientCode(MalaDirector $malaDirector)
{
    $builder = new MalaBuilder;
    $malaDirector->setBuilder($builder);

    echo "This is vege Mala:\n";
    $malaDirector->addVegeNoodle();
    $builder->add()->returnMala();

    echo "Full Ingredients Mala:\n";
    $malaDirector->addVegeMeatNoodle();
    $builder->add()->returnMala();

    // This time with no MalaDirector usage.
    echo "Custom Mala:\n";
    $builder->addNoodle();
    $builder->addMeat();
    $builder->add()->returnMala();
}

$malaDirector = new MalaDirector;
clientCode($malaDirector);