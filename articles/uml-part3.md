## UML (Unified Modeling Language) – Part 3
### Relationship Notations (Aggregation & Instantiation)
![Image of UML Part2](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-part3.png)


#### Aggregate Relationship

Aggregate rs ဆိုတာက acquaintance rs နဲ့ဆင်တယ်၊ ဒါပေမယ့် သူက နည်းနည်းလေး ပို strong ဖြစ်တယ်လို့ သတ်မှတ်ထားပါတယ်။ GOF ထဲမှာပြောထားတာတော့ aggregate rs ကတစ်ခြား rs တွေထက်စာလို့ရှိရင် နည်းနည်းလေးနားလည်ရခက်နိုင်တယ်လို့ပြေထားတယ်။ သူ့အတွက်ဆိုပြီး သီးသန့် code နမူနာလည်းပြလို့မရဘူးတဲ့။ ဆိုတော့ ဒီနေရာမှာ ကျနော်တို့ aggregate rs ကိုနားလည်ဖို့ strategy pattern ကိုသွားကြည့်ကြပါမယ်။ strategy pattern မှာ aggregate rs ပါတယ်ဆိုတော့ သူ့ကိုကြည့်လိုက်မယ်ဆိုရင် aggregate rs ကိုနားလည်မယ်ထင်ပါတယ်။

ကျနော်ဖတ်တဲ့ စာအုပ်ထဲမှာတော့ aggregate rs ကို ဒီလိုလေးနမူနာပေးထားတယ်။ အဓိက က aggregate ရဲ့ သဘောတရားက တစ်ခုနဲ့တစ်ခု ဆက်နွယ်ပြီး ရပ်တည်နေကြတယ်ဆိုတဲ့ သဘောလို့လဲ ကောက်လို့ရပါတယ်။ body ထဲမှာရှိတဲ့ heart နဲ့ lungs ကို ဥပမာ ကြည့်မယ်ဆို heart ကို blood pumping လုပ်နေသမျှ lungs ကလည်း oxygenated ဖြစ်တဲ့ blood တွေနဲ့ အလုပ်ဆက်လုပ်လို့ရတယ်။ ဆိုလိုချင်တာက နှလုံးနဲ့ အဆုတ် ဆိုတာ body organs အနေနဲ့ သက်သက်ဆီဖြစ်နေပေမယ့် တစ်ခု break down ဖြစ်သွားမယ်ဆို နောက်တစ်ခုလည်း အလိုလို break down ဖြစ်သွားလိမ့်မယ်။ ဒီလိုဆက်နွယ်မှုလေးပေါ့။

ဆိုတော့ ရေးရေးလေးပေါ်ပြီဆိုတော့ strategy pattern ကိုဆက်ကြည့်ရအောင်။ strategy pattern က နောက်မှ သက်သက် emphasize လုပ်ပြီးရေးမှာ၊ အခုကတော့ aggregate ကိုပဲနားလည်ဖို့ အဓိကထားပြီးပြောသွားပါမယ်။ ကျနော်ပုံလေးတစ်ပုံနဲ့ code နည်းနည်းရေးထားတယ်၊ ကြည့်ရအောင်။

![Image of UML Factory](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/aggregaters.png)

```
<?php
   class Context
   {
       private $abmethod;
       public function __construct(SampleInterface $abmethod)
       {
           $this->abmethod = $abmethod;
       }
       public function operation($data)
       {
           $this->abmethod->operation($data);
       }
}
?>
```
Sample Interface ထဲမှာ abmethod() ဆိုတဲ့ method တစ်ခုရှိပါတယ်။ ဒါကြောင့်အဲ့ဒီ interface ကိုယူသုံးမယ်ဆိုရင် abmethod ကို concrete implementation ရှိရပါမယ်။ context class ရေးထားတဲ့ code ကိုဆက်ကြည့်ရအောင်။

