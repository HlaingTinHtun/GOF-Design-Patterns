## Builder Pattern

### Objective

Creational design pattern category အောက်ထဲကတစ်ခုပါပဲ။ အဓိကသူ့ရဲ့ ရည်ရွယ်ချက်က code portion တစ်ခုထဲကနေ မတူညီတဲ့ objects တွေ ထုတ်ပေးနိုင်အောင်ပါ၊ တစ်နည်းအားဖြင့်ဆိုရင် complex objects တွေကို return ပြန်ပေးနိုင်အောင်ပေါ့။ ဘယ်လိုမျိုး complex objects တွေလည်း အောက်မှာဆက်ကြည့်ရင် နားလည်သွားပါလိမ့်မယ်။

### Usage & Implementation

ဆိုပါစို့၊ မာလာရှမ်းကော တစ်ပွဲစားဖို့ မှာတယ်ဆို။ မာလာရှမ်းကော တစ်ပွဲပေးပါဆိုပြီး တန်းမှာလို့မရဘူး။ ဘာအရွက်တွေထည့်မယ်၊ ဘာအသားတွေထည့်မယ်ဆိုတာ ကိုယ်တိုင် customize လုပ်ရတယ်ဟုတ်။ မှာတဲ့အခေါက်တိုင်းမှာ မတူညီတဲ့ မာလာရှမ်းကောပွဲတွေထွက်လာလိုက်မယ်။ ဒါကို complex object လို့သတ်မှတ်နိုင်တယ်။ programming ရှုထောင့်ကနေ ရှင်းသွားအောင် ပြန်ပြောရရင် Mala ဆိုတဲ့ object ထဲမှာ parameters တွေအများကြီးရှိနိုင်တယ်၊ သူနဲ့ သက်ဆိုင်တဲ့ object implementation တွေရောပေါ့။ ကျနော်တို့က Mala ဆိုတဲ့ object ကိုလှမ်းသုံးတော့မယ်ဆို ကျနော်တို့လိုချင်တဲ့ parameter (စားချင်တဲ့ အမယ်တွေ) တွေ Pass လုပ်ပေးရမယ်။

ဒီအချိန်မှာ param တွေထဲမှာပါတာကလဲ ပါမယ်၊ မပါတာကလဲမပါဘူး။ ဒါကြောင့် နောက်ဆက်တွဲအနေနဲ့ Mala Object ထဲမှာ param အမျိုးမျိုး ကို control လုပ်ရမယ့် code တွေရေးရမယ်။ conditional statement တွေအများကြီးပါလာမယ့် အပြင် code ကလည်း တော်တော်လေး nasty ဖြစ်လာနိုင်ပါတယ်။ Pass လုပ်ပေးလိုက်တဲ့ param တွေအရ အသုံးဝင်မယ့် အရာတွေရှိနိုင်သလို မလိုတဲ့ code တွေဖောင်းပွလာတာမျိုးတွေလိုဖြစ်နိုင်တယ်။ ဒီလိုမျိုး အခြေအနေမှာ builder pattern ကိုသုံးပြီး ထိန်းချုပ်နိုင်ပါတယ်။ ဘယ်လိုထိန်းချုပ်မလဲ ဆက်ကြည့်ရအောင်။

ခုနက အပေါ်မှာပြောခဲ့တဲ့ ရှုပ်ထွေးနိုင်တဲ့ object implementation code တွေကို သက်သက်ခွဲထုတ်နိုင်ပါတယ်။ ခွဲထုတ်လိုက်တဲ့ objects တွေကို builder လို့ခေါ်တာပေါ့။ ဥပမာ
-	addPotato()
-	addBeef()
-	addMushRoom()
-	add Noodle()
စသည်ဖြင့်ပေါ့။

အဲ့လို သီးသန့် builder တွေအနေနဲ့ ခွဲထုတ်လိုက်ခြင်းအားဖြင့် client က Mala Object Implement လုပ်တော့မယ်ဆို အရင်ကလို param pass လုပ်တဲ့နေရာမှာ ugly မဖြစ်အောင် builder ကနေလိုအပ်တဲ့အရာလေးတွေကိုပဲလှမ်းခေါ်သုံးရုံပဲ၊ အကုန်ခေါ်သုံးစရာလည်းမလိုအပ်တော့ဘူး။

