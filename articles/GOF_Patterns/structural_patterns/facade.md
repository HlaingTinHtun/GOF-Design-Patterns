## Facade Design Pattern

### Objective
Strcture Design Pattern တစ်ခုဖြစ်ပြီးတော့ Framework level, Library level တွေမှာရှိတဲ့ complex ဖြစ်နိုင်တဲ့ class modules တွေအတွက် client code က access လုပ်ရလွယ်ကူတဲ့ ရိုးရှင်းတဲ့ Interface တစ်ခုပြန်ထုတ်ပေးထားခြင်းဖြစ်ပါတယ်။

အောက်က usage & implementation တွေဆက်ဖတ်ပြီးမှ objective ကိုတစ်ခေါက်ပြန်ဖတ်ပါမယ်။

### Usage & Implementation

ပထမဦးဆုံး Façade ကဘယ်လိုအသုံးဝင်လဲဆိုတာကို နားလည်အောင် ကြိုးစားကြည့်ပါမယ်။ ဆိုပါစို့ ကျနော်တို့ဆီမှာ system တစ်ခုရှိတယ်၊ အဲ့ system မှာသုံးထားတဲ့ third party packages တွေအများကြီးရှိတယ်။ ဒါဆိုလို့ရှိရင် ကျနော်တို့ system code တွေထဲမှာ အဲ့ဒီ 3rd party packages တွေကို လှမ်းခေါ်သုံးထားရမယ်။ ခေါ်သုံးထားမှသာ သက်ဆိုင်တဲ့ functions တွေကို access လုပ်လို့ရမှာကိုး။

အဲ့လို ခေါ်သုံးလိုက်ခြင်းအားဖြင့် ကျနော်တို့ရဲ့ system code ဟာ 3rd party dependencies တွေနဲ့ coupling tight ဖြစ်သွားပြီးတော့ code ကို maintain လုပ်ရတဲ့ နေရာမှာ အခက်အခဲတွေကြုံလာရနိုင်ပါတယ်။ ဒီလိုအခြေအနေမျိုးတွေမှာ Façade Interface တစ်ခုထုတ်ပြီးတော့ ဖြေရှင်းနိုင်ပါတယ်။

Real world နဲ့ ဥပမာပေးရရင် စားသောက်ဆိုင်တစ်ခုသွားပြီးတော့ order မှာတော့မယ်ဆိုရင် ကျနော်တို့ မှာလိုက်တဲ့ order ရဖို့အတွက်လုပ်ရတဲ့ process တွေ behind the scences မှာအများကြီးရှိပေမယ့် တစ်ကယ်တမ်း ကျနော်တို့ ထိတွေ့ရမှာက waiter ဆိုတဲ့ interface နဲ့ပဲ ထိတွေ့ရမှာ၊ waiter ကို ကျနော်တို့ လိုချင်တာပြောလိုက်ရုံနဲ့တင်အဆင်ပြေသွားပြီ။ နောက်ကွယ်က ချက်ပြုတ်တာတွေ၊ order serve လုပ်တာတွေက ကျနော်တို့သိစရာမလိုတော့ဘူး။ 

Implementation လုပ်တာကလည်း မခက်ခဲပါဘူး၊ ကျနော်တို့ဆီမှာ သက်ဆိုင်ရာ third party classes တွေရှိမယ်၊ အဲ့ဒီ classes တွေကို Façade ကနေပြီးတော့ wrap လှမ်းလုပ်ထားလိုက်မယ်။ ဒါဆိုရင် client code က façade ကိုပဲလှမ်းသုံးရင်အဆင်ပြေသွားပြီ၊ တစ်ခြား third party classes တွေကိုသိစရာမလိုတော့ဘူး။ အပေါ်မှာပြောထားတဲ့ restaurant က example နဲ့ပဲ code ရေးကြည့်ရအောင်။

### PHP Sample Code
```
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

```

### C# Sample Code

```
using System;

namespace HelloWorld
{

    //Waiter facade hiding the complexity of other 3rd party classes.
    //wrapper class of our all third party packages.
    public class Facade
    {
        protected Kitchen _kitchen;

        protected Cashier _cashier;

        public Facade()
        {
            this._kitchen = new Kitchen();
            this._cashier = new Cashier();
        }

        //providing a simple method called order for client
        public string order()
        {
            string result = "";
            result += this._kitchen.cook();
            result += this._cashier.bill();
            return result;
        }
    }

    // 3rd party module classes
    public class Kitchen
    {
        public string cook()
        {
            return "cook order";
        }
    }

    public class Cashier
    {
        public string bill()
        {
            return "print bill";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            Console.Write(facade.order());
        }
    }

}

```


Code sample နှစ်ခုလုံးကို restaurant examples ကိုပဲ implement လုပ်ပြထားပါတယ်။ Kitchen နဲ့ cashier ကတော့ 3rd party library modules တွေပေါ့။ Waiter ဆိုတဲ့ façade ကနေပြီးတော့မှ အဲ့ဒီ kitchen & cashier classes တွေကို wrap လုပ်ထားပေးပြီးတော့ ရိုးရှင်းတဲ့ order ဆိုတဲ့ function တစ်ခုထုတ်ပေးထားပါတယ်။ client က façade ကထုတ်ပေးထားတဲ့ order ဆိုတဲ့ function ကိုပဲ access လုပ်လိုက်ရင် အဆင်ပြေသွားမှာဖြစ်ပြီးတော့ underlying 3rd party modules တွေဆီက cook တို့ bill တို့ functions တွေသိစရာမလိုတဲ့အပြင် class တွေကိုလည်း initiate လုပ်ပေးစရာမလိုတော့ပါဘူး။

Façade ကိုသုံးခြင်းအားဖြင့် client က complexity များတဲ့ library code တွေအစား façade ကိုသုံးနိုင်သွားမယ်။ library code တွေနဲ့ client code ကြား tight coupling ဖြစ်တာကို လျော့ချနိုင်မယ်။ ဒါပေမယ့် ကျနော့်အမြင်အရ façade မှာ methods တွေများသွားရင်လည်း Façade object ဖောင်းပွလာမှာစိုးရိမ်ရတယ်၊ အဲ့အချိန်ကျရင်တော့ Façade refine လုပ်ရတာတို့ responsibility တစ်မျိုးစီအတွက် façade ပြန်ခွဲတာတို့ လုပ်နိုင်ရင် ပိုကောင်းပါတယ်။


