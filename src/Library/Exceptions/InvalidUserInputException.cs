[System.Serializable]
public class InvalidUserInputExceptionException : System.Exception
{
    public InvalidUserInputExceptionException() { }
    public InvalidUserInputExceptionException(string message) : base(message) { }
    public InvalidUserInputExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidUserInputExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}