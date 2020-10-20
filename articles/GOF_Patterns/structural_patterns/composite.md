## Composite

### Objective
Objects တွေကို tree structures အဖြစ်ပြောင်းလဲသတ်မှတ်ပြီးတော့ individual object ကိုရော၊ composition objects တွေကိုရောကို interface တစ်ခုတည်းနဲ့ တစ်သတ်မှတ်တည်း အဆင်ပြေအောင် လုပ်ဆောင်ပေးပါတယ်။

ထုံစံအတိုင်း objective ဖတ်ပြီး နားလည်မှာမဟုတ်ပါဘူး။ အောက်ကဟာတွေ အကုန်ဖတ်ပြီးမှ objective ပြန်ဖတ်ကြည့်ပါ။ ဒါဆို နားလည်သွားပါမယ်။

### Usage & Implementation

Composite pattern ကိုသုံးမယ်ဆိုရင် ကိုယ့် system ရဲ့ အဓိကအပိုင်းက tree hierarchy အဖြစ်ပြန်လည်ခွဲချနိုင်တဲ့ ပုံစံမျိုးနဲ့ရှိနေရမယ်။ real world example နဲ့အရင်ပြောရရင် MLM လုပ်နေတဲ့ process ကြီးကိုတွေးလိုက်လို့ရတယ်။ Large Member တွေအောက်မှာ normal member တွေထပ်ရှိမယ်၊ normal member တွေအောက်မှာ small member တွေထပ်ရှိမယ်။ အထက်ကနေချလိုက်တဲ့ orders တွေ(methods) တွေက တစ်ဆင့်ခြင်းဆီ အောက်ကိုသယ်သွားမယ်။ ဥပမာ ပစည်းတွေရောင်းခိုင်းတာမျိုးပေါ့။ ဒီနေရာမှာ ဖြစ်တဲ့ issue က ဘာလဲဆိုတော့ တစ်လလုံးစာ ရောင်းရတဲ့ငွေကိုတွက်ချင်တယ်ဆို ဘယ်လိုလုပ်မလဲပေါ့၊ လွယ်တယ်လေ တစ်ဦးခြင်းဆီရဲ့ ငွေကိုလိုက်ပေါင်းချလိုက်ပေါ့၊ ခက်တာက real world မှာလိုက်ပေါင်းတယ်ဆိုတဲ့ analogy ကလွယ်ပေမယ့် programming မှာဆို သူ့မှာရှိတဲ့ nested hierarchy ဖြစ်တဲ့ member , sub member, extra sub member စသည်ဖြင့် အဲ့ဒီ class တွေအားလုံးကို လိုက်ထောက်ပြီး calculation လုပ်ရမယ်၊ မလွယ်ကူသလို တစ်နည်းအားဖြင့် hierarchy ကြီးတယ်ဆို မဖြစ်နိုင်လောက်တော့ဘူး။ ဒီလို အခြေအနေမှာ composite pattern ကိုသုံးပြီး ဖြေရှင်းပါတယ်။
Composite pattern ကိုသုံးပြီး ဘယ်လို ဖြေရှင်းမလဲမပြောခင် composite မှာရှိတဲ့ individual object နဲ့ composition objects ကိုအရင်ပြောပြပါမယ်။ individual ဆိုတာ တစ်ခုတည်းပေါ့၊ ဆိုလိုချင်တာက သူ့အောက်မှာ child objects တွေဆက်မရှိတော့ဘူး၊ MLM အမြင်ရဆို နောက်ဆုံးမှာဝင်ပြီး ပိုက်ဘောမိ သားကောင်ဖြစ်သွားတဲ့ member တွေပေါ့။ ဒါဥပမာ ပေးတာ individual ဆိုရင် သူ့နောက်မှာ child မရှိတော့ဘူး။ compositions ဆိုတာကတော့ complex ဖြစ်တဲ့ object မျိုး child objects တွေရှိချင်လည်းရှိနိုင်တယ် or may be not.
ဒါနားလည်ပြီဆို composite pattern နဲ့ဖြေရှင်းနည်းဆက်ပြောလို့ရပြီ။ ခုနက MLM scenario ကိုပဲဖြေရှင်းကြည့်ရအောင်။ composite pattern မှာ common interface တစ်ခုဆောက်ထားတယ်၊ အဲ့ဒီ interface မှာ monthly ရောင်းရငွေကို တွက်ထုတ်ပေးတဲ့ function ကိုရေးထားမယ်။ individual object ရော composition objects တွေရော လှမ်းသုံးလို့ရမယ်။ ဒါဆိုရင် individual ကိုလှမ်းသုံးတဲ့အချိန် အဲ့ဒီ individual member ရဲ့ ရောင်းရငွေကို simply ရနိုင်တယ်။ compositions တွေလှမ်း access လုပ်ပြီဆို သူ့အောက်မှာရှိတဲ့ tree hierarchy အရ objects တွေကို ဆင်းပြီး looping ထပ်လုပ်ရင်း calculate လုပ်သွားပါတယ်။ ဒီနေရာမှာ interface က method ကိုလှမ်း access လုပ်တဲ့ နေရာမှာ concrete class တွေက individual တွေလား ၊ compositions တွေလား ဆိုတာသိစရာမလိုပါဘူး။ အားလုံးကို common interface တစ်ခုတည်းနဲ့ ထိန်းသွားလို့ရပါတယ်။ ဒီထိ ဖတ်ပြီးပြီရင် objective ကိုပြန်ဖတ်ကြည့်ရင် နားလည်သွားပါလိမ့်မယ်။

