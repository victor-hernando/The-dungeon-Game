using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Resources
    {
        /*
           try
           {
               //Pass the filepath and filename to the StreamWriter Constructor
               StreamWriter sw = new StreamWriter("C:\\Users\\bigth\\Documents\\Universitat\\T1\\Fonaments de programació\\Test programs\\Juegos\\Juego the dungeon\\Test.txt");
               //Write a line of text
               sw.WriteLine("Hello World!!");
               //Write a second line of text
               sw.WriteLine("From the StreamWriter class");
               //Close the file
               sw.Close();
           }
           catch (Exception e)
           {
               Console.WriteLine("Exception: " + e.Message);
           }
           finally
           { 
               Console.WriteLine("Executing finally block.");
           }
           */

        public static void Initialize(int pantallaX,int pantallaY)
        {
            Console.SetWindowSize(pantallaX,pantallaY);
            Console.SetBufferSize(pantallaX,pantallaY);
            Console.Title = "The Dungeon {a game by Blue_Glue_Guy}";

        }
        public static void Color(int color, string texto, bool saltoLinea = false)
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
            if (saltoLinea) Console.WriteLine(texto);
            else Console.Write(texto);
            Console.ResetColor();
        }

        public static void PutCursor(bool centered = false, int horizontal =0, int separated = 0)
        {
            int x, y;

            if (centered == true) { x = (Console.WindowWidth)/2;}
            else { x = horizontal; }
            if (separated > 0) { y = Console.CursorTop + separated; }
        }

        public static System.IO.StreamReader OpenFile(string name)
        {
            try
            {
                StreamReader file = new StreamReader("C:\\Users\\bigth\\Documents\\Universitat\\T1\\Fonaments de programació\\Test programs\\Juegos\\Juego the dungeon\\" + name + ".txt");
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        public static void Printing(System.IO.StreamReader print)
        {
            String line;    

            //Read the first line of text
            line = print.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                Console.WriteLine(line);
                //Read the next line
                line = print.ReadLine();
            }
            //close the file
            print.Close();

        }

        public static int Randomize(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next (min, (max + 1));
        }
    }
}