Builder Pattern အကြောင်းပြောမယ်ဆို တစ်ဆက်တည်း Director ရဲ့ အကြောင်းပါပြောမှပိုပြည့်စုံမယ်ထင်တယ်။ Director ဆိုတာက အထူးအဆန်းတော့ မဟုတ်ဘူး။ ခုနကခွဲချထားတဲ့ builder pattern လိုမျိုးနောက်တစ်ခုပဲ။ အဓိက သူ့ရဲ့ ရည်ရွယ်ချက်က Builder ထဲမှာရှိတဲ့ method steps တွေကို ordering လုပ်ဖို့။ ဆိုတော့ Director က builder steps တွေကို ordering လုပ်မယ်။ တစ်ကယ့် implementation တွေကတော့ builder object ထဲမှာပဲရှိမယ်၊ ဒီလိုပုံစံဖြစ်သွားလိမ့်မယ်။ Director က builder pattern မှာ မရှိမဖြစ်တော့လည်း မဟုတ်ဘူး။ Client code က builder object နဲ့ directly communicate လုပ်လို့ရမယ်။ Director ရှိတော့ကျတော့ client code ကနေ code reuse ပြန်လုပ်လို့ရတာပေါ့။

Theory ပိုင်းရှင်းပြီးပြီဆိုတော့ code sample လေးတွေကြည့်ရအောင်။

### PHP
```
<?php

/**
 * Builder interface with different methods.
 */
interface Builder
{
    public function addVege();

    public function addNoodle();

    public function addMeat();
}

/**
 * Implementing the builder and interface with different implementations
 */
class MalaBuilder implements Builder
{
    private $product;

    /**
     * To rest the Mala Object as a new one.
     */
    public function __construct()
    {
        $this->product = new Mala;
    }

    /**
     * All production steps work with the same product instance.
     */
    public function addVege()
    {
        $this->product->ingredients[] = "Vegetable";
    }

    public function addNoodle()
    {
        $this->product->ingredients[] = "Noodle";
    }

    public function addMeat()
    {
        $this->product->ingredients[] = "Meat";
    }

    /**
     * returning results for each different implementatins.
     */
    public function add()
    {
        $result = $this->product;

         /**
         * To rest the Mala Object as a new one.
         */
        $this->product = new Mala;

        return $result;
    }
}

/**
 * display the final results of Malabuilder
 */
class Mala
{
    public $ingredients = [];

    public function returnMala()
    {
        echo implode(', ', $this->ingredients) . "<br>";
    }
}

/**
 * I added a sample MalaDirector to create a few ready made implementations.
 */
class MalaDirector
{
    private $builder;

    public function setBuilder(Builder $builder)
    {
        $this->builder = $builder;
    }

    public function addVegeNoodle()
    {
        $this->builder->addVege();
        $this->builder->addNoodle();
    }

    public function addVegeMeatNoodle()
    {
        $this->builder->addVege();
        $this->builder->addNoodle();
        $this->builder->addMeat();
    }
}


function clientCode(MalaDirector $malaDirector)
{
    $builder = new MalaBuilder;
    $malaDirector->setBuilder($builder);

    echo "This is vege Mala:\n";
    $malaDirector->addVegeNoodle();
    $builder->add()->returnMala();

    echo "Full Ingredients Mala:\n";
    $malaDirector->addVegeMeatNoodle();
    $builder->add()->returnMala();

    // This time with no MalaDirector usage.
    echo "Custom Mala:\n";
    $builder->addNoodle();
    $builder->addMeat();
    $builder->add()->returnMala();
}

$malaDirector = new MalaDirector;
clientCode($malaDirector);
```

### C#

