using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Personaje
    {
        
        protected string nombre;
        protected double vida;
        protected double vidaMaxima;
        protected double ataque;
        protected double escudo;
        protected double escudoModificado;
        protected double iniciativa;
        protected List<Movimientos> Habilidades;
        protected List<Movimientos> Hechizos;

        public Personaje(string nombre = " ",bool prota=false)
        {
            if (!prota) NuevoEnemigo(nombre);
        }
       private void NuevoEnemigo(string archivo)
        {
            StreamReader doc = Resources.OpenFile(archivo);
            nombre = doc.ReadLine();
            vida = Convert.ToDouble(doc.ReadLine());
            ataque = Convert.ToDouble(doc.ReadLine());
            escudo = Convert.ToDouble(doc.ReadLine());
            iniciativa = Convert.ToDouble(doc.ReadLine());
            Habilidades = new List<Movimientos>(2);
            escudoModificado = escudo;
            for (int i = 0; i < 2; i++)
            {
                Habilidades.Add(new Movimientos());
            }
            for (int i =0; i < 2; i++)
            {
                Habilidades[i].SetName( doc.ReadLine());
                Habilidades[i].SetModif(Convert.ToDouble(doc.ReadLine()));
            }
        }
        public double RecibirDaño(Personaje agresor, int habilidad, double furia = -1)
        {
            double daño;

            if (furia<0) { daño = agresor.InflingirDaño(habilidad) - agresor.InflingirDaño(habilidad) * (escudo / 100); }
            else { daño = furia * ((agresor.InflingirDaño(habilidad) - agresor.InflingirDaño(habilidad) * (escudo / 100)))/100; }
            vida -= daño;

            return daño;
        }

        public double InflingirDaño(int tecnica)
            {
            return ataque*Habilidades[tecnica].GetModif();
        }
                
        public string GetName()
            {
            return nombre;
        }

        public double GetVida()
        {
            return vida;
        }
        public double GetIniciativa()
        {
            return iniciativa;
        }
        public double GetEscudo()
        {
            return escudoModificado;
        }
        public List<Movimientos> GetMovimientos()
        {
            return Habilidades;
        }
        public List<Movimientos> GetHechizos()
        {
            return Hechizos;
        }
        
    }
}

