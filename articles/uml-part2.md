## UML (Unified Modeling Language) – Part 2
### Relationship Notations (Acquaintance & Inheritance)
![Image of UML Part2](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-part2.png)

 Part 1 မှာတုန်းက Class Diagram အကြောင်းလေးနဲ့စပြီး intro ဝင်ခဲ့ပါတယ်၊ အခု part 2 မှာ အဲ့ဒီ diagram တွေမှာသုံးခဲ့တဲ့ notation လေးတွေအကြောင်းကို ရေးသွားပါမယ်။ အဓိက ကတော့ GoF (Gang of four) design pattern UML တွေကို reference လုပ်ထားတဲ့ notation တွေပါပဲ။

 part 1 ဖတ်ထားဖို့လိုပါတယ်။

 ဆိုတော့ ကျနော်ဒီမှာပုံလေးတစ်ပုံဆွဲထားတယ်။ ကြည့်ရအောင်
 ![Image of notations](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/notations.png)
 အများကြီးတော့ မပါဘူး၊ ဒါပေမယ့် အခုပြထားတဲ့ notation လေးတွေကို design pattern လေ့လာတဲ့အချိန်မှာ ခနခန မြင်ရမှာပဲဖြစ်ပါတယ်၊ အရေးကြီးပြီး အသုံးဝင်တဲ့အရာလေးတွေပေါ့။ တစ်ချို့ situation လေးတွေမှာတော့ meaning ကွဲတာတွေရှိနိုင်ပေမယ့် ယေဘုယျအားဖြင့်တော့ သဘောတရားအတူတူပါပဲ၊ ဆိုတော့ စလိုက်ရအောင်။

 Part.1 မှာတုန်းက acquaintance လုပ်တာတို့ extend, instantiate လုပ်တာတို့ကမြင်ခဲ့တယ်ဆိုပေမယ့် ဘာတွေလဲ တိတိကျကျတော့ သိခဲ့မှာမဟုတ်လောက်ဘူး၊ ပြီးတော့ နောက်ထပ် aggregation တို့ တစ်ခြား notation လေးတွေလည်းပါလာတာတွေ့ရမယ်၊ ဒီနေ့ ကျနော် တစ်ခုခြင်းဆီအတွက် အနက်ဖွင့်ပေးသွားပါမယ်။

 Acquaintance / Object Reference

 Acquaintance လုပ်လိုက်တယ်ဆိုတာ class တစ်ခုရဲ့ reference ကို နောက် class တစ်ခုက hold လုပ်ထားတဲ့သဘောပဲ။ ဆိုတော့ part 1 မှာလုပ်ခဲ့တဲ့ acq example လေးကိုပြန်ကြည့်ရအောင်။
 ![Image of acq](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/acq.png)

 Code အနေနဲ့ကြည့်မယ်ဆို
 ![Image of acqcode](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/acqcode.png)

 Client က SampleInterface ကို acq relation လှမ်းလုပ်ထားတယ်၊ တစ်နည်းအားဖြင့် Object Reference လုပ်ပြီး $sample အနေနဲ့ယူထားတယ်။ အဲ့လိုလုပ်ခြင်းအားဖြင့် $sample ကနေမှတစ်ဆင့် လိုချင်တဲ့ method တွေကို execute လုပ်ခွင့်ရှိသွားတယ်။ ဒီ scenario မှာတော့ အဲ့လို reference လုပ်နိုင်ဖို့အတွက် နောက်ထပ် class တစ်ခု instantiate လုပ်ရတယ်ပေါ့။ မတူညီတဲ့ နောက်ထပ် ဥပမာလေးတစ်ခုကြည့်ရအောင်။

 ![Image of acq](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/acq2.png)


```
 Class classA extends Parent()
 {
    private $data;
    protected function method()
    {
      $this->data = new classB();
      $this->data->method();
    }
 }
 ```

 ဒီနေရာမှာ classB instantiate လုပ်ပြီးမှ acq relation လုပ်ပုံကိုလည်းတစ်မျိုးတစ်ဖုံတွေ့ရမှာပဲဖြစ်ပါတယ်။ Strongly Type Lang တွေမှာတော့ ဒီလိုကြေညာတာပေါ့။
 private ClassB data;
 PHP လိုကောင်မျိုးမှာတေ့ private $data ဆိုပြီးကြေညာတာ any type ဖြစ်နေသေးတယ်၊ပြီးတော့ မှ classB ရဲ့ object reference ကို hold လုပ်ခိုင်းထားလိုက်တယ်။ ဒီလောက်ဆို acquaintance relation အကြောင်းသဘောပေါက်ကောင်းပါရဲ့။ ဒါနဲ့ one to many လည်းရှိသေးတယ်၊ arrow ရှေ့မှာ circle လေးပါရင် ဒီ relation ဟာတစ်ခုထက်ပိုနိုင်တယ်လို့ဆိုလိုတာ၊ မပါရင်တော့ one ပဲပေါ့။

 Inheritance အကြောင်းဆက်ရအောင်။

 သူကတော့လွယ်ပါတယ်။ notation ကို triangle လေးနဲ့သုံးတယ်။ abstract class ပဲလာလာ ၊ interface ပဲလာလာပေါ့။ single inheritance လည်း ရှိနိုင်သလို multiple inheritance လည်းရှိနိုင်တယ်။ ဘာလို့ GoF က abstract class ကိုရော interface ကိုရော triangle symbol ပဲသုံးလဲဆိုတော့ ab class ရော interface ရောမှာ implementation logic ကတူနေလို့ပါပဲ၊ ab class ဆိုလည်း ab method တွေကို implementation လုပ်ရတယ်၊ ထိုနည်းလည်းကောင်းပဲ interface ကလည်း implementation လုပ်ပေးဖို့လိုအပ်တယ်။ ဒါကြောင့်မို့ symbol notation ကိုတူတူပဲသုံးတာဖြစ်ပါတယ်။ ဒီကောင်ကတော့ နားလည်းရလွယ်တော့ ပုံတွေသက်သက်မဆွဲပြတော့ပါဘူး။ Aggregation နဲ့ Instantiation အကြောင်းကို Part 3 ဆက်ရေးပေးသွားပါမယ်။