```
<?php
   class Context
   {
       private $strategy;
       public function __construct(SampleInterface $strategy)
       {
           $this->strategy = $strategy;
       }
       public function abmethod($data)
       {
           $this->strategy->abmethod($data);
       }
}
?>
```
ဒီနေရာမှာ constructor ကိုကြည့်လိုက်မယ်ဆိုရင် SampleInterface ကို instantiate မလုပ်ဘဲ hint လုပ်ပြီး reference ကို hold လုပ်ထားပါတယ်။ ပြီတော့ abmethod ကိုလည်း implementation လုပ်ထားပါတယ်။ ဆိုတော့ ဒီနေရာမှာ context ကို instantiate လုပ်ချင်ပြီဆိုလို့ရှိရင်လည်း abmethod ကို concrete implementation လုပ်ပြီးမှသာ instantiate လုပ်လို့ရပါမယ်။ sample concrete လိုပေါ့။ ဆိုတော့ ဒီလို သဘောတရားလေးက aggregate rs ပါပဲ။ နည်းနည်းတော့ confusing ဖြစ်ကောင်းနိုင်ပေမယ့် အချင်းချင်းဆက်စပ်ပြီး identical lifetime ဖြစ်နေတဲ့ သဘောဘဘာဝကို အခြေခံထားတာပါပဲ။ ဒီနေရာမှာအရမ်းကြီး နားမလည်လဲ အရေးမကြီးပါဘူး။ နောက် pattern တွေလေ့လာတဲ့အခါမှာ aggregate rs တွေပါလာပြီး ဘယ်နေရာမှာ သုံးကြတယ်ဆိုတာကို ပိုပြီးမြင်လာပါလိမ့်မယ်။

#### Instantiation (Relation creation)

Instantiation ကတော့ လွယ်ပါတယ်၊ class တစ်ခုကို instantiate လုပ်လိုက်တာပဲ၊ dash line သုံးတယ်၊ arrow key အထောက်ခံရတဲ့ကောင်က instantiated လုပ်ခံရတယ်။ ကျနော် part 1 မှာတုန်းက factory design pattern မှာပါခဲ့ဖူးတယ်။ ပုံလေးပြန်ထည့်ပေးထားတယ်။

![Image of UML Factory](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-factory-pattern.png)

အောက်ဆုံးမှာ arrow ကို dash line နဲ့သုံးထားတဲ့ instantiation ကိုတွေ့ပါလိမ့်မယ်။ SampleConcrete က factorymethod() ကို implement လုပ်တဲ့နေရာမှာ concreteItem ကို instantiate လှမ်းလုပ်ထားတာကိုတွေ့ရပါမယ်၊ အပေါ်ကပုံ အကြောင်းအသေးစိတ်သိချင်ရင်ဖြင့် part 1 ကို ပြန်လည်ဖတ်ရှုပါ။

So ကျနော်ဒီနေရာမှာပြောစရာရှိတာက instantiation ကို acquaintance ကိုသွားမရောမိဖို့ပဲ။ တစ်ချို့သော situation တွေမှာ Class တွေ interface တွေရဲ့ reference တွေကို hold လုပ်မယ့် acquaintance rs လုပ်ဖို့အတွက် instantiate လုပ်လိုက်ရတာမျိုးတွေလည်း ရှိတတ်တယ်။ ဒီလို situation မှာ အဓိက က acquaitance rs လုပ်ပြီး reference hold လုပ်ဖို့အတွက်ပဲ၊ instantiate လုပ်ချင်တာမဟုတ်ဘူး။ ဒါကြောင့် အဲ့လို situation မှာ dash line မသုံးဘဲနဲ့ acquaintance rs အတွက်ပဲသုံးတဲ့ full arrow line သုံးရပါမယ်။

ဒီလောက်ဆိုရင် part 2 and 3 မှာ ယေဘုယျကျတဲ့ Design Pattern UML Relationship notation အကြောင်းတွေပြောခဲ့ပြီးပါပြီ။ နောက် part 4 မှာ Object Diagram & Interaction Diagram အကြောင်း ရေးပေးသွားပါမယ်။ Part 4 ပြီးရင်တော့ UML ရေးတာ တစ်ခန်းရပ်ပြီး Design Pattern တွေဆက်ရေးပါတော့မယ်။

See Ya.
