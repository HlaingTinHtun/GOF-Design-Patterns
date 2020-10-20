## Decorator Design Pattern

### Objective

Object တစ်ခုဆီကို behaviors နဲ့ responsibilities အသစ်တွေကို dynamically ထည့်ချင်တဲ့အချိန်မှာ အသစ်ထည့်ရမယ့် responsibilities တွေကို wrapper class တစ်ခုလိုဆောက်ပြီး original object ဆီကိုလှမ်းထည့်ပါတယ်။ Structural design pattern category ထဲကတစ်ခုဖြစ်ပါတယ်။

အောက်က usage & implementation တွေဆက်ဖတ်ပြီးမှ objective ကိုတစ်ခေါက်ပြန်ဖတ်ပါမယ်။

### Usage Implementation

Real world example နဲ့အရင်မြင်အောင် ကြည့်ကြတာပေါ့။ ဆိုပါစို့ ကျနော်တို့မှာ အိမ်တစ်လုံးရှိတယ်။ class တစ်ခုလို့သဘောထားလိုက်မယ်။ အိမ်ထဲမှာလည်း သက်ဆိုင်တဲ့ methods တွေ fields တွေရှိမယ်။ ဥပမာ setup ဆိုတဲ့ method လိုမျိုးပေါ့။ setup ထဲမှာ အိမ်နဲ့သက်ဆိုင်တဲ့ living room, dining room စတာတွေကို build လုပ်ထားတဲ့ code တွေပါတယ်ပေါ့။ ဒါတော့ဟုတ်ပါပြီ၊ ကျနော်တို့က အိမ်ကို ထပ်ပြီးမွမ်းမံပြီး ထည့်ချင်တာတွေရှိသေးတယ်ဆိုရင်ရော၊ ဥပမာ ရေကူးကန်ထည့်ချင်တယ်၊ mini cinema လေးထည့်ချင်တယ် စသည်ဖြင့်ပေါ့။ ဒါဆိုရင် ကျနော်တို့ sub class တွေဆောက်ရတော့မယ်၊ မူလ home class ကို extend လုပ်ပြီးတော့ပေါ၊ ပြီးရင် လိုချင်တဲ့ methods တွေကို sub class တွေထဲမှာ ရေးမယ်။ ဒါဆိုရင် client က ကျနော်တို့ code ကိုလှမ်းသုံးမယ်ဆိုရင် လိုချင်တဲ့ features တွေအလိုက် sub class တွေကိုတစ်ခုခြင်းဆီ လိုက်ပြီး instantiate လုပ်ဖို့လိုအပ်ပါတယ်။ ဆိုလိုချင်တာက တစ်ပြိုင်နက်တည်းမှာ တစ်ကြိမ်တည်းနဲ့ မပြီးသွားဘူးပေါ့၊ အကုန်လုံးကို လိုက်ပြီး instantiate လုပ်ဖို့လိုအပ်နေတာဖြစ်တဲ့အတွက်ကြောင့်ပေါ့။

ဆိုတော့ တစ်ကြိမ်တည်းနဲ့ အကုန်ပြီးအောင် မလုပ်နိုင်ဘူးလားဆိုတော့ လုပ်နိုင်တယ်။ ကျနော်တို့ sub class တွေထဲမှာ တစ်ခြားသော sub class တွေရဲ့ features methods တွေလာဝင်ရေးလို့ရတယ်။ ဥပမာ ရေကူးကန် sub class ထဲမှာ mini cinema အတွက်ပါ တစ်ခါတည်း လာဝင်ရေးထားမယ်ပေါ့။ တစ်ခြားသော sub class တွေမှာလည်း ထိုနည်းလည်းကောင်းပဲ အကုန်လုံးကိုဝင်ပြီး ပေါင်းရေးထားမယ်ဆိုပါစို့၊ ဒါဆိုရင် client ကလှမ်းခေါ်တဲ့နေရာမှာတော့ sub class တစ်ခါခေါ်တာနဲ့ အဆင်ပြေသွားပေမယ့် behind the scene မှာ ကျနော်တို့ရဲ့ sub class code တွေက မလိုအပ်ဘဲ ဖောင်းပွနေတာကို သတိထားမိပါလိုက်မယ်။ ပြီးတော့ class တစ်ခုက responsibility တစ်ခုထက်မကဘဲ loading လုပ်နေရပါလိမ့်မယ်။

