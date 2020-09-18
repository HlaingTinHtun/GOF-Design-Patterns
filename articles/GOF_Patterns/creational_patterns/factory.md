## Factory Method Design Pattern

### Factory Method ဆိုတာဘာလဲ။ (Objective)

Interface တစ်ခု support လုပ်ပေးပြီးတော့ အဲ့ဒီ interface ကနေမှတစ်ဆင့် object တွေ create လုပ်နိုင်ပါတယ်။ create လုပ်ထားတဲ့ object type တွေကို subclass တွေမှလည်း တစ်ဆင့် ပြောင်းလဲခြင်းတွေပြုလုပ်နိုင်ပါတယ်။ ဒီလိုမျိုး object creations တွေပါလို့ factory method က creational design patterns category အောက်ကို ရောက်သွားပါမယ်။

### ဘယ်လိုနေရာမှာအသုံးဝင်နိုင်လဲ။ (Usage)

ဘယ်လိုနေရာမှာသုံးလဲ သိနိုင်ဖို့ ပထမဆုံး issue တစ်ခု sample ရှိရမယ်။ ပြီးတော့မှ sample issue ကို factory method သုံးပြီး ဘယ်လိုဖြေရှင်းနိုင်လဲဆိုတာပြောသွားပါမယ်။

ကျနော်တို့ဆီမှာ mail ပို့တဲ့ service တစ်ခုရှိပါတယ်။ ပုံမှန်ကျနော်တို့က mail ပို့တယ်ဆို mailgun ကိုသုံးပြီးပို့နေပါတယ်။ code ကလည်းအဆင်ပြေပြေအလုပ်လုပ်နေတယ်။ အကုန် fine တယ်။ ဒါပေမယ့် mail ပို့တဲ့နေရာမှာ mailgun မဟုတ်တော့ဘူး၊ တစ်ခြား service တစ်ခု mailchimp သုံးချင်တယ်ဆိုပါစို့၊ ဒီလိုအချိန်မှာ ပထမက ကျနော်တို့ရဲ့ mail class မှာ mailgun နဲ့ပို့တဲ့ code တွေနဲ့တစ်ခါတည်း ရေးပြီးသား၊ ပြောင်းတော့မယ်ဆို mail class တစ်ခုလုံးကို override လိုက်လုပ်ဖို့လိုအပ်လာပါမယ်။ နှစ်ခုလုံးကို အပြောင်းအလဲလုပ်ပြီးသုံးချင်တဲ့ အချိန်ဆို ကျနော့်တို့ mail class ထဲမှာ code က တော်တော်လေးရှုပ်လာနိုင်ပါတယ်။

ဒီလိုအချိန်မှာ factory pattern ကိုသုံပြီး factory method တွေဆောက် object creation တွေလုပ်ပြီး ဖြေရှင်းနိုင်ပါတယ်။ factory ရဲ့ အဓိက အချက်က client code ကနေလှမ်းသုံးတဲ့အချိန်မှာ ဒီ service က mailgun လား mailchimp လားသိစရာမလိုဘဲအသုံးပြုနိုင်အောင်ပါ။ ကိုယ်လိုချင်တဲ့ serviceFactory ကို inject လုပ်ပြီးခေါ်သုံးလိုက်ရုံပါပဲ။

Code sample တွေမရေးခင် implementation ကိုစာနဲ့ပဲအရင်စဉ်းစားကြည့်ရအောင်။ mail interface တစ်ခုရှိမယ်၊ sendmailဆိုတဲ့ function တစ်ခုဆောက်ထားမယ်။ အဲ့ဒီ mail interface ကို implement လုပ်မယ့် class နှစ်ခုထားမယ်။ လောလောဆယ်မှာ mailgun နဲ့ mailchimp ပေါ့။ အဲ့ဒီ class တွေမှာ sendmail ဆိုတဲ့ function ကို implement လုပ်မယ်၊ ဒါပေမယ့် မတူတော့ဘူး၊ ကြိုက်သလို implement လုပ်လို့ရမယ်။ mailgun class ကလည်း သူလိုချင်တဲ့ အတိုင်းရေးပြီး return ပြန်မယ်။ Mailchimp လည်းထိုနည်းလည်းကောင်းပဲ။

