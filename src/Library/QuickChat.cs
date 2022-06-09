using System;

namespace Library
{
    public class QuickChat
    {
        public static Dictionary<int, string> predefinedChats = new Dictionary<int, string>()
        {
            {1, "Buen disparo!"},
            {2, "Horrible!"},
            {3, "buena suerte!"}
        };

        public static void AllMessages()
        {
            Console.WriteLine("Menú de mensajes predefinidos:");
            foreach (var item in predefinedChats)
            {
                Console.WriteLine($"-{item.Key}: {item.Value}");
                //return $"-{item.Key}: {item.Value}\n";
            }
        }


        public static string SendPredefinedChat(int num)
        {
            foreach (var item in predefinedChats)
            {
                if (predefinedChats.ContainsKey(num))
                {
                    Console.WriteLine(predefinedChats[num]);
                    return predefinedChats[num];
                }
            }
            return "No hay un mensaje predefinido para ese numero";
        }

    }
}