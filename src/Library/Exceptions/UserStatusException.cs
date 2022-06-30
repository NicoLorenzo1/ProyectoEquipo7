[System.Serializable]
public class UserStatusExceptionException : System.Exception
{
    public UserStatusExceptionException() { }
    public UserStatusExceptionException(string message) : base(message) { }
    public UserStatusExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected UserStatusExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}