နောက်ပြီးမှ သက်ဆိုင်ရာ factory method တွေဆောက်ပြီး ခုနက concrete class တွေကို return ပြန်မယ်။ ဒါဆိုရင် client code ကခေါ်သုံးတဲ့နေရာမှာ သက်ဆိုင်ရာ factory ကို instantiate လုပ်ပြီးခေါ်သုံးလိုက်မယ်ဆို တစ်ကယ့် subclasses တွေရဲ့ implementation ကိုသိစရာမလိုတော့ဘူး။ mailgun factory ခေါ်မယ် sendmail function ကိုသွားရင် mailgun နဲ့ mail ထွက်သွားမယ်ဆိုတာသိနေရုံပဲ၊ mailgun class ဘယ်လိုအလုပ်လုပ်လဲဆိုတာသိစရာမလိုတော့ဘူး။

Code sample တွေကအောက်က link တွေကနေဝင်ကြည့်နိုင်ပါတယ်။ လေ့လာနေတဲ့သူဆိုကြည့်ဖြစ်အောင်ကြည့်ပါ။ ဒါမှနားလည်မှာ။

PHP code sample
```
<?php

abstract class MailerFactory
{
    abstract function mailDriver();
}
class MailchimpFactory extends MailerFactory
{
    public function mailDriver()
    {
        return new MailchimpMailer();
    }
}
class MailgunFactory extends MailerFactory
{
    public function mailDriver()
    {
        return new MailgunMailer();
    }
}

interface Mailer
{
    function sendmail($message);
}
class MailchimpMailer implements Mailer
{
    public function sendmail($message)
    {
        echo("Mailchimp email > " . $message . "<br/>");
    }
}
class MailgunMailer implements Mailer
{
    public function sendmail($message)
    {
        echo("mailgun email > " . $message . "<br/>");
    }
}

//Client code
$client = new MailchimpFactory();
$client->mailDriver()->sendmail("This is from Mailchimp");
$client = new MailgunFactory();
$client->mailDriver()->sendmail("this is from mailgun");
?>

```

C# code sample
```
using System;

namespace HelloWorld
{
    abstract class MailerFactory
    {
        public abstract Mailer mailDriver();
    }

    class MailchimpFactory : MailerFactory
    {
        public override Mailer mailDriver()
        {
            return new MailchimpMailer();
        }
    }

    class MailgunFactory : MailerFactory
    {
        public override Mailer mailDriver()
        {
            return new MailgunMailer();
        }
    }

    public interface Mailer
    {
        string sendmail(string message);
    }

    class MailchimpMailer : Mailer
    {
        public string sendmail(string message)
        {
            return "sending from mailchimp";
        }
    }

    class MailgunMailer : Mailer
    {
        public string sendmail(string message)
        {
            return "sending from mailgun";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mailgun = new MailgunFactory();
            Console.WriteLine(mailgun.mailDriver().sendmail("sending from mailgun"));


            var mailchimp = new MailchimpFactory();
            Console.WriteLine(mailchimp.mailDriver().sendmail("sending from mailchimp"));
        }
    }

}

```


Factory pattern ကိုသုံးလို့ ဘာကောင်းသွားလဲဆိုတော့ coupling tight ဖြစ်တာကို လျော့ပေးနိုင်တယ်။ subclass တစ်ခုခြင်းဆီက ဘယ်သူ့အပေါ်မှ မှီခိုခြင်းမရှိဘဲ loosely coupling ဖြစ်တယ်။ နောက်တစ်ခုက extend လုပ်ရတာ၊ remove လုပ်ရတာလွယ်သွားတယ်။ နောက်ထပ် service ရှိလာရင်သော်လည်းကောင်း၊ ရှိပြီးသားကို ဖြုတ်ချင်ရင်သော်လည်းကောင်း တစ်ခြား ဘယ် code ကိုမှ ထိစရာမလိုဘဲနဲ့ လုပ်ဆောင်နိုင်တယ်။

တစ်ခုသတိထားရမှာက subclass တွေအများကြီးက interface တစ်ခုတည်းကို ဝိုင်းပြီး implementation လုပ်တာများလာပြီဆို code က nasty ဖြစ်လာနိုင်ပါတယ်။ implementation လုပ်တဲ့နေရာမှာလည်း interface ရဲ့ intent ကိုကြည့်ပြီး သက်ဆိုင်မှသာ implementation လုပ်သင့်ပါတယ်။

ကျနော်ကိုယ်တိုင်လည်း လေ့လာရင်းရေးနေတာဖြစ်တဲ့အတွက် လိုတာတွေဝင်ရောက်ဖြည့်ပေးသွားနိုင်ပါတယ်။ ကျေးဇူးတင်ပါတယ်။

See you in next pattern.