ဒီနေရာမှာ decorator ဆိုတာကို သုံးပါတယ်။ ပုံမှန်ဆို sub class ကတွေက မူလ class ဆီကနေ extend လုပ်ထားတဲ့အတွက် inheritance လုပ်ထားတဲ့ သဘောဖြစ်ပါတယ်။ decorator မှာကတော့ inheritance မလုပ်ဘဲ object composition လုပ်တဲ့ပုံစံနဲ့သွားပါတယ်။ composition အကြောင်း အရှေ့က pattern တွေမှာ ကျနော်တို့ ပြောခဲ့ကြတဲ့အတွက် နားလည်မယ်လို့ထင်ပါတယ်၊ အလွယ်ပြောရရင် object reference လုပ်တယ်ပေါ့ဗျာ။ ဘာလို့ inheritance မသုံးရလဲဆိုတော့ သူက static ဖြစ်တဲ့အတွက်ကြောင့် run time မှာ object တွေရဲ့ behaviors တွေကို dynamically ပြောင်းလဲလိုက်လို့မရပါဘူး၊ လုပ်ချင်ရင် object တစ်ခုလုံး swap လုပ်တာမျိုးပဲရမယ်၊ နောက်အရေးကြီးဆုံးတစ်ချက်က များသောအားဖြင့် sub class တွေကို inheritance လုပ်တဲ့အချိန်မှာ class တစ်ခုကိုပဲ extends လုပ်လို့ရပါတယ်၊ တစ်ခုထပ်ပိုပြီး extends လုပ်လို့မရပါဘူး။ decorator မှာတော့ composition လုပ်ပြီး reference ယူထားတဲ့အတွက် လိုသလောက် object တွေထပ်ဖြည့်ပြီး reference လုပ်လို့ရမှာပါ၊ မြင်သာသွားအောင် ပြောရရင် နောက်ဆုံးရလဒ်အနေနဲ့ မူလ class နဲ့ decorator class တွေဟာ one to many ပုံစံလိုဖြစ်သွားမှာပါ။ decorator ရဲ့ main theme က wrapping လုပ်တဲ့ပုံစံပါပဲ၊ အုပ်လိုက်တဲ့သဘောပေါ့၊ ကျနော်တို့ အပေါ်မှာပေးခဲ့တဲ့ ဥပမာအရဆို နောက်ထပ်ထည့်မယ့် ရေကူးကန် class က home class ကိုအုပ်လိုက်မယ်။ mini cinema ကနောက်တစ်ထပ် ထပ်အုပ်မယ်၊ reference လုပ်တဲ့အရာကို wrapping လုပ်တဲ့ပုံစံနဲ့သွားပါတယ်။ ဒါက decorator အလုပ်လုပ်တဲ့ပုံစံပါပဲ။ ဆိုတော့ အောက်က code examples လေးတွေဆက်ကြည့်ရင် ပိုပြီးနားလည်သွားမှာပါ။

## PHP
```
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
```

## C#

```
using System;

namespace HelloWorld
{

    /**
     * The interface that must be implemented by concrete class or decorator class
     * Many methods might exist in a real world application.
     */
    abstract class Home
    {
        public abstract string setup();
    }

    /**
     * An example simple concrete class implementing the interface through the setup method.
     */
    class ModernHome : Home
    {
        public override string setup()
        {
            return "ModernHome";
        }
    }

    /**
     * Here is the base decorator class referncing the home interface.
     * Implementations don't exist here as this is the scheme of the concrete classes that will extend to it.
     * we have a condition here to do the wrapping process.
     */
    abstract class Decorator : Home
    {
        protected Home _Home;

        public Decorator(Home Home)
        {
            this._Home = Home;
        }


        public override string setup()
        {
            if (this._Home != null)
            {
                return this._Home.setup();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /**
     * Concrete decorator classes extending the  basedecorator(wrapping the original ModernHome Instance).
     */
    class CinemaDecorator : Decorator
    {
        public CinemaDecorator(Home comp) : base(comp){}

        
        public override string setup()
        {
            return $"CinemaDecorator({base.setup()})";
        }
    }

    class PoolDecorator : Decorator
    {
        public PoolDecorator(Home comp) : base(comp){}

        public override string setup()
        {
            return $"PoolDecorator({base.setup()})";
        }
    }


    /**
     * Clients just have to pass the modernhome instance to each decorator class that they want.
     * We can see here it is wrapping step by step. ModenHome is wrapped by cinema. Afterwards, cinema is wrapped by pool.
     * PoolDecorator(CinemaDecorator(ModernHome))
     */
    class Program
    {
        static void Main(string[] args)
        {

            var moden = new ModernHome();
            CinemaDecorator cinema = new CinemaDecorator(moden);
            PoolDecorator pool = new PoolDecorator(cinema);
            Console.WriteLine(pool.setup());
            
        }
    }

}

```


ရေးထားတဲ့ code တွေကို PHP ရော C#ရောကို ကျနော်အပေါ်မှာပြောထားတဲ့အတိုင်းပဲ ရေးထားတယ်၊ Interface တစ်ခုရှိမယ်၊ ပြီးတော့ သူ့ကို implement လုပ်ထားတဲ့ normal concreate class တစ်ခုရှိမယ်။ ပြီးတော့မှ base decorator class ဆောက်ပြီးအဲ့ထဲမှာ interface class ကို reference လုပ်တယ်။ base decorator concrete class တွေထပ်ဆောက်ပြီးတော့ လိုချင်တဲ့ features တွေထည့်တယ်၊ ဒါပါပဲ။ C#မှာတော့ ရေးထားတဲ့ပုံစံလေးအနည်းငယ်ကွဲပေမယ့် သဘောတရားကတော့ အတူတူပါပဲ၊ wrapping ပဲ။
 
Decorator ကိုသုံးနိုင်တဲ့အတွက် runtime မှာ object တွေရဲ့ behaviours တွေကို dynamically ပြောင်းနိုင်သွားမယ်၊ sub class တွေထုတ်စရာမလိုတော့ဘူး၊ ထပ်ထည့်ချင်တဲ့ features တွေရှိရင်လည်း decorator ရဲ့ ထုံးစံအတိုင်း reference လုပ် wrap လုပ်ပြီးဆက်ထည့်သွားလို့ရမယ်။ 

ဒါပေမယ့် wrap ထားတဲ့နေရာမှာ ဘယ်အဆင့်ဘယ်အဆင့်ဆိုတာကို မှတ်မထားတဲ့အတွက် ဘယ် decorator class ကိုတော့ ပြန်ထုတ်မယ်ဆိုပြီး ထုတ်ချင်တဲ့အချိန်မှာ တိုင်ပတ်နိုင်တယ်။ နောက်ပြီးတော့ wrap လုပ်တဲ့ decorator class တွေများလာတဲ့အချိန်မှာ wrap လုပ်ခဲ့တဲ့ order တွေ၊ index တွေမှတ်မထားတဲ့အတွက် ထုတ်ရဖျက်ရခက်တဲ့ issue အပြင်တစ်ခြားသော issues တွေလည်းရှိနိုင်တယ်လို့ယူဆရပါတယ်။
