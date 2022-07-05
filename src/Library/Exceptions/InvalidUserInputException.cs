[System.Serializable]
/// <summary>
/// Clase que hereda de la clase Exception. Tiene la estructura estandar de una excepción nueva básica.
/// Esta pensada para lanzarse en caso de que el usuario escriba por telegram un mensaje no válido.
/// </summary>
public class InvalidUserInputException : System.Exception
{
    public InvalidUserInputException() { }
    public InvalidUserInputException(string message) : base(message) { }
    public InvalidUserInputException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidUserInputException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
} 
