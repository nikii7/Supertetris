using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supertetris
{
    class Schwierigkeitsgrad
    {
        public int schnelligkeit { get; set; }


        public void leicht() {

            schnelligkeit += 1;
        }

        public void mittel()
        {
            schnelligkeit += 2;
        }

        public void schwierig()
        {
            schnelligkeit += 3;
        }
    }
}
