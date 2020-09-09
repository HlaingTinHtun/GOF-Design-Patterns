## Prototype Design Pattern

ရှိပြီးသား Object တွေကို prototype Interface တစ်ခုဆောက်ပြီး အဲ့ဒီ interface ကနေ clone ပြန်ပွားဖို့ပဲဖြစ်ပါတယ်။ အဓိက ကတော့ original objects ကိုတိုက်ရိုက်သွားပြီးတော့ instantiate လုပ်စရာမလိုတဲ့အတွက် coupling မဖြစ်တော့ဘူးပေါ့။

### Usage & Implementation

ဘာလို့ Prototype ကနေ ပြန် clone ပွားရလဲမေးစရာရှိတယ်။ ကျနော်အပေါ်မှာ ပြောခဲ့သလိုပဲ object တစ်ခုကို copy ကူးချင်ပြီးဆိုပါစို့၊ သူ့ class ကနေ instantiate လုပ်ရမယ်။ ဒါဆိုရင် ပထမဦးဆုံး အနေနဲ့ အဲ့ဒီ class အပေါ်မှာ depend ဖြစ်သွားတဲ့အတွက် tight coupling ဖြစ်သွားပါမယ်။ old object က fields တွေအများကြီးရှိတယ်ဆို copy လုပ်ရတဲ့နေရာမှာ heavy loading လဲဖြစ်နိုင်ပါတယ်။ depend ဖြစ်သွားပြီဆိုတာနဲ့ tight coupling အပြင် တစ်ခြားသော မလိုလားအပ်တဲ့ issue တွေထပ်ဖြစ်လာနိုင်ပါတယ်၊ original object အပေါ်မူတည်ပြီးတော့ပေါ့။ နောက်တစ်ချက်က အဲ့ဒီ object မှာရှိတဲ့ fields တွေအတိုင်းလိုက်ဖြည့်စရာလိုပါတယ်။ ဒီနေရာမှာ original object ကသာ သူ့ရဲ့ fields တစ်ချို့ ကို visibility scope hidden လုပ်ထားမယ်ဆိုရင် အဲ့ဒီကောင်တွေကို copy လုပ်လို့မရနိုင်တော့ပါဘူး။ ဒါက issue တစ်ခုပါပဲ။

ဒီလို issue တွေကို ပြေလည်စေဖို့အတွက် prototype pattern ကိုသုံးပါတယ်။ Interface တစ်ခုကြေညာထားပြီးတော့ clone လုပ်ချင်တဲ့ object တွေကို သူတို့ရဲ့ original object အထိသွားပြီးတော့ coupling လုပ်စရာမလိုဘဲနဲ့ သူမှတစ်ဆင့် clone ပြုလုပ်ခွင့်ပေးထားပါတယ်။ Prototype Interface တိုင်းမှာ clone ဆိုတဲ့ method တစ်ခုပါပါတယ်။


Implement လုပ်တဲ့ပုံစံကတော့ prototype က original object ဆီကနေ object create လုပ်ပြီး fields တွေကို carry လုပ်ပေးထားပြီးတော့ object အသစ်ကလိုတာတဲ့အခါမှာပြန် pass လုပ်ပေးပါတယ်။ Prototype က field တွေကို original ဆီကနေ ယူတဲ့နေရာမှာ within same class ဖြစ်တဲ့အတွက် visibility hidden ဖြစ်တဲ့ private field တွေကိုပါ access လုပ်လို့ရပါတယ်။ ဆိုတော့ နောက်တစ်ကြိမ် ဒီလို object မျိုးလိုချင်ပြီဆို တိုက်ရိုက် access သွားလုပ်ပြီး ပြန်တည်ဆောက်စရာမလိုဘဲ prototype interface ကနေမှတစ်ဆင့် clone ချလိုက်ရုံပါပဲ။

PHP နဲ့ C# code sample လေးတွေတစ်ချက်ကြည့်ရအောင်။

### PHP
```
<?php

// I made a common prototype interface for cloning purpose.
// has a single function called _clone
abstract class Person {

    protected $name;

    abstract function __clone();

    function getName() {
        return $this->name;
    }
    function setName($name) {
        $this->name = $name;
    }
}

// Here is a concrete class extending the person prototype.
// we will implement the _clone method to support object cloning.
//This may contain a lot of fields and implementations but I will keep this simple for now.
class Boy extends Person {
    function __clone() {

    }
}


//here is our first time instantiation of boy concrete class
$person = new Boy();

//next time we will clone that object by using clone.
// we will also pass the name param dynamically.
// clone1
$person1 = clone $person;
$person1->setName('Hlaing');
$person1->getName();

// clone2
$person2 = clone $boy;
$person2->setName('Tin');
$person2->getName();

print_r($person1);
print_r($person2);
 


?>
```

### C#
```
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    // Here is my simple object that support object cloning.
    // I already build a function called copyclone to clone this object.
    public class Person
    {
        public string Name;

        public Person CopyClone()
        {
            return (Person)this.MemberwiseClone();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            // firstly we build a object using new instantiation
            Person person = new Person();

            //next time we will clone that object by theh function copyclone.
            // we will also pass the name param dynamically.
            // clone1
            Person person1 = person.CopyClone();
            person1.Name = "Hlaing";

            // clone2
            Person person2 = person.CopyClone();
            person2.Name = "Tin";


            Console.WriteLine(person1.Name);
            Console.WriteLine(person2.Name);
        }

        
    }

}

```

Code တွေကို complexity နည်းအောင် ကျနော်ရေးပေးထားတယ်။ Implementation ကတော့ အပေါ်မှာ ကျနော် ပြောထားတဲ့အတိုင်းပဲ clone support ပေးမယ့် common interface တစ်ခုရှိမယ်။ နောက်တစ်ချိန်ပုံစံတူ object တွေ ဆောက်ရတော့မယ်ဆို သူ့ဆီကနေ clone ပြန်ပွားလိုက်ရုံပဲ။

Clone ချထားတဲ့အတွက် concrete class တွေကမှတစ်ဆင့် coupling ဖြစ်တဲ့ issue ကိုရှောင်နိုင်မယ်။
New ဆိုတဲ့ keyword နဲ့ ထပ်ခါထပ်ခါ instantiate လုပ်စရာမလိုတော့ဘူး။
Object တွေကို အစအဆုံးပြန်ဆောက်စရာမလိုတဲ့အတွက် complexity လည်းနည်းသွားမယ်။

အခုပြထားတဲ့ code တွေကတော့ simple prototype pattern ပဲဖြစ်ပါတယ်။ ဒါပေမယ့် မူရင်း original object မှာကတည်းက တစ်ခြားသော reference လုပ်ထားတဲ့အရာတွေရှိမယ်ဆို clone လုပ်ရတဲ့နေရာမှာ complex ဖြစ်နိုင်ပါတယ်။
