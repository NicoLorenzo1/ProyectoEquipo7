[System.Serializable]
public class AToJExceptionException : System.Exception
{
    public AToJExceptionException() { }
    public AToJExceptionException(string message) : base(message) { }
    public AToJExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected AToJExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}