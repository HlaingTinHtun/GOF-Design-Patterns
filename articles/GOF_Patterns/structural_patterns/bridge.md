## Bridge Design Pattern

### Objective

GOF ထဲမှာရေးထားတဲ့အတိုင်း ဘာသာပြန်ရမယ်ဆို ရှုပ်နိုင်တဲ့အတွက် ကျနော်နားလည်ထားသလို ဆီလျော်အောင် ပြောရရင် bridge ဆိုရင် ဟိုဘက်ကမ်း ဒီဘက်ကမ်းလိုမျိုးရှိတယ်ဟုတ်၊ ပြန်လည် ချိတ်ဆတ်တဲ့နေရာမှာ အခြင်းခြင်းရဲ့ implementation သဘောတရားတွေကို hide လုပ်၊ abstract ထုတ်ပြီး decouple လုပ်လိုက်ခြင်းပါပဲ။ 

ဒါကတော့ GOF က ရေးထားတာဖြစ်ပါတယ်။
Decouple an abstraction from its implementation so that the two can vary independently.

### Usage & Implementation

Objective ဖတ်ပြီး နားလည်သွားမှာမဟုတ်ဘူးဆိုတာ သေချာပါတယ်။ ကျနော်လည်း အဲ့ဒီ English Meaning ကို နားမလည်ပါဘူး။ ဆက်ရေးမယ့် Usage နဲ့ Implementation and code samples တွေကို ကြည့်ရင် ဖြည်းဖြည်းခြင်းနားလည်သွားပါလိမ့်မယ်။ ဒါပေမယ့် decouple လုပ်တာတို့၊ abstraction ရဲ့ သဘောတရားတွေကို နားလည်ထားရပါမယ်။ ကျနော် အရှေ့က articles တွေမှာ အကျယ်ရေးဖူးပါတယ်။ ပြန်ရှာပြီးဖတ်နိုင်ပါတယ်။
ဆိုတော့ အရင်ဆုံး bridge ကဘယ်လိုနေရာတွေမှာ သုံးလို့ရနိုင်လဲဆိုတာနဲ့စရအောင်။ ကျနော်တို့ဆီမှာ Application ဆိုတဲ့ parent class တစ်ခုရှိတယ်ဆိုပါစို့၊ အဲ့ဒီအောက်မှာမှ android app ရှိမယ်၊ iOS app ရှိမယ်၊ ဟုတ်ပီ၊ နောက်တစ်ဆင့် အနေနဲ့ application တွေမှာသုံးမယ့် database driver ထပ်ထည့်ချင်တယ်ဆိုပါစို့၊ MySQL & Oracle ပဲထား။ ဒါဆိုရင် android & iOS ဆိုတဲ့ subclass တွေဖြစ်တဲ့အတွက် သူတို့ တစ်ခုခြင်းဆီရဲ့ အောက်မှာ sub class of sub class တွေထပ်ထားရတော့မယ်။ android sub class အောက်မှာလဲ MySQL & Oracle sub class ထပ်ထားရမယ်၊ iOS မှာလဲ ထိုနည်းလည်းကောင်း ထပ်ထားရပါမယ်။ ဒါဆိုရင် တစ်ဖြည်းဖြည်းနဲ့ သူ့ရဲ့ class hierarchy က ဆပွားကြီးလာဖို့ပဲရှိပါတယ်။ db driver တွေအောက်မှာဆက်ရှိလာမယ်ဆိုရင် hierarchy က တော်တော်များသွားပါလိမ့်မယ်။ ဒီလို အခြေအနေမျိုးမှာ ထိန်းချုပ်နိုင်ဖို့အတွက် bridge pattern ကိုအသုံးပြုပါတယ်။
အပေါ်ကဖြစ်တဲ့ issue က ပုံမှန် class inheritance ကိုက အဲ့လိုရှိနေလို့ ဒီလိုဖြစ်ရခြင်းဖြစ်ပါတယ်။ bridge pattern မှာ class inheritance မလုပ်တော့ဘဲနဲ့ object composition ပုံစံနဲ့သွားလိုက်ပါတယ်။ object composition ကို မြင်အောင် ပြောရရင် ကျနော်တို့အပေါ်မှာ ပြောထားတဲ့ application ဆိုတဲ့ class ကိုသက်သက် sub class တွေအောက်ကို hierarchy အသစ်ထပ်ဝင်လာမယ့် db drivers တွေကို hierarchy inheritance ပုံစံမလုပ်တော့ဘဲ သူ့ကိုလည်း သီးခြား object တစ်ခုအနေနဲ့ ရပ်တည်လိုက်ပြီး sub class အနေနဲ့ MySQL & Oracle ဆိုပြီးထားလိုက်ပါမယ်။ ပြီးတော့မှ original class ဖြစ်တဲ့ application ကနေပြီးတော့ hierarchy လုပ်ရမယ့် db drivers class ကို object reference လုပ်လိုက်မှာပဲဖြစ်ပါတယ်။

