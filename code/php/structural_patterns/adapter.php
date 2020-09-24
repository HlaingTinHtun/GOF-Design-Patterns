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