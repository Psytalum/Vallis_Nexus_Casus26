using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    internal class Bezoeker
    {
        private int idfestivalkaartje;
        public int leeftijd;
        public List<Ervaring> ervaring = new List<Ervaring>();
        public Bezoeker(int idfestivalkaartje)
        {
            this.idfestivalkaartje = idfestivalkaartje;
        }

        public bool Toegang (string recht)
        {
            if (idfestivalkaartje <= 5) 
            {
                recht = "Je hebt rechten om ervaringen van de bezoekers te lezen!";
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
