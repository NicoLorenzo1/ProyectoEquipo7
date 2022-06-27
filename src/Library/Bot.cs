using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
//por hacer
namespace Library
{
public abstract class Bot{
            // El token provisto por Telegram al crear el bot. Mira el archivo README.md en la raíz de este repo para
        // obtener indicaciones sobre cómo configurarlo.
    public static string token;
    // Configura la aplicación.
    public static void Setup()
    {
        // Lee una variable de entorno NETCORE_ENVIRONMENT que si no existe o tiene el valor 'development' indica
        // que estamos en un ambiente de desarrollo.
        var developmentEnvironment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var isDevelopment =
            string.IsNullOrEmpty(developmentEnvironment) ||
            developmentEnvironment.ToLower() == "development";

        var builder = new ConfigurationBuilder();
        builder
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // En el ambiente de desarrollo el token secreto del bot se toma de la configuración secreta
        if (isDevelopment)
        {
            builder.AddUserSecrets<Bot>();
        }

        var configuration = builder.Build();

        IServiceCollection services = new ServiceCollection();

        // Mapeamos la implementación de las clases para  inyección de dependencias
        services
            .Configure<BotSecret>(configuration.GetSection(nameof(BotSecret)))
            .AddSingleton<ISecretService, SecretService>();

        var serviceProvider = services.BuildServiceProvider();
        var revealer = serviceProvider.GetService<ISecretService>();
        token = revealer.Token;
    }
}
}

