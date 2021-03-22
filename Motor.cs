using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Motor
    {
        static void Main(string[] args)
        {

            int pantallaX = 180;
            int pantallaY = 52;
            string[] enemigos = { "Sample", "Guerrero" };
            string[] poderes = { "Furia", "Escudo" };
            int poder = 0;
            Resources.Initialize(pantallaX, pantallaY);
            Resources.Printing(Resources.OpenFile("Title"));
            Console.WriteLine("\n\n\n\n");

            Protagonista prota = new Protagonista();
            Console.WriteLine("Hola: " + prota.GetName());

            for (int i = 0; i < enemigos.Length; i++)
            {
                Personaje enemigo = new Personaje(enemigos[i]);
                SistemaCombate.Combate(prota, enemigo);
                Console.ReadKey(true);
                prota.setMovimientos("Espadazo");
                poder++;
                prota.setHechizos(poderes[poder]);
            }
        }
    }
}
