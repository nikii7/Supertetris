using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supertetris
{
    class Schwierigkeitsgrad
    {
        public int Schnelligkeit { get; set; }


        public void Leicht() {

            Schnelligkeit += 1;
        }

        public void Mittel()
        {
            Schnelligkeit += 2;
        }

        public void Schwierig()
        {
            Schnelligkeit += 3;
        }
    }
}
