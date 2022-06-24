using System;
using Library;
using Telegram.Bot.Types;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {


            IHandler handler =
                            new HelloHandler(
                            new GoodByeHandler(
                            new PhotoHandler(null, null)
                        ));
            Message message = new Message();
            string response;

            Console.WriteLine("Escribí un comando o 'salir':");
            Console.Write("> ");

            while (true)
            {
                message.Text = Console.ReadLine();
                if (message.Text.Equals("salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Salimos");
                    return;
                }

                IHandler result = handler.Handle(message, out response);

                if (result == null)
                {
                    Console.WriteLine("No entiendo");
                    Console.Write("> ");
                }
                else
                {
                    Console.WriteLine(response);
                    Console.Write("> ");
                }
            }




        }
    }
}
