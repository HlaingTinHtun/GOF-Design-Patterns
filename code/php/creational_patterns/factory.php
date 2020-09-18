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
