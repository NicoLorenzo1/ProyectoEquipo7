using Microsoft.Extensions.Options;
namespace Library
{
// Una clase que provee el servicio de leer el token secreto del bot.
public class SecretService : ISecretService
{
    private readonly BotSecret _secrets;

    public SecretService(IOptions<BotSecret> secrets)
    {
        _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
    }

    public string Token { get { return _secrets.Token; } }
}
}
