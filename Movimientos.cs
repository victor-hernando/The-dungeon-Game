using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Movimientos
    {
        private string nombre;
        private string descripcion;
        private string tipo;
        private double modificador;
        private int coste;


        public Movimientos()
        {

        }

        public void SetName(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetName()
        {
            return nombre;
        }

        public void SetCoste(int precio)
        {
            coste = precio;
        }

        public int GetCoste()
        {
            return coste;
        }

        public void SetModif(double modif)
        {
            this.modificador = modif;
        }

        public double GetModif()
        {
            return modificador;
        }

        public void SetDescr(string descr)
        {
            descripcion = descr;
        }

        public string GetDescr()
        {
            return descripcion;
        }
        public void SetTipo(string tipo)
        {
            this.tipo = tipo;
        }
        public string GetTipo()
        {
            return tipo;
        }
    }
}