### Implementation

Code နဲ့ implement မလုပ်ခင် ဒီတိုင်းအရင် ချရေးကြည့်ပါတယ်။ Parent original class အတွက် interface တစ်ခုရှိမယ်၊ အဲ့ဒီ interface ကို implement လုပ်မယ့် abstract class တစ်ခုထပ်ထားထားမယ်။ အဲ့ဒီ abstract class ထဲမှာ နောက်လာမယ့် hierarchy object ကို reference လုပ်ထားမယ်။ original class ရဲ့ sub concrete class တွေက abstract class ကို extend လုပ်ပြီး implementation တွေဆက်လုပ်မယ်။ ဒါက original class ရဲ့အပိုင်း၊ နောက်လာမယ့် hierarchy မှာဝင်လာမယ့် class ကိုကလည်း သီးသန့် interface တစ်ခုရှိမယ် (original abstract class က reference လုပ်မှာ အခု interface class)။ ပြီးရင် အဲ့ဒီ interface ကို implements လုပ်မယ့် concrete sub class တွေရှိမယ်။
Client ကနေ access လုပ်တဲ့နေရာမှာ ဘယ် concrete class ရဲ့ implementation detail ကိုမှသိစရာမလိုဘူး၊ decouple လုပ်ထားတဲ့ abstract တွေကနေတစ်ဆင့် ကိုယ်လိုချင်တာကို access လုပ်လို့ရသွားရမယ်။ ဒါက bridge pattern ရဲ့ main theme ပါပဲ၊ ဒီထိရောက်ပြီဆို bridge ကိုသဘောပေါက်လာပြီထင်ပါတယ်။ code samples လေးတွေပါတစ်ခါတည်း ထပ်ကြည့်ရအောင်။

### PHP Code Sample
```
<?php

/**
 * This is the original application interface 
 * where we place the methods need to develop from its concrete sub classes
 */
interface ApplicationInterface
{
    public function setDbDriver(DbDriver $dbDriver);
 
    public function query($query);
}

/**
 * This abstract class will implements the interface as we have to reference the next hierarchy object here.
 * After that we can access the methods of their sub concrete classes in our sub classes. see below.
 */
abstract class Application implements ApplicationInterface
{
   protected $dbDriver;
 
   public function setDbDriver(DbDriver $dbDriver)
   {
       $this->dbDriver = $dbDriver;
   }
}

/**
* Concrete sub classes of the original class working with the reference object's method.
*/
class android extends Application
{
    public function query($query)
    {
        $query .= "\n\n running android app query\n";
 
        return $this->dbDriver->handleQuery($query);
    }
}
 
class ios extends Application
{
    public function query($query)
    {
        $query .= "\n\n running ios app query\n";
 
        return $this->dbDriver->handleQuery($query);
    }
}


/**
* This is the interface that need to be referenced by original class instead of inheritance.
*/
interface DbDriver
{
    public function handleQuery($query);
}

/**
* Concrete classes that will have the detail implementations of the interface.
*/
class MysqlDriver implements DbDriver
{
    public function handleQuery($query)
    {
        echo "\nUsing the mysql driver: ".$query;
    }
}
 
 
class OracleDriver implements DbDriver
{
    public function handleQuery($query)
    {
        echo "\nUsing the oracle driver: ".$query;
    }
}


//client code
// client doesn't need to know any implementation details. 
// Just build the original concrete class and inject the concrete object that will be referenced.
 
$android = new android();
$android->setDbDriver(new MysqlDriver());
echo $android->query("select * from table");
 
$android->setDbDriver(new OracleDriver());
echo $android->query("select * from table");
 

$ios = new ios();
$ios->setDbDriver(new MysqlDriver());
echo $ios->query("select * from table");

$ios->setDbDriver(new OracleDriver());
echo $ios->query("select * from table");
 
```

