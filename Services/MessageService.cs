using System;
using System.Text;

namespace TextAdventure.Services
{
    public sealed class MessageService
    {
        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteBlock(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
    }
}