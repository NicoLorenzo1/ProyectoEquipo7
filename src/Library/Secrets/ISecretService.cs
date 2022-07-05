namespace Library
{
// Una interfaz requerida para configurar el servicio que lee el token secreto del bot.
public interface ISecretService
{
    string Token { get; }
}
}
