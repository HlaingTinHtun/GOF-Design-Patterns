<?php

/**
 * This is the common interface of the composite pattern, declares the necessary operations here.
 * this might be a set of complex operations under here in a real world application.
 */
interface Common
{
   public function report();
}

/**
 * Leaf class where there is no any children under this.
 */
class Individual implements Common
{
   private $name;
   private $total;

   public function __construct($name,$total)
   {
       $this->name = $name;
       $this->total = $total;
   }
   public function report()
   {
       echo "$this->name got $this->total\n";
   }
}

/**
 * composite class where has complex component structure.
 * getting to each target children to get the final result
 */
class Composition implements Common
{
   public $report_list = [];

   public function addRecord($list)
   {
       $this->report_list[] = $list;
   }

  /**
   * traversing child nodes.
   */
   public function report()
   {
       foreach($this->report_list as $list) {
           $list->report();
       }
   }
}

/**
 * client code can now access both individual and composite class without acknowleding the concrete implementations.
 */
$p1 = new Individual("Mg Mg",100);
$p2 = new Individual("Hla Hla",200);

$list = new Composition();
$list->addRecord($p1);
$list->addRecord($p2);
$list->report();

?>
