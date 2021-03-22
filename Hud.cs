using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_dungeon
{
    class Hud
    {
        private Position pantalla;
        private const int margen = 10;
        public Hud(int x, int y)
        {
            pantalla = new Position(x, y);
        }
       public void printSkills() { }
    }
}
