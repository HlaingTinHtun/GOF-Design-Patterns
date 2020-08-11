## Interface & Abstract Class (Part 1)

![Image of I&A1](https://raw.githubusercontent.com/HlaingTinHtun/OOP-Design-Patterns-In-PHP/master/images/interface-abstract-part1.png)

ကျနော်ဒီနေ့ တော်တော်များများရောတတ်ကြတဲ့ OOP concept တွေထဲက interface နဲ့ abstract class အကြောင်းကိုပြောသွားမှာဖြစ်ပါတယ်။ ဆင်သယောင် ရှိပေမယ့်လို့ နှစ်ခုစလုံးရဲ့ purpose scope ကမတူကြပါဘူး။ code example တွေကိုတော့ PHP နဲ့ရေးသွားပါမယ်။

Part 1 မှာ Interface နဲ့ စလိုက်ရအောင်။ ဘာကြောင့် Interface လိုအပ်လဲပါထည့်ပြောသွားပါမယ်။

Interface တစ်ခု implement လုပ်တော့မယ်ဆို၊ interface ဆိုတဲ့ keyword သုံးတယ်၊ Interface ထဲမှာရှိတဲ့ method တွေက abstract method တွေဖြစ်ရမယ်၊ ဆိုလိုချင်တာ အဲ့ဒီ method တွေရဲ့ declaration ပဲရှိမယ်၊ implementation မရှိရဘူး။ နောက်တစ်ချက်က method တွေရဲ့ visibility က public ဖြစ်မယ်။ ဆိုတော့ ဘာကြောင့် interface ကအသုံးဝင်ရတာလဲကို အောက်က နမူနာ code လေးတွေကြည့်ရအောင်။

```
<?php

class useGmail
{
  public function send()
  {
    echo "sending using gmail";
  }
}

class useHotmail
{
  public function send()
  {
    echo "sending using hotmail";
  }
}
usegmail နဲ့ usehotmail ဆိုပြီး ကျနော့်မှာ class နှစ်ခုရှိပါတယ်။

class Client
{
    protected $service;

    public function __construct(useGmail $service)
    {
        $this->service = $service;
    }

    public function submit()
    {
        $this->service->send();
    }
}
```
Client class ကနေ useGmail class ကိုသုံးပြီးတော့ အလုပ်လုပ်မယ်လို့ပြောလိုက်ပါတယ်။
```
$client = new Client(new useGmail);
$client->submit();
```
ပြီးတော့မှ client ထဲမှ submit function ကိုလာrun လိုက်တယ်။ ဒါဆိုရင် sending using gmail ဆိုတဲ့ output ကျနော်တို့ရပါတယ်၊ ဟုတ်ပြီ၊ ဒါဆို Hotmail ကိုသုံးပြီး ပို့ချင်တယ်ဆိုပါစို့၊ ဒါဆိုရင် client class က constructor ထဲမှာသွားပြောင်းပေးဖို့လိုပါတယ်။လက်ရှိ scenario မှာ class ကတစ်ခုတည်း ရှိပေမယ့် real world project တွေမှာ class တွေအများကြီး ရှိနိုင်ပါတယ်။ ဒါကြောင့် တစ်ခုခုပြောင်းချင်ပြီဆို အကုန်လိုက်ပြင်နေရမယ်၊ ဒီနေရာမှာ ဒီလို swapping issue ကို interface သုံးပြီး ဖြေရှင်းကြည့်ရအောင်။
```
<?php

interface mailService
{
    public function send();
}

class useGmail implements mailService
{
  public function send()
  {
    echo "sending using gmail";
  }
}

class useHotmail implements mailService
{
  public function send()
  {
    echo "sending using hotmail";
  }
}
```
mailService ဆိုတဲ့ interface တစ်ခုဆောက်ပြီး usegmail နဲ့ usehotmail တွေကနေ implement လုပ်ထားလိုက်မယ်။ ပြီးတော့ အရှေ့က scenario မှာကျနော်တို့ကို အလုပ်ရှုပ်စေနိုင်မယ့် client class ထဲမှာ usegmail usehotmail ဆိုပြီး manual မထည့်တော့ဘဲ ဒီလိုမျိုး interface ကို constructor ထဲမှာလာ hint လုပ်လိုက်မယ်။

```
class Client
{
    protected $service;

    public function __construct(mailService $service)
    {
        $this->service = $service;
    }

    public function submit()
    {
        $this->service->send();
    }
}
// just have to change this if we want to modify all the time
$client = new Client(new useHotmail);
$client->submit();
```

ဒီလိုမျိုး modify လုပ်ပြီးတဲ့နောက်မှာ ကျနော်တို့အနေနဲ့ mail service ကိုပြောင်းချင်တဲ့အချိန်တိုင်းမှာ client class ကို initiate လုပ်တဲ့နေရာမှာ ကိုယ်သုံးချင်တဲ့ကောင်ကို pass လုပ်ပေးလိုက်ရုံပဲ။ result ကတူတူပဲ၊ constructor ကို manually သွားထိနေစရာမလိုတော့ဘူး။

ဒီလောက်ဆိုရင် interface အကြောင်းသိလောက်ပြီထင်ပါတယ်။ Part 2 မှာ abstract class အကြောင်းရေးသွားပါမယ်။ ဒါဆို interface နဲ့ abstract class ဘာကွာလဲဆိုတာကိုလဲသိသွားပါလိမ့်မယ်။
