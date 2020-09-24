## Adapter

### Objective
မတူညီတဲ့ interface ရှိတဲ့ objects တွေကို adaptable ဖြစ်အောင် ကြားခံလုပ်ယူပြီး အချင်ချင်း communicate လုပ်လို့ရအောင်ပြုလုပ်ပေးပါတယ်။ Structural design pattern တစ်ခုဖြစ်ပါတယ်။

### Usage & Implementation
Objective ဖတ်ဖတ်ပြီးချင်းနားလည်ဖို့ခက်ဦးမယ်။ တိုတိုနဲ့နားလည်အောင် ဥပမာ တစ်ခုပေးရရင် ကျနော့်မှာ laptop တစ်လုံးရှိတယ်၊ အားသွင်းကြိုးက 3 Pin နဲ့ ၊ ဆိုတော့ 3 pin ရှိတဲ့ socket ပေါက်ရှိမှသာ ကျနော့် laptop ကိုအားသွင်းလို့ရမယ်။ ဒါပေမယ့် ခက်တာက 3 pin ရှိတဲ့ socket ပေါက်တွေက မရှိဘူး။ 2 pin socket ပေါက်တွေပဲရှိတယ်။ ဒီလိုအချိန်က 2 pin ပေါက်ကနေ 3 pin ပြန်လက်ခံတဲ့ socket ကြားခံပစည်းလေးတွေရှိတယ်။ အဲ့တာကို သုံးမယ်ဆိုရင်တော့ ကျနော့် laptop ကို 3 pin ကနေတစ်ဆင့် အားသွင်းလို့ရသွားမယ်။ 2 pin ကနေတိုက်ရိုက်ယူတာတော့မဟုတ်ပေမယ့် ကြားထဲက 2pin to 3pin socket adapter ကနေတစ်ဆင့် လှမ်းယူလိုက်တာဖြစ်ပါတယ်။ adapter ဆိုတာကလဲ ထိုနည်းလည်းကောင်းပါပဲ။ မတူညီတဲ့ interfaces တွေရှိတယ်၊ ဒီတိုင်းဆို အခြင်ခြင်း communicate လုပ်လို့မရပေမယ့် ကြားခံ adapter တစ်ခုထည့်ပြီး အဆင်ပြေအောင် လုပ်နိုင်ပါတယ်။ Technical terms အရ example ထပ်ပေးရရင် ကျနော်တို့ဆီမှာ third party API service တစ်ခုကနေ ချိတ်ထားတဲ့ object တစ်ခုရှိတယ်။ response တွေကို xml နဲ့လက်ခံပြီး xml နဲ့လည်း အလုပ်လုပ်နေတယ်။ ဒါပေမယ့် နောက် object တစ်ခုက xml လက်ခံရတာ အဆင်မပြေဘူး၊ Json ပဲလက်ခံချင်တယ်ဆို ရှိပြီးသား object ကိုသွားပြီး ပြင်လို့မရပေမယ့် ကြားကနေ adapter တစ်ခုထည့်ပြီး xml to json conversion အလုပ်လုပ်ကိုလုပ်ပေးခြင်းအားဖြင့် နဂို interface နဲ့ adapter တွဲသုံးပြီး Json နဲ့အလုပ်လုပ်နိုင်သွားမှာဖြစ်ပါတယ်။
Implementation အတွက်ကတော့ adapter သုံးဖို့ဆို ပထမဦးဆုံး interface incompatible ဖြစ်တဲ့ object နှစ်ခုအနည်းဆုံးရှိရမယ်၊ ဒါမှလည်း adapter ထည့်လို့ရမှာကိုး၊ ပုံမှန် interface နဲ့ အလုပ်လုပ်နေတဲ့ object ကတော့ ရှိမြဲအတိုင်းပဲအလုပ်လုပ်နေမယ်။ incompatible ဖြစ်တဲ့ object အတွက် adapter တစ်ခုဆောက်မယ်၊ အဲ့ adapter က ခုနက interface ကို implement လုပ်မယ်၊ conversion အတွက် sub object ကိုလဲသုံးရင်းနဲ့ပေါ့. Adapter class ထဲမှာပဲ conversion လုပ်နိုင်ရင်တော့ sub object ခွဲစရာမလိုပါဘူး။ adapter ဆောက်ပြီးပြီဆို client code ကနေ original interface ကနေမှတစ်ဆင့် adapter က method တွေကို လှမ်း access လုပ်ပြီး ကိုယ်လိုချင်တဲ့ conversion format တွေကိုရနိုင်ပါပြီ။
Code တွေနဲ့ကြည့်ရင် ပိုမြင်သွားပါလိမ့်မယ်။ PHP & C# code sample တွေထည့်ပေးထားပါတယ်။

