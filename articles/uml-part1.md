## UML (Unified Modeling Language) – Part 1

 ![Image of UML Part1](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-part1.png)

အစတုန်းကတော့ UML အကြောင်းရေးဖို့ အစီအစဉ်မရှိဘူး၊ ဒါပေမယ့် တစ်ခုစဉ်းစားမိသွားတာက design pattern ပဲ learning လုပ်ချင်တာပဲဖြစ်ဖြစ် တစ်ခြားနေရာတော်တော်များများမှရော UML က အသုံးဝင်တဲ့အရာတစ်ခုဖြစ်လို့ သေသေချာချာ နားလည်ထားရင် အကျိုးရှိမယ်လို့ထင်လို့ ရေးဖြစ်သွားတာပါ၊ UML က perspective scope အမျိုးမျိုးအတွက်ရှိပေမယ့် ဒီ ဆောင်းပါးမှာ Design Pattern တည်ဆောက်တဲ့ UML scope ကိုပဲ focus လုပ်ပြီးရေးသွားပါမယ်။ ကျနော် ဖတ်ထားခဲ့တဲ့ Willian Sanders ရေးထားတဲ့ PHP Design Patterns စာအုပ်ထဲက Chapter 4 Using UMLs with design patterns အခန်းကို Reference လုပ်ပြီးရေးသွားမှာပဲဖြစ်ပါတယ်။  အပိုင်း ၄ ပိုင်းလောက်ခွဲပြီးရေးသွားပါမယ်။ အခု part 1 မှာတော့ class diagram အေကြာင်းကို Intro ဝင်သွားမယ်။ part 2, 3 မှာ relationship notations တွေအကြောင်းပြောမယ်၊ နောက်အပိုင်းတွေမှာ Object diagram အကြောင်းပြောမယ်။

ကျနော် Factory Design Pattern အတွက် sample UML လေးတစ်ခုဆောက်ထားတယ်၊ ကြည့်ရအောင်၊ (Factory Design Pattern သိစရာမလိုသေးဘူး၊ ဒီ article က UML ဘယ်လိုအသုံးဝင်လဲဆိုတာပဲမြင်စေချင်တာ)

 ![Image of UML Factory](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-factory-pattern.png)

အခုသုံးထားတဲ့ notations တွေက commonly သုံးဖြစ်ကြတဲ့ notation တွေပဲ၊ system နဲ့ software ပေါ်မူတည်ပြီး style လေးနည်းနည်းလေးပြောင်းတာတော့ရှိနိုင်တယ်။ (notation ဆိုတာပုံစံ symbols လေးတွေကိုဆိုလိုတာ , ဒီမှာဆို triangle line တို့ dotted line တို့ etc.)

ဒီထဲမှာ ကျနော်တို့မသိတဲ့ပုံစံ notation တွေမပါဘူး ၊ Bold & Italic လေးတွေက Interface တွေ, bold ချည်းပဲက concrete class တွေ, triangle က interface or abstract class ကို extend လုပ်ထားတာ, SampleInterface abstract class မှာရှိတဲ့ factory method ကို extend လုပ်ထားတဲ့ sample concrete က implement လုပ်ပေးထားတယ်၊ လုပ်ထားတဲ့နေရာမှာ concreteitem ကိုပါ object instantiation တစ်ပါတည်းလုပ်ထားတယ်။ concreteitem ဆိုတာကလည်း Item ဆိုတဲ့ interface ကို extend လုပ်ထားတယ်။ ဒီတိုင်းပုံကြီးကြည့် စာလိုက်ဖတ်နေရင် ရှုပ်နေဦးမယ်၊ code sample လေးကြည့်ရအောင်၊ အောက်မှာ PHP နဲ့ ရေးပေးထားပါတယ်။

```
<?php

abstract class SampleInterface
{
    /**
     * abstract တစ်ခုရှိမယ်
     */
    abstract public function factoryMethod();

    /**
     * concrete တစ်ခုရှိမယ်
     */
    public function concreteOperation()
    {
        /**
         * factory method ကိုလှမ်းခေါ်ပြီးသုံးထားတယ်။
         */
        $item = $this->factoryMethod();
        $result = $item->doSmth();
        return $result;
    }
}

/**
 * sample concrete က sampleinterface ကို extend လုပ်မယ်(traingle shape)၊ abstract method
 * ဖြစ်တဲ့ factory method ကို implement လုပ်မယ်။
 */
class SampleConcrete extends SampleInterface
{
    public function factoryMethod()
    {
        /**
         * concrete Item ဆိုတဲ့အရာကိုပါတစ်ပါတည်း instantiate လုပ်လိုက်တယ်။ (dotted line)
         */
        return new ConcreteItem;
    }
}


/**
 * Item Iterface
 */
interface Item
{
    public function doSmth();
}

/**
 * concreteItem ဆိုတဲ့ကောင်ကလည်း Item class ကို extends လုပ်ထားပြီး doSmth ကို implement လုပ်ထားတယ်။
 */
class ConcreteItem implements Item
{
    public function doSmth()
    {
        return "I am doing something";
    }
}


/**
 * client ဆိုတဲ့ function ထဲမှာ SampleInterface ကို inject လုပ်ထားမယ်။
 */
function client(SampleInterface $sample)
{
    echo $sample->concreteOperation();
}


/**
 * ပြီးရင် client ဆိုတဲ့ကောင်က sampleconcrete class instantiate လုပ်ပြီး
 * SampleInterface ကို object reference လုပ်သွားတယ်။
 * acquaintance relation လို့လည်းပြောလို့ရတယ်။
 */
client(new SampleConcrete);
```

Factory method ကို code ချည်းပဲထိုင်ကြည့်နေမယ်ဆို နားလည်ရခက်နေဦးမယ်။
ပုံနဲ့ code နဲ့တွဲကြည့်လိုက်မယ်ဆို ကွက်ကွက်ကွင်းကွင်းမြင်သွားလိမ့်မယ်၊ (Again. I am not saying about factory design pattern though. Factory Pattern က နောက်မှ သက်သက်ထပ်ရေးမှာ) နားလည်ရလွယ်အောင် code comment တွေလည်းရေးပေးထားတယ်။ ဒါဆိုလို့ရှိရင် UML က design pattern တွေကို ဖော်ပြရတဲ့နေရာမှာ ဘာလို့အသုံးဝင်လည်းဆိုတာ သဘောပေါက်လောက်ပြီးထင်ပါတယ်။ ဖတ်ပြီးပြီးချင်း သဘောပေါက်ချင်မှလည်း ပေါက်မှာပေါ့၊ သေချာလေးပြန်ဖတ်ကြည့်ပေါ့ မရှင်းရင်လဲ။

နောက် article မှာ notation တွေကိုအဓိကထားပြီးပြောသွားမယ်။ ဒီမှာဆို acquaintance လုပ်သွားတာတို့ instantiate လုပ်တယ်ဆို dotted line သုံးသွားတာတို့ စသည်ဖြင့် notation တွေပါတယ်၊ နောက်ထပ် notation တွေလည်း ရှိသေးတယ်။ ဆိုတော့ နောက် article မှာထပ်ရေးပေးသွားပါမယ်။

ဒါနဲ့ UML ဆွဲတော့မယ်ဆို tools တွေအများကြီးရှိတယ်၊ ကိုယ်နှစ်သက်ရာသုံးနိုင်တယ်၊ ကျနော်ကတော့ draw.io သုံးပြီးဆွဲထားပါတယ်။

See Ya.
