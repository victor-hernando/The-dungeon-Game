using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_dungeon
{
    struct Position
    {
       public int row;
       public int col;
       public Position (int row, int col)
       {
            this.row = row;
            this.col = col;
       }
       public bool compararPosiciones(int col, int row)
        {
            return Math.Abs(this.col - col) <= 3 && Math.Abs(this.row - row) <= 9;
        }

    }
}