### PHP Sample Code
```
<?php
/**
 * The original interface that is working as normal
 */
interface Socket
{
    public function input();
}
/**
 * This is the simple class that follows the existing target interface `Socket`
 */
class twoPinSocket implements Socket
{
    public function input()
    {
        echo "two pin input";
    }
}
/**
 * This is the conversion class (might be 3rd party service code as well) that will be used later in adapter class.
 */
class conversion
{
    public function changetoThreePin()
    {
        echo "changed to three pin => three pin input";
    }
}
/**
 * This is the adapter class implementing the original target interface linking with conversion class.
 * this will product the format that is second object want.
 */
class threePinSocket implements Socket
{
    private $conversion;
    public function __construct(conversion $conversion)
    {
        $this->conversion = $conversion;
    }
    public function input()
    {
        $this->conversion->changetoThreePin();
    }
}
/**
 * The existing twoPinSocket class that follows the target interface.
 */
$socket = new twoPinSocket();
echo $socket->input();
/**
 * threePinSocket conversion that follows target interface using conversion adapter
 */
$conversion = new conversion();
$socket = new threePinSocket($conversion);
echo $socket->input();
?>
```

### C# Sample Code
```
using System;
namespace HelloWorld
{
    /**
     * The original interface that is working as normal
     */
    public interface Socket
    {
        string input();
    }
    /**
     * This is the simple class that follows the existing target interface `Socket`
     */
    class TwoPinSocket : Socket
    {
        public string input()
        {
            return "two pin input";
        }
    }
    /**
     * This is the conversion class (might be 3rd party service code as well) that will be used later in adapter class.
     */
    class Conversion
    {
        public string change()
        {
            return "changed 2pin to 3pin";
        }
    }
    /**
     * This is the adapter class implementing the original target interface linking with conversion class.
     * this will product the format that is second object want.
     */
    class ThreePinSocket : Socket
    {
        private readonly Conversion _conversion;
        public ThreePinSocket(Conversion conversion)
        {
            this._conversion = conversion;
        }
        public string input()
        {
            return this._conversion.change();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             * The existing twoPinSocket class that follows the target interface.
             */
            Socket socket = new TwoPinSocket();
            Console.WriteLine(socket.input());
            /**
             * threePinSocket conversion that follows target interface using conversion adapter
             */
            Conversion conversion = new Conversion();
            Socket socket = new ThreePinSocket(conversion);
            Console.WriteLine(socket.input());
        }
    }
}
```

ကျနော် နားလည်ရလွယ်အောင် အရင်ဆုံးပေးခဲ့တဲ့ two pin ,  three pin socket example ကိုပဲ code နဲ့ ရေးပြထားတယ် socket ဆိုတဲ့ interface တစ်ခုမှာ input ဆိုတဲ့ function ရှိတယ်၊ two pin class ကပုံမှန်အတိုင်းအလုပ်လုပ်နေတဲ့ class ဖြစ်တယ်။ three pin ကျတော့ incompatible ဖြစ်တဲ့ class ဖြစ်လာပြီး ကြားခံ conversion class တစ်ခုရေးပြီးတော့ adapter တစ်ခုအဖြစ် ဖန်တီးပြီး target interface ဖြစ်တဲ့ socket ကို implement လုပ်လိုက်ခြင်းအားဖြင့် လိုချင်တဲ့ conversion ကိုယူလိုက်ပါတယ်။ C# code ကလည်း ရေးထုံးပဲ ကွာသွားပါမယ်။ ကျန်တာ အကုန်အတူတူပါပဲ။
Adapter ကိုသုံးခြင်းအားဖြင့် Data conversion process နဲ့တစ်ခြား code တွေကိုခွဲထားနိုင်တယ်၊ ပြီးတော့ adapter အသစ်ထည့်တာ ဖြုတ်တာတွေကို လက်ရှိ ရှိပြီးသား target interface နဲ့ object ကိုထိခိုက်မှုမရှိဘဲလုပ်နိုင်တယ်။ ဒါပေမယ့် တစ်ချို့ scenario တွေမှာ adapter မလိုဘဲ တိုက်ရိုက် conversion လုပ်နိုင်တဲ့ case လည်းရှိနိုင်တဲ့အတွက် အဲ့ဒီ အချိန်မှာ Adapter တွေဆောက်မယ်ဆို မလိုအပ်ဘဲ code ဖောင်းပွလာတာမျိုးလည်း ရှိနိုင်ပါတယ်။