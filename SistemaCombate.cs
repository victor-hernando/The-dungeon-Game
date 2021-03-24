using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_dungeon
{
    class SistemaCombate
    {
        public static void Combate(Protagonista protagonista, Personaje enemigo)
        {
            Console.WriteLine("Preparate porque el combate con {0} està a punto de empezar", enemigo.GetName());
            Console.ReadKey(true);

            while (ContinuarPeleando(protagonista, enemigo))
            {
                Console.Clear();

                if (protagonista.GetIniciativa() >= enemigo.GetIniciativa())
                {
                    Console.WriteLine("Es tu turno, que prefieres hacer? Usar una de tus habilidades (h), o hacer un ataque (a)?");
                    Ataque(true, protagonista, enemigo);
                    Console.WriteLine("\n");
                    Ataque(false, protagonista, enemigo);
                    protagonista.ResetEstado();
                }
                else
                {
                    Ataque(false, protagonista, enemigo);
                    protagonista.ResetEstado();
                    Console.WriteLine("\n");
                    Console.WriteLine("Es tu turno, que prefieres hacer? Usar una de tus habilidades (h), o hacer un ataque (a)?");
                    Ataque(true, protagonista, enemigo);
                }
                Hud.printColor(2, protagonista.GetName());
                Console.Write(" tiene {0} puntos de vida, un ", protagonista.GetVida());
                Hud.printColor(1, Convert.ToString(protagonista.GetEscudo()));
                Console.Write(" % de reduccion por escudo y ");
                Hud.printColor(4, Convert.ToString(protagonista.GetMagia()));
                Console.Write(" puntos de maná.");
                Console.ReadKey(true);
            }
        }

        private static bool ContinuarPeleando(Personaje uno, Personaje dos)
        {
            return uno.GetVida() > 0 && dos.GetVida() > 0;
        }

        private static void Ataque(bool atacante, Protagonista prota, Personaje enem)
        {
            int habilidad;

            if (atacante)
            {
                char awnser;
                Char.TryParse(Console.ReadLine(), out awnser);
                while (awnser != 'h' && awnser != 'a')
                {
                    Console.WriteLine("Que prefieres hacer? Usar una de tus habilidades (h), o hacer un ataque (a)?");
                    Char.TryParse(Console.ReadLine(), out awnser);
                }
                if (awnser == 'a')
                {
                    Console.WriteLine("¿Que ataque prefieres usar?");
                    Console.WriteLine("Escribe:");
                    for(int i = 0; i < prota.numMovimientos; i++)
                    {
                        Hud.printSkills(1, "<" + (i+1) + ">:", 6,6);
                        Hud.printSkills(4, prota.GetMovimientos()[i].GetName(), 7);
                        Hud.printSkills(3, prota.GetMovimientos()[i].GetDescr(), 8);
                        Hud.printSkills(6, "Multiplicador: ", 9);
                        Hud.printSkills(2, Convert.ToString(prota.GetMovimientos()[i].GetModif()));
                        Console.WriteLine();
                    }
                    
                    habilidad = Convert.ToInt32(Console.ReadLine()) - 1;
                    Daño(enem, prota, habilidad);
                }
                else
                {
                    Console.WriteLine("¿Que habilidad prefieres usar?");
                    Console.WriteLine("Escribe:");
                    for(int i = 0; i < prota.numHechizos; i++)
                    {
                        Hud.printSkills(1, "<" + (i+1) + ">:", 6,6);
                        Hud.printSkills(2, prota.GetHechizos()[i].GetName(), 7);
                        Hud.printSkills(4, prota.GetHechizos()[i].GetDescr(), 8);
                        Hud.printSkills(7, Convert.ToString(prota.GetHechizos()[i].GetModif()), 9);
                        Hud.printSkills(3, "Coste: ", 10);
                        Hud.printSkills(6, Convert.ToString(prota.GetHechizos()[i].GetCoste()));
                        Hud.printSkills(3, " puntos de maná");
                        Console.WriteLine();
                    }
                        habilidad = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (prota.UsarPoder(habilidad) < 0)
                    {
                        Console.WriteLine("No tienes manà suficiente.");
                        Ataque(true, prota, enem);
                    }
                }
                
            }
            else
            {
                Console.Write("És el turno de {0}", enem.GetName());
                Console.WriteLine(); 
                habilidad = Resources.Randomize(0, 2);
                Console.WriteLine("{0} va a usar {1}.",enem.GetName(), enem.GetMovimientos()[habilidad].GetName());
                if (prota.getfuria()!=-1)
                {
                    enem.RecibirDaño(enem, habilidad, prota.getfuria());
                    Console.WriteLine("{0} está furioso, deflecta el ataque y devuelve un {1}% del daño a {2}.", prota.GetName(), prota.GetHechizos()[1].GetModif(), enem.GetName());
                    Console.Write(" Inflinje ");
                    Hud.printColor(3, Convert.ToString(prota.InflingirDaño(habilidad)));
                    Console.Write(" puntos de daño a {0}, con un escudo de ", enem.GetName());
                    Hud.printColor(5, Convert.ToString(enem.GetEscudo()));
                    Console.WriteLine(" puntos que reduce el daño recibido a {0} puntos.\n", enem.RecibirDaño(enem, habilidad));
                    Console.WriteLine("{0} tiene {1} puntos de vida.\n", enem.GetName(), enem.GetVida());
                }

                else { Daño(prota, enem, habilidad); }
            }

        }

        private static void Daño(Personaje receptor, Personaje agresor, int habilidad)
        {
            Console.Write("{0} usa ",agresor.GetName());
            Hud.printColor(3, agresor.GetMovimientos()[habilidad].GetName());
            Console.Write(" e inflinje ");
            Hud.printColor(3, Convert.ToString(agresor.InflingirDaño(habilidad)));
            Console.Write(" puntos de daño a {0}, con un escudo de ", receptor.GetName());
            Hud.printColor(5, Convert.ToString(receptor.GetEscudo()));
            Console.WriteLine(" puntos que reduce el daño recibido a {0} puntos.", receptor.RecibirDaño(agresor, habilidad));
            Console.WriteLine("{0} tiene {1} puntos de vida.\n", receptor.GetName(), receptor.GetVida());
        }

    }
}
