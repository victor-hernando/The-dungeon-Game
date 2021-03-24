using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_dungeon
{
    static class Hud
    {
        const int margen = 10;
        public static void printColor(int color, string texto)
        {
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
            Console.Write(texto);
            Console.ResetColor();
        }
        public static void printSkills(int color, string texto, int top =0, int left=0)
        {
            if (left != 0) Console.CursorLeft=left;
            if (top != 0) Console.CursorTop=top;
            printColor(color, texto);
        }
    }
}
