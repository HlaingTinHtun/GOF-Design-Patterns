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
