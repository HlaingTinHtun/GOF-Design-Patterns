## Singleton Design Pattern

### Objective

Creational design အောက်ထဲက pattern တစ်ခုပဲဖြစ်ပါတယ်။ မှတ်ရလည်းလွယ်တယ်လို့ပြောရတယ်။ Class တစ်ခုမှာ Instance တစ်ခုပဲရှိရမယ်၊ ပြီးတော့ အဲ့ဒီ instance ကို globally access လုပ်ခွင့်ပေးနိုင်ရမယ်။ access လာလုပ်မယ်ဆိုရင်တော့ Lazy initialization(initialization on first use) နဲ့လုပ်ရင်ပိုကောင်းပါတယ်။

### Usage

ကျနော်တို့ application ထဲမှာ instance တစ်ခုတည်းကို global access လိုမျိုးသုံးဖို့လိုလာတာတို့၊ ဥပမာ database instance/ logging instance/ mailer instance စသည်ဖြင့် ဒီလိုမျိုးတွေသုံးဖို့လိုလာရင် singleton pattern ကိုသုံးပါတယ်။ ဆောက်လိုက်တဲ့ instance ကလည်း global access လုပ်နိုင်ရမယ်။ lazy initialization လည်းလုပ်နိုင်ရမယ်။

Implementation လုပ်ဖို့အတွက်ဆို instance ထဲမှာရှိတဲ့ attribute က private ဖြစ်ရမယ်။ function ကတော့ client code က access လုပ်မှာဖြစ်တဲ့အတွက် public ဖြစ်ရမယ်။ lazy initialization အတွက်လဲ ထည့်ပေးထားရမယ်။ constructors တွေက public ဖြစ်လို့မရဘူး၊ sub class တွေကို access ပေးလုပ်ချင်ရင် protected သုံး၊ ဒါမှမဟုတ် private သုံးရမယ်။  နောက်ဆုံးမှာ client code က public ဖြစ်တဲ့ function ကိုသာ access လုပ်လို့ရရမယ်။

ပိုပြီးမြင်သာအောင် sample code လေးတွေနဲ့ အတူတူကြည့်ကြည့်ရအောင်။

PHP code sample
```
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

```

LogSingleton ဆိုပြီး singleton class တစ်ခု ဆောက်လိုက်ပါတယ်။ အထဲမှာ attribute နဲ့ constructor ကို private ပေးထားတယ်၊ client class ကနေ initialize အလုပ်မခံချင်လို့ ၊ အကယ်လို့ ကိုယ်က subclass တွေကနေတစ်ဆင့် initialize လုပ်ခံချင်တယ်ဆိုရင်တော့ ဒီနေရာမှာ protected သုံးလည်းရတယ်။ နောက်တစ်ခုအနေနဲ့ public function တစ်ခုဆောက်လိုက်တယ်၊ အဲ့ထဲမှာ instance ကရှိပြီးသား လည်း အလွတ်လားဆိုတဲ့ condition စစ်ပြီးတော့ instance ကို return ပြန်တယ်၊ ဒါမှသာ singleton class က same object ကိုပဲ return ပြန်ပေးပါ။ ဒါက singleton ရဲ့ အဓိက အချက်ပဲ။ အောက်မှာ ကိုယ့် application က လိုအပ်တဲ့ business logic function တွေထပ်ထည့်လို့ရသေးတယ်။ public function တွေပေါ့။

အောက်က client code မှာ singleton class နဲ့အတူ သူ့ရဲ့ public static function ကိုပါလှမ်းခေါ်ထားတယ်။ $client variable ကိုတန်းထုတ်ကြည့်မယ်ဆို singleton class instance ကြီးပြန်ပေးလိုက်တယ်။ အဲ့ဒီ Instance ကလည်း ဘယ် client code ကနေခေါ်ခေါ် အတူတူပဲဖြစ်နေလိုက်မယ်။ log() function ထဲမှာ lazy initialization လုပ်ထားပြီး conditional statement လုပ်ထားခဲ့တာကြောင့်။ $client variable ကနေတစ်ဆင့်လည်း singleton ထဲမှာ ရှိတဲ့ public function တွေကို ထပ်ပြီးတော့ access လုပ်လို့ရမယ်။

C# code sample

C# မှာတော့ အပေါ်က PHP မှာရေးခဲ့သလိုပဲ implement လုပ်လို့ရပေမယ့် multi-threaded ဖြစ်လာခဲ့မယ်ဆို thread safe မဖြစ်ဘူးလို့ mention လုပ်ထားကြတယ်ဗျ။ ဒါကြောင့် C# မှာ thread-safe ဖြစ်အောင် implement လုပ်ပေးဖို့လိုလာမယ်။

ပုံမှန်ဆို C# မှာဒီလို implement လုပ်မယ်ဆို thread safe မဖြစ်ဘူး။
```
if (instance==null)
{
  instance = new LogSingleton();
}
return instance;
```
thread safe ဖြစ်အောင် လုပ်ဖို့ဆို lock function ကိုသုံးပြီး စစ်လို့ရမယ်။ ပြီးတော့ .net မှာပါတဲ့ Lazy type ကိုလည်း သုံးလို့ရမယ်လို့ Documentation တွေမှာ mention ထားပါတယ်။ ကျနော်ကတော့ လွယ်တဲ့ lock function လေးကိုသုံးပြီး နမူနာရေးပြပါမယ်။
```
using System;

namespace HelloWorld
{
    class LogSingleton
    {
        /**
         * I kept this attributes as private so that other sub class can't instantiate
         * it can also be protected if you want to allow sub classes to be instantiated
         */
        private static LogSingleton instance;

        /**
         * for the first use for this class, s_lock will have a object.
         * This will later use along with lock function to protect from multi thread base.
         */
        private static readonly object s_lock = new object();

        public static LogSingleton log()
        {
            if (instance == null)
            {
                /**
                 * The client who has s_lock will proceed this condition.
                 */
                lock (s_lock)
                {
                    /**
                     * I will assign the singleton instance if instance is null.
                     * otherwise will return directly.
                     */
                    if (instance == null)
                    {
                        instance = new LogSingleton();
                    }
                }
            }
            return instance;
        }

        //can also declare other public functions below.
        public string debugLog()
        {
            return "debug log";
        }

        //client code
        class Program
        {
            static void Main(string[] args)
            {
                var client = LogSingleton.log(); // this is the singleton instance.
                Console.WriteLine(client.debugLog());

            }
        }
    }

}

```
lock function ကိုသုံးပြီး multi-threaded ကို prevent လုပ်တာက လွဲလို့ ကျန်တာတွေက အပေါ်က ရေးထားတဲ့ PHP နဲ့ သဘောတရားခြင်း အတူတူပါပဲ၊


### Pros & Cons

Singleton သုံးမယ်ဆို singly instance တစ်ခုရတယ်၊ ဆိုလိုချင်တာ အဲ့ဒီ instance က vary မဖြစ်ဘူး။ နောက်တစ်ခု global access point ရမယ်။

မကောင်တဲ့ အချက်က singleton class ကိုလှမ်းသုံးနေသမျှ client code က loosely coupling မဖြစ်ဘူး၊ singleton ကို depend လုပ်နေရမယ်။ နောက်ပိုင်း test case တွေ implement လုပ်မယ်ဆို အခက်အခဲရှိနိုင်တယ်။
