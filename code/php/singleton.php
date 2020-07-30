<?php

/**
 * Singleton class
 */
class LogSingleton {
    /**
     * I kept this attribute and constructor as private so that other sub class can't instantiate
     * it can also be protected if you want to allow sub classes to be instantiated
     */
    private static $intance = null;

    private function __construct() {
    }

    /**
     * I will assign the singleton instance if $instance is null.
     * otherwise will return directly.
     */
    public static function log() {
      if (self::$intance == null) {
         self::$intance = new LogSingleton();
      }
      return self::$intance;
    }

    //can also declare other public functions below.
    public function debugLog()
    {
      return "debug log";
    }
  }

//client code
$client = LogSingleton::log(); // this is the singleton instance.
var_dump($client->debugLog());