### C# Code Sample
```
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    /**
     * Two Original classes referencing the same DbDriver which is the next hierarchy object
     * After that we can access the methods of their sub concrete classes in our sub classes. query method in this case
     */
    class ApplicationInterface
    {
        protected DbDriver  _dbdriver;

        public ApplicationInterface(DbDriver  dbdriver)
        {
            this._dbdriver = dbdriver;
        }

        public virtual string setDbDriver()
        {
            return "Base DB Driver:" +
                _dbdriver.query();
        }
    }

    class RefinedAbstraction : ApplicationInterface
    {
        public RefinedAbstraction(DbDriver  dbdriver) : base(dbdriver)
        {
        }

        public override string setDbDriver()
        {
            return "Refined DB Driver:" +
                base._dbdriver.query();
        }
    }


    /**
    * This is the interface that need to be referenced by original class instead of inheritance.
    */
    public interface DbDriver 
    {
        string query();
    }

    /**
    * Concrete classes that will have the detail implementations of the interface.
    */
    class MysqlDriver : DbDriver 
    {
        public string query()
        {
            return "Using the mysql driver:\n";
        }
    }

    class OracleDriver : DbDriver 
    {
        public string query()
        {
            return "Using the oracle driver:.\n";
        }
    }

    // client doesn't need to know any implementation details. 
    // Just build the original class and inject the concrete object that will be referenced.
    class Client
    {
        public void ClientCode(ApplicationInterface applicationInterface)
        {
            Console.Write(applicationInterface.setDbDriver());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            ApplicationInterface applicationInterface;

            applicationInterface = new ApplicationInterface(new MysqlDriver());
            client.ClientCode(applicationInterface);

            Console.WriteLine();

            applicationInterface = new RefinedAbstraction(new OracleDriver());
            client.ClientCode(applicationInterface);
        }
    }

}

```

PHP ရော C# ရောအပေါ်က ပြောထားတဲ့ အတိုင်း implement လုပ်ထားပါတယ်၊ code comment တွေလည်း ထည့်ပေးထားတဲ့အတွက် နားလည်မယ်လို့ထင်ပါတယ်။ C# မှာတော့ original class အတွက် sub concrete class တွေထပ်မဆောက်တော့ဘဲ interface class နဲ့ refined class ကိုပဲတန်းသုံးလိုက်တာကလွဲလို့ ကျန်တာတွေ အကုန်အတူတူပဲဖြစ်ပါတယ်။

Bridge ကိုသုံးခြင်းအားဖြင့် object အချင်းချင်း သိသိသာသာ decouple ဖြစ်သွားမယ်။ client code ကလည်း concrete တွေရဲ့ implementation detail သိစရာမလိုဘဲ abstraction ကိုပဲသုံးပြီး အလုပ်လုပ်လို့ရသွားမယ်။ နောက်ထပ် hierarchy အသစ်ဝင်လာစရာရှိရင်လည်း existing code base ကို effect မဖြစ်ဘဲ လုပ်လို့ရသွားမှာပဲဖြစ်ပါတယ်။ ဒါပေမယ့် bridge pattern ကိုသုံးမယ်ဆို ပုံမှန် simple ဖြစ်တဲ့ scenario မှာတောင် code complexity ရှိနေတဲ့အတွက် original class ကိုက ရှုပ်ထွေးတဲ့ implementation တွေရှိနေနိုင်မယ်ဆို bridge ကိုထပ်သုံးလိုက်ရင် complexity level ပိုတတ်သွားနိုင်ပါတယ်။

