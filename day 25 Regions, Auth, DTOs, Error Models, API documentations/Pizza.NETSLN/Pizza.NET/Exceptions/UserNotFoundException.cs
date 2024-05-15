namespace Pizza.NET.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message => "User not found";
    }
}
