using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Protagonista:Personaje
    {
        public int numMovimientos;
        public int numHechizos;
        private double turnosEscudo;
        private int furia;
        private double energia;
        private double energiaMaxima;
        private double magia;
        private double magiaMaxima;
        private Hud H = new Hud();
        public Protagonista():base(prota:true)
        {
            nombre = SetAdventurerName();
            vidaMaxima = 100;
            ataque = 30;
            magiaMaxima = 80;
            magia = magiaMaxima;
            iniciativa = 30;
            vida = vidaMaxima;
            escudo = 20;
            escudoModificado = escudo;
            energiaMaxima = 50;
            energia = energiaMaxima;
            turnosEscudo = 0;
            furia = -1;
            numMovimientos = 0;
            numHechizos = 0;
            Habilidades = new List<Movimientos>();
            Hechizos = new List<Movimientos>();
            setMovimientos("Estoque");
            setHechizos("Curar");
        }
        private string SetAdventurerName()
        {
            Console.WriteLine("Escribe el nombre del aventurero: ");
            return Console.ReadLine();
        }
        public void setMovimientos(string nombre)
        {
            StreamReader doc = Resources.OpenFile(nombre);
            numMovimientos++;
            Habilidades.Add(new Movimientos());
            Habilidades[Habilidades.Count - 1].SetName(doc.ReadLine());
            Habilidades[Habilidades.Count - 1].SetDescr(doc.ReadLine());
            Habilidades[Habilidades.Count - 1].SetModif(Convert.ToDouble(doc.ReadLine()));
        }
        public void setHechizos(string nombre)
        {
            StreamReader doc = Resources.OpenFile(nombre);
            numHechizos++;
            Hechizos.Add(new Movimientos());
            Hechizos[Hechizos.Count - 1].SetTipo(doc.ReadLine());
            Hechizos[Hechizos.Count - 1].SetName(doc.ReadLine());
            Hechizos[Hechizos.Count - 1].SetDescr(doc.ReadLine());
            Hechizos[Hechizos.Count - 1].SetModif(Convert.ToDouble(doc.ReadLine()));
            Hechizos[Hechizos.Count - 1].SetCoste(Convert.ToInt32(doc.ReadLine()));
            

        }
        public double UsarPoder(int habilidad)
        {

            if (magia - Hechizos[habilidad].GetCoste() < 0) { return -1; }
            else { magia -= Hechizos[habilidad].GetCoste(); }

            if (Hechizos[habilidad].GetTipo() == "Curar") curar(habilidad);
            else if (Hechizos[habilidad].GetTipo() == "Furia") setfuria(habilidad);
            else if (Hechizos[habilidad].GetTipo() == "Escudo") ponerEscudo(habilidad);
            return magia;
        }

        private void curar(int hab)
        {
            vida += Hechizos[hab].GetModif();
            Console.Write("{0} se cura ", nombre);
            H.printColor(1, Convert.ToString(Hechizos[0].GetModif()));
        }
        public void ponerEscudo(int hab)
        {
            escudoModificado = escudo + escudo * Hechizos[hab].GetModif() / 100;
            turnosEscudo = 3;
            Console.Write("{0} se pone el escudo y aumenta un {1}% su defensa. Defensa actual: ", nombre, Hechizos[hab].GetModif());
            H.printColor(3, Convert.ToString(escudoModificado));

        }
        public void setfuria(int hab)
        {
            furia = hab;
        }
        public void resetFuria()
        {
            furia = -1;
        }
        public int getfuria()
        {
            return furia;
        }
        public void ResetEstado()
        {
            if (turnosEscudo > 0)
            {
                turnosEscudo--;
                if (turnosEscudo <= 0) { escudoModificado = escudo; }
            }
            if (vida > vidaMaxima) { vida = vidaMaxima; }
            resetFuria();
            magia += 5;
            if (magia > magiaMaxima) { magia = magiaMaxima; }
        }
        public double GetMagia()
        {
            return magia;
        }
    }
}