```
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * Builder interface with different methods.
     */
    public interface Builder
    {
        void addVege();

        void addNoodle();

        void addMeat();
    }

    /**
     * Implementing the builder and interface with different implementations
     */
    public class MalaBuilder : Builder
    {
        private Mala _mala = new Mala();

        /**
         * To rest the Mala Object as a new one.
         */
        public MalaBuilder()
        {
            this._mala = new Mala();
        }

        public void addVege()
        {
            this._mala.Add("vegetable");
        }

        public void addNoodle()
        {
            this._mala.Add("noodle");
        }

        public void addMeat()
        {
            this._mala.Add("meat");
        }

        /**
         * returning results for each different implementatins.
         */
        public Mala FinalMala()
        {
            Mala result = this._mala;

            this._mala = new Mala();

            return result;
        }
    }

    /**
     * add function to the list object of ingredients.
     * return the final results of Malabuilder.
     */
    public class Mala
    {
        private List<object> incredigents = new List<object>();

        public void Add(string part)
        {
            this.incredigents.Add(part);
        }

        public string ReturnMala()
        {
            string str = string.Empty;

            for (int i = 0; i < this.incredigents.Count; i++)
            {
                str += this.incredigents[i] + ", ";
            }

            str = str.Remove(str.Length - 2); //removing last comma and space.

            return + str + "\n";
        }
    }

    /**
     * A sample MalaDirector to create a few ready made implementations.
     */
    public class Director
    {
        private Builder _builder;

        public Builder Builder
        {
            set { _builder = value; }
        }

        public void addVegeNoodle()
        {
            this._builder.addVege();
        }

        public void addVegeMeatNoodle()
        {
            this._builder.addVege();
            this._builder.addNoodle();
            this._builder.addMeat();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new MalaBuilder();
            director.Builder = builder;

            Console.WriteLine("Vegetable Mala:");
            director.addVegeNoodle();
            Console.WriteLine(builder.FinalMala().ReturnMala());

            Console.WriteLine("Full Ingredients Mala:");
            director.addVegeMeatNoodle();
            Console.WriteLine(builder.FinalMala().ReturnMala());

            // This time with no MalaDirector usage.
            Console.WriteLine("Custom Mala:");
            builder.addNoodle();
            builder.addMeat();
            Console.Write(builder.FinalMala().ReturnMala());
        }
    }

}

```


code တွေထဲမှာလည်း ကျနော် comment တွေရေးပေးထားပါတယ်။ ပထမဦးဆုံး builder Interface တစ်ခုဆောက်တယ်။ ပြီးတော့ အဲ့ဒီ interface ကို implementation လုပ်တယ်၊ အထဲမှာ final object ကို return ပြန်တဲ့ code နဲ့အတူ တစ်ခြားလိုအပ်တဲ့ object implementation တွေပါရှိမယ်။ Director class ထည့်ပြထားတယ်၊ ready made implementation တွေနဲ့၊ မထည့်လဲရပါတယ်။ နောက်ဆုံး client ကနေပြီးတော့ director ကိုသုံးပြီးတော့ရော ၊ မသုံးဘဲနဲ့ builder နဲ့တိုက်ရိုက်ချိတ်ဆက်ပြီးတော့ ရော ခေါ်သုံးနိုင်ပါတယ်။ တစ်ခုသတိထားရမှာက director class မှာ implementation detail တွေပါလို့မရဘူး။ သူက ရည်ရွယ်ချက်က builder steps တွေကို ordering လုပ်ဖို့ပါပဲ။

Builder သုံးခြင်းအားဖြင့် code တစ်ခုတည်းနဲ့ implementation ကိုကြိုက်သလို စီမံလို့ရတယ်။(လိုတာပဲခေါ်သုံးလို့ရ)။ Director သုံးထားမယ်ဆိုရင် code ကို reuse ပြန်လုပ်လို့ရမယ်။

Builder class တွေထပ်ခွဲချရမယ့် အခြေအနေရောက်လာရင်တော့ code block ပိုထွက်လာမယ့်အတွက် complexity များနိုင်၊ ဥပမာ addNoodle() မှာ ရိုးရိုးခေါက်ဆွဲလား၊ အလုံးလား၊ အပြားလား ဒါမျိုးတွေထပ်ရှိလာနိုင်တယ်ဆိုရင် Noodle အတွက်သက်သက် builder ထပ်ခွဲဖို့လိုလာတာမျိုးပေါ့။




