// using Telegram.Bot.Types;

// namespace Library
// {
//     /// <summary>
//     /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
//     /// </summary>
//     public class MenuHandler : BaseHandler
//     {
//         /// <summary>
//         /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
//         /// </summary>
//         /// <param name="next">El próximo "handler".</param>
//         public MenuHandler(BaseHandler next) : base(next)
//         {
//             this.Keywords = new string[] { "menu" };
//         }

//         /// <summary>
//         /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
//         /// </summary>
//         /// <param name="message">El mensaje a procesar.</param>
//         /// <param name="response">La respuesta al mensaje procesado.</param>
//         /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
//         protected override void InternalHandle(Message message, out string response)
//         {
//             response = "Este es el menu";
//         }
//     }
// }