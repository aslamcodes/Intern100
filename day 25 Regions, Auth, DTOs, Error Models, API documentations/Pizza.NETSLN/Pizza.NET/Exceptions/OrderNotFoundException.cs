namespace Pizza.NET.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public override string Message => "Order not found exception";
    }
}
