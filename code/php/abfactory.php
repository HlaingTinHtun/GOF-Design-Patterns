<?php

/**
 * Define the Factory interface first.
 */
abstract class TvSetFactory
{
    abstract function createTv();
    abstract function createCdPlayer();
}

/**
 * Then I will create related factory classes and extends the interface
 * Panasonic  Factory & SamsaungFactory in this scenario.
 */
class PanasonicFactory extends TvSetFactory
{
    public function createTv()
    {
        return new PanasonicTv;
    }

    public function createCdPlayer()
    {
        return new PanasonicCdPlayer();
    }
}

class SamsaungFactory extends TvSetFactory
{
    public function createTv()
    {
        return new SamsaungTv;
    }

    public function createCdPlayer()
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
    abstract function getTv();
}

/**
 * These classes have to be implemented by their relative factory.
 */
class PanasonicTv extends Tv
{
    public function getTv()
    {
        return "PanasonicTv";
    }
}

class SamsaungTv extends Tv
{
    public function getTv(): string
    {
        return "SamsaungTv";
    }
}

abstract class CdPlayer
{
    abstract function getCdPlayer();
}

class PanasonicCdPlayer extends CdPlayer
{
    public function getCdPlayer()
    {
        return "PanasonicCdPlayer";
    }
}

class SamsaungCdPlayer extends CdPlayer
{
  public function getCdPlayer()
  {
      return "SamsaungCdPlayer";
  }
}


// client code
function test($tvSetFactory)
{
    $tv = $tvSetFactory->createTv();
    echo('TV model is'.$tv->getTv());

    $cdPlayer = $tvSetFactory->createCdPlayer();
    echo('CD Player model is'.$cdPlayer->getCdPlayer());
}

/**
 * Now you can call the specific factory to return family of objects without knowing their own detail implementations.
 * if you want to get samsaung products, you just need to change the Factory class to samsaung factory.
 */
$tvSetFactory = new PanasonicFactory;
test($tvSetFactory);
