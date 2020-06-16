## UML (Unified Modeling Language) – Part 4
### Object & Interaction Diagram
![Image of UML Part2](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/uml-part4.png)

UML အကြောင်းရေးတာ အပိုင်း 4 ရောက်လာပါပြီ၊ နောက်ဆုံးအပိုင်းပေါ့။ ဒီအပိုင်းမှာ object & interaction diagram အကြောင်း ရေးပေးသွားပါမယ်။ စလိုက်ရအောင်။

#### Object Diagram

Object နဲ့ Interaction Diagram က အရမ်းမရှုပ်ဘူး၊ Object Reference ဖြစ်သွားပြီဆို ဖြစ်သွားတဲ့ Object Instance တွေကို arrow နဲ့လိုက်ပြီး indicate လုပ်လိုက်ရုံပဲ။ သူ့ object diagram ရဲ့ naming convention ကတော့ class နဲ့မတူဘူး။ class diagram မှာ class name Sample လို့ပေးတယ်ဆိုရင် object မှာ အရှေ့က a sign လေးလိုက်ပြီး aSample ဆိုပြီးပေးတယ်။ ဒါသူ့ရဲ့ convention ပေါ့။ Chain of responsibility design pattern လေ့လာမယ်ဆိုရင် object diagram ရဲ့ အသုံးပြုပုံကိုပါတွဲသိထားမှ အဆင်ပြေမယ်။ chain of responsibility မှာ object တွေက တစ်ခုထက်ပိုပြီး request ကို handle လုပ်ပေးတယ်။ ဥပမာ မြင်အောင် ပြောရရင် call center လိုမျိုး၊ client က ဖုန်းခေါ်လိုက်တယ်၊ client နဲ့ ဖုန်းပြောပေးနိုင်မယ့် အားမယ့် agent ဆီကို တစ်ဆင့်ခြင်းဆီပြန်လွှဲပေးလိုက်တဲ့ ပုံစံမျိုးပေါ့။ အောက်မှာ ပုံလေးနဲ့ ဥပမာပြထားတယ်။

![Image of UML Factory](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/object.png)

Client ကို response ပြန်ပေးနိုင်တဲ့ ဆီကို object တွေက တစ်ဆင့်ခြင်းဆီ direct လုပ်ပေးသွားတာကို တွေ့နိုင်မှာပဲဖြစ်ပါတယ်။

#### Interaction Diagram

Interaction ကလည်း object နဲ့ သဘောသဘာဝအတူတူပဲ။ ဒါပေမယ့် request တွေက object မှာလို horizontal မသွားဘဲ vertical ပုံစံနဲ့သွားတယ်။ အဓိက ကတော့ request တွေ execute ဖြစ်သွားတာကို ဖော်ပြထားတာပါပဲ။ အပေါ်က object diagram တုန်းက scenario ကိုပဲ interaction diagram ပြောင်းလိုက်မယ်ဆို ဒီလိုလေးရလာပါလိမ့်မယ်။

![Image of UML Factory](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/interaction.png)

ဒီ interaction diagram မှာကျနော် red line လေးထည့်ပေးထားတယ်။ ပြောချင်တာက handler အကုန်လုံးက အချိန်တိုင်းမှာ active ဖြစ်မနေဘူးလို့ပြောချင်တာ သူတို့ဆီကို request direct အလုပ်ခံရမှသာ active ဖြစ်နေတယ်။ ဒီမှာဆိုလို့ရှိရင် client က အမြဲတမ်း active ဖြစ်တယ်။ ပြီးတော့ ပထမဆုံး call handler တစ်ခုကို request ပို့လိုက်တယ်၊ အဲ့အချိန်မှ first call handler က active ဖြစ်တယ်၊ second is not active yet. First ကနေ second ကို request ပို့လိုက်တဲ့အချိန်မှ second ကလည်း active ဖြစ်သွားတယ်။ ဒီသဘောပါ။
ဆိုတော့ ဒီလောက်ပါပဲ၊ object နဲ့ interaction ကိုဒီထက် အနက်ထပ်ဖွင့်ချင်လည်း အသေးစိတ်တွေက အစ ထပ်ဖွင့်လို့ရသေးပေမယ့် ဒီလောက်သိထားတယ်ဆိုရင်ပဲ design pattern uml တွေကြည့်ရတဲ့အချိန် နားလည်မယ်လို့ယူဆပါတယ်။ နောက်အပိုင်းတွေမှာ design pattern တွေစရေးပါတော့မယ်။


See ya
