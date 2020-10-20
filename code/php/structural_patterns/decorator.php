<?php

/**
 * The interface that must be implemented by concrete class or decorator class
 * Many methods might exist in a real world application.
 */
interface Home
{
    public function setup();
}

/**
 * An example simple concrete class implementing the interface through the setup method.
 */
class ModernHome implements Home
{
    public $addon;

    public function setup()
    {
        $this->addon[] = "Added extra bed room";
    }
}

/**
 * Here is the base decorator class referncing the home interface.
 * Implementations don't exist here as this is the scheme of the concrete classes that will extend to it.
 */
abstract class ModernHomeDecorator implements Home
{
    protected $home;

    public function __construct(Home $home)
    {
        $this->home = $home;
    }

    abstract public function setup();
}

/**
 * Concrete decorator classes extending the  basedecorator(wrapping the original ModernHome Instance).
 */
class CinemaDecorator extends ModernHomeDecorator
{
    public function setup()
    {
        $this->home->setup();
        $this->home->addon[] = "added mini cinema";
        $this->addon = $this->home->addon;
    }
}


class PoolDecorator extends ModernHomeDecorator
{
    public function setup()
    {
        $this->home->setup();
        $this->home->addon[] = "added pool";
        $this->addon = $this->home->addon;
    }
}


/**
 * Clients just have to pass the modernhome instance to each decorator class that they want.
 * We can see here it is wrapping step by step. ModenHome is wrapped by cinema. Afterwards, cinema is wrapped by pool.
 * Array ( [0] => Added extra bed room [1] => added mini cinema [2] => added pool )
 */

$home = new ModernHome();
$home = new CinemaDecorator($home);
$home = new PoolDecorator($home);
$home->setup();

print_r($home->addon);