## Implementations
အပေါ်ကပြောထားတဲ့အတိုင်းပဲ common interface တစ်ခုရှိမယ်။ အဲ့ထဲမှာတော့ လိုတဲ့ method တွေထည့်ပြီးကြေညာထားမယ်။ individual class ရယ် composition class ရယ်ထပ်ရှိမယ်။ of course သူတို့နှစ်ခုရဲ့ implementation ကတော့မတူဘူး၊ ဒါပေမယ့် common interface တစ်ခုတည်းကိုပဲ share သုံးကြမယ်။ client code ကလှမ်း access လုပ်တဲ့အခါကျရင်တော့ ဒီ class individual လား compositions ကြီးလားဆိုတာကို သိစရာမလိုဘဲ အသုံးပြုနိုင်မှာဖြစ်ပါတယ်။ code samples တွေဆြက်ကည့်ရအောင်။

### PHP Code Sample
```
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


```

### C# Code Sample
```
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * This is the common interface of the composite pattern, declares the necessary operations here.
     * this might be a set of complex operations under here in a real world application.
     */
    interface Component
    {
        string report();
    }

    /**
     * Leaf class where there is no any children under this.
     */
    class Individual : Component
    {
       
        private string _name;
        private int _total;

        public Individual(string name,int total)
        {
            this._name = name;
            this._total = total;
        }
        public string report()
        {
            return _name + " got " + _total;
        }
    }

    /**
     * composite class where has complex component structure.
     * getting to each target children to get the final result
     */
    class Composition : Component
    {
        protected List<Component> _lists = new List<Component>();

        public string report()
        {
            int i = 0;
            string result = "";

            foreach (Component component in this._lists)
            {
                result += component.report();
                if (i != this._lists.Count - 1)
                {
                    result += "\n";
                }
                i++;
            }

            return result;
        }

        public void Add(Component component)
        {
            this._lists.Add(component);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            /**
             * client code can now access both individual and composite class without acknowleding the concrete implementations.
             */
            var p1 = new Individual("Mg Mg", 100);
            var p2 = new Individual("Hla Hla", 200);

            var list = new Composition();
            list.Add(p1);
            list.Add(p2);
            Console.Write(list.report());
        }
    }

}

```

Implementation မှာကျနော် အပေါ်မှာပြောထားတဲ့အတိုင်းပဲ common interface ရယ် individual leaf class ရယ် composite class တွေရယ်ဆောက်ပြီး ရေးပြသွားပါတယ်။ လက်ရှိမှာတော့ sample code ဖြစ်တဲ့အတွက် နားလည်ရလွယ်အောင် ရှင်းရှင်းလေးရေးထားပေမယ့် တစ်ကယ့် real word မှာ common interface မှာတစ်ခြားလိုအပ်တဲ့ method တွေလည်း အများကြီး ရှိနိုင်တာကို သတိချပ်ရပါမယ်။

Composite pattern ကိုသုံးလိုက်ခြင်းအားဖြင့် complex ဖြစ်နိုင်တဲ့ tree hierarchy structures တွေကိုလည်း လွယ်လင့်တကူ break down လုပ်နိုင်သုံးနိုင်သွားတယ်။ အရှေ့ က structural pattern တွေလိုမျိုးပဲ elements အသစ်တွေဝင်လာရင် လက်ရှိ code base ကိုထိခိုက်ခြင်းမရှိဘဲ operation လုပ်နိုင်တယ်။ လက်ရှိမှာ individual ဖြစ်တဲ့ leaf class ရော composite ဖြစ်တဲ့ class ရောမှာ report ဆိုတဲ့ function ကတူတော့ common interface ခွဲထုတ်ထားလို့ရပေမယ့် လက်တွေ့မှာ leaf and composite class ရဲ့တစ်ခြားသော မတူညီတဲ့အရာတွေ အများကြီးရှိနိုင်ပါတယ်။ အဲ့ဒီ အချိန်မှာတော့ common interface ထုတ်ရတဲ့ နေရာမှာ အခက်အခဲတွေပါလာနိုင်ပါတယ်။
