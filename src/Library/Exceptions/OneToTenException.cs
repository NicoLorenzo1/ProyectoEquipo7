[System.Serializable]
public class OneToTenExceptionException : System.Exception
{
    public OneToTenExceptionException() { }
    public OneToTenExceptionException(string message) : base(message) { }
    public OneToTenExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected OneToTenExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}