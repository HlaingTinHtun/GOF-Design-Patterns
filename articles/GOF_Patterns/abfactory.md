## Abstract Factory Method Design Pattern

### Objective

Factory Design Pattern နဲ့ဆင်တယ်၊ creational design pattern category အောက်ကပါပဲ။ မတူတဲ့အချက်က abstract factory က single object မဟုတ်တော့ဘဲ family of objects ဖြစ်သွားမယ်။ သူတို့ရဲ့ concrete classes တွေကိုသိစရာမလိုဘဲ family of objects တွေနဲ့ အလုပ်လုပ်နိုင်မယ်။

### ဘယ်လိုနေရာမှာအသုံးဝင်နိုင်လဲ။ (Usage)

ဥပမာ electronic products တွေရောင်းတဲ့ company တွေနဲ့ ဆက်စပ်ကြည့်ရအောင်၊ Panasonic ရှိမယ်၊ Samsaung ရှိမယ်ဆိုပါစို့။ ဒါက company တွေ၊ သူတို့ကို factory အဖြစ်သတ်မှတ်လို့ရတယ်။ သူတို့အောက်မှာ washing machine, aircon, tv အစရှိသဖြင့် products တွေအများကြီးရှိနိုင်တယ်။ ဒါတွေကို family of objects အဖြစ်သတ်မှတ်နိုင်တယ်။ ပြသနာရှိတာက customer တစ်ယောက်က မနေ့က Samsaung tv တစ်လုံးဝယ်သွားတယ်ဆိုပါစို့ ၊ သူက TV remote ပျောက်သွားလို့ ထပ်ဝယ်ချင်တယ်ဆိုပါစို့၊ ဒီနေရာ panasonic က tv remote ကြီးသွားပေးလို့မရဘူး၊ သက်ဆိုင်ရာ family ထဲက object ကိုပဲ return ပြန်ပေးရမယ်။ ဒါကတစ်ခု နောက်တစ်ခုက အခုလက်ရှိ family of objects တွေ factory တွေက အမြဲပြောင်းလဲနေမှာ၊ ဒါကြောင့် code base ကိုတစ်ခုပြောင်းတိုင်း လိုက်ပြောင်းနေရမယ်ဆို အလုပ်ရှုပ်နိုင်တယ်။

ဒီလို problem scenario တွေမှာ abstract factory ကိုအသုံးပြုနိုင်ပါတယ်။ ဘယ်လို implementation လုပ်ပြီးဖြေရှင်းမလဲဆိုတာ code sample တွေမရေးပြခင် ဒီတိုင်းပြောကြည့်မယ်ဆို ဥပမာ TV set တစ်ခုဆိုပါစို့ ၊ ဒါကို Interface တစ်ခုအနေနဲ့ထပ်ထား၊ Tv set ထဲမှာ remote , cd player ထပ်ပါမယ်။ ဒါတွေကို သက်ဆိုင်ရာ electronic company ကနေတစ်ဆင့် implement ပြန်လုပ်၊ နောက်ထပ် တစ်ဆင့် TVset ထဲမှာက Tv ဆိုတဲ့ Interface ထုတ်၊ Tv မှာ display ပါမယ်။ sound ပါမယ်၊ စသည်ဖြင့် ပေါ့။ ဒါတွေကိုမှ ခုနကပြောထားတဲ့ companies တွေကနေ implement ထပ်လုပ်။ ဒီလိုပုံစံမျိုးနဲ့သွားတယ်။ ဘာကောင်းသွားလဲဆိုတော့ client code ကနေ TV တစ်လုံးပေးဆိုတာနဲ့ tv ရဲ့  factory specific implementation တွေသိစရာမလိုတော့ဘူး၊ နောက်ပြီး family မတူတဲ့ ကောင်တွေဆီကနေ data return ပြန်လာမှာမပူရတော့ဘူး။ နောက်တစ်ချက်က family of product တွေ manage လုပ်ရတဲ့ code base ကပိုလွယ်သွားမယ်။

Code sample တွေကအောက်က link တွေကနေဝင်ကြည့်နိုင်ပါတယ်။ လေ့လာနေတဲ့သူဆိုကြည့်ဖြစ်အောင်ကြည့်ပါ။ ဒါမှနားလည်မှာ။

PHP code sample
```
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

```

C# code sample
```
using System;

namespace HelloWorld
{
    /**
 * Define the Factory interface first.
 */
    abstract class TvSetFactory
    {
        public abstract Tv createTv();
        public abstract CdPlayer createCdPlayer();
    }

    /**
     * Then I will create related factory classes and implements the interface
     * Panasonic  Factory & SamsaungFactory in this scenario.
     */
    class PanasonicFactory : TvSetFactory
    {
        public override Tv createTv()
        {
            return new PanasonicTv();
        }

        public override CdPlayer createCdPlayer()
        {
            return new PanasonicCdPlayer();
        }
    }

    class SamsaungFactory : TvSetFactory
    {
        public override Tv createTv()
        {
            return new SamsaungTv();
        }

        public override CdPlayer createCdPlayer()
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
        public abstract string getTv();
    }

    /**
     * These classes have to be implemented by their relative factory.
     */
    class PanasonicTv : Tv
    {
        public override string getTv()
        {
            return "PanasonicTv";
        }
    }

    class SamsaungTv : Tv
    {
        public override string getTv()
        {
            return "SamsaungTv";
        }
    }

    abstract class CdPlayer
    {
        public abstract string getCdPlayer();
    }

    class PanasonicCdPlayer : CdPlayer
    {
        public override string getCdPlayer()
        {
            return "PanasonicCdPlayer";
        }
    }

    class SamsaungCdPlayer : CdPlayer
    {
        public override string getCdPlayer()
        {
            return "SamsaungCdPlayer";
        }
    }


    // client code
    /**
     * Now you can call the specific factory to return family of objects without knowing their own detail implementations.
     * if you want to get samsaung products, you just need to change the Factory class to samsaung factory.
     */

    class Program
    {
        static void Main(string[] args)
        {
            var tv = new PanasonicFactory();
            Console.WriteLine(tv.createTv().getTv());

            var cdPlayer = new PanasonicFactory();
            Console.WriteLine(cdPlayer.createCdPlayer().getCdPlayer());

        }
    }

}

```
ကောင်းတဲ့အချက်တွေကတော့ Factory pattern လိုပဲ။ coupling tight ဖြစ်တာကို လျော့ပေးနိုင်တယ်။ subclass တစ်ခုခြင်းဆီက ဘယ်သူ့အပေါ်မှ မှီခိုခြင်းမရှိဘဲ loosely coupling ဖြစ်တယ်။ နောက်တစ်ခုက extend လုပ်ရတာ၊ remove လုပ်ရတာလွယ်သွားတယ်။ နောက်ထပ် service ရှိလာရင်သော်လည်းကောင်း၊ ရှိပြီးသားကို ဖြုတ်ချင်ရင်သော်လည်းကောင်း တစ်ခြား ဘယ် code ကိုမှ ထိစရာမလိုဘဲနဲ့ လုပ်ဆောင်နိုင်တယ်။

မကောင်းတဲ့ အချက်ကတော့ class တွေပုံမှန်ထက်ပိုများလာတဲ့အတွက် code complexity တစ်ဖြည်းဖြည်းများလာနိုင်တယ်။

See you in next pattern.
