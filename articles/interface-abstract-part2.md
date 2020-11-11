## Interface & Abstract Class (Part 2)

![Image of I&A1](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/interface-abstract-part2.png)

Part 2 မှာတော့ abstract class အကြောင်းကို အဓိကထားပြီး PHP code examples တွေနဲ့ ပြောသွားမှာပဲဖြစ်ပါတယ်။

Part 2 ကိုမဖတ်ခင် part1 interface အကြောင်းကိုဖတ်ထားရင်ပိုကောင်းပါတယ်။ part 1 link အောက်မှာပါ။
https://bit.ly/2yT8W5f

Interface နဲ့ မတူတာက abstract မှာ concrete method တွေပါရေးလို့ရတယ်။ class ထဲမှာ define လုပ်ထားတဲ့ abstract method တွေကို child class တွေက မဖြစ်မနေ implement လုပ်ပေးရမယ်။ Abstract class ရဲ့ main purpose က child class တွေအတွက် template လေးလိုပုံစံပဲ၊ inherit လုပ်မယ်၊ abstract method တွေ implement လုပ်မယ်။ abstract class ကဘယ်လိုအသုံးဝင်လဲဆိုတာ အောက်က code example လေးတွေကြည့်ရအောင်။
```
<?php

class ChickenCurry
{
    public function addChicken()
    {
        var_dump('Add raw chicken');
        return $this;
    }
    protected  function  addSalt()
    {
        var_dump('Add some salt');
        return $this;
    }

    protected  function addPepper()
    {
        var_dump('Add some pepper');
        return $this;
    }

    public function cook()
    {
        return $this
            ->addChicken()
            ->addSalt()
            ->addPepper();
    }
}

$chickenCurry = new ChickenCurry();
$chickenCurry->cook();

```
chickenCurry ဆိုတဲ့ ကြက်သားဟင်းချက်တဲ့ class တစ်ခုရှိတယ်။

```
class PorkCurry
{
    public function addPork()
    {
        var_dump('Add raw pork');
        return $this;
    }
    protected  function  addSalt()
    {
        var_dump('Add some salt');
        return $this;
    }

    protected  function addPepper()
    {
        var_dump('Add some pepper');
        return $this;
    }

    public function cook()
    {
        return $this
            ->addPork()
            ->addSalt()
            ->addPepper();
    }
}

$PorkCurry = new PorkCurry();
$PorkCurry->cook();
```
နောက်တစ်ခု ဝက်သားဟင်းချက်တဲ့ porkCurry ဆိုတဲ့ class တစ်ခုရှိတယ်။ class နှစ်ခုကိုကြည့်လိုက်မယ်ဆို addSalt ရယ် addPepper ရယ်ဆိုတဲ့ တူတဲ့ method 2 ခုကိုတွေ့ရမယ်၊ အဓိကပါဝင်ပစည်းဖြစ်တဲ့ addPork နဲ့ addChicken ပဲကွာသွားမယ်။ ဒီလိုနေရာမှာ abstract class ကိုသုံးပြီးတော့ addSalt & addPepper ကို implement လုပ်ထားမယ်၊ main ingredients ဖြစ်တဲ့ ကြက်နဲ့ဝက်ကို abstract method လုပ်ပြီးတော့ concrete class တွေကို implement လုပ်ခိုင်းမယ်။ ဒါဆိုရင် အောက်က လိုဖြစ်သွားမယ်။

```
abstract class Recipe
{
    protected  function  addSalt()
    {
        var_dump('Add some salt');
        return $this;
    }

    protected  function addPepper()
    {
        var_dump('Add some pepper');
        return $this;
    }

    public function cook()
    {
        return $this
            ->addMainIngredient ()
            ->addSalt()
            ->addPepper();
    }

    protected abstract function addMainIngredient();
}

```
ကျနော် Recipe ဆိုတဲ့ abstract class လေးတစ်ခုဆောက်လိုက်တယ်။ အဲ့ထဲမှာ reuse လုပ်လို့ရတဲ့ method ၃ခုကိုတစ်ခါတည်း implement လုပ်ထားတဲ့ reuse လုပ်လို့မရတဲ့ကောင်ကိုတော့ abstract method အဖြစ်ရေးထားတယ်။

ဒါဆိုရင် chickenCurry နဲ့ porkCurry class ကိုဆောက်တော့မယ်ဆို Recipe abstract class ကို extend လုပ်ပြီး ဆောက်ရုံပဲ။ extend လုပ်လိုက်ပြီဆို abstract class မှာရှိတဲ့ concrete method တွေကို access လုပ်ခွင့်ရှိမယ်။ abstract method ကိုလည်း ကိုယ်လိုချင်တဲ့ code တွေ implement လုပ်ပြီးရေးလိုက်ရုံပဲ။ အောက်ကလိုပေါ့။

```
class ChickenCurry extends Recipe
{
    public function addMainIngredient()
    {
      var_dump('Add raw chicken');
      return $this;
    }
}
$chickenCurry = new ChickenCurry();
$chickenCurry->cook();

class PorkCurry extends Recipe
{
    public function addMainIngredient()
    {
      var_dump('Add raw pork');
      return $this;
    }
}
$porkCurry = new PorkCurry();
$porkCurry->cook();
```
ဒါဆိုလို့ရှိရင် အပေါ်မှာပြထားတဲ့ sample လိုမျိုး result ကအတူတူပဲရတယ်။ ဒါဆိုရင် ဘယ်လိုအခြေအနေမျိုးမှာ abstract ကိုသုံးရမယ်ဆိုတာနားလည်မယ်လို့ထင်ပါတယ်။

ဒါဆိုရင် Interface ရော abstract class ရောသိသွားပြီဆိုတော့ အဓိကအားဖြင့်သူတို့နှစ်ခုဘာကွာသွားလဲဆိုရင်

-	Interface မှာ child class တွေက interface တစ်ခုထက်မက implement လုပ်လို့ရတယ်။ abstract မှာတော့ child က abstract class တစ်ခုပဲ extend လုပ်လို့ရမယ်။
-	ကျနော် implement နဲ့ extend ခွဲသုံးထားတယ်၊ interface အတွက်ဆို implement keyword သုံးတယ်၊ abstract class အတွက်ဆို extend keyword သုံးတယ်။
-	Interface မှာ data member တွေနဲ့ constructor တွေမပါဘူး၊ abstract class မှာတော့ data member ရော constructor ရောပါလို့ရတယ်။
-	Interface မှာ implementation မရှိတဲ့ abstract method တွေပဲပါခွင့်ရှိမယ်။ abstract class မှာတော့ abstract method ရော၊ concrete method ရောပါခွင့်ရှိမယ်။
-	Interface မှာ default အနေနဲ့ public ကလွဲလို့ ကျန်တဲ့ access modifiers တွေပါခွင့်မရှိဘူး abstract မှာတော့ methods တွေ properties တွေမှာ access modifiers တွေထည့်လို့ရတယ်။
-	Interface မှာ ပါတဲ့ member တွေက static type ဖြစ်မရ၊ abstract မှာတော့ concrete ဖြစ်ထားတဲ့ member တွေက static type ဖြစ်လို့ရတယ်။

စာလည်းရှည်ပြီ၊ interface နဲ့ abstract class ကိုလည်း ကွဲပြီလို့ထင်ပါတယ်။
