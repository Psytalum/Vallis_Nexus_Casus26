using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Casus_Vallis_Nexus.Models
{
    public class Bezoeker
    {
        public int idfestivalkaartje;
        public int leeftijd;
        public List<Ervaring> ervaring = new List<Ervaring>();
       
        public string Toegang (string recht) // klassediagram veranderen.
        {
            if (idfestivalkaartje > 0 && idfestivalkaartje <= 5) 
            {
                recht = "\n\nJe hebt voldoende rechten om de ervaringen van de bezoekers te lezen!" +
                        "  \nWil je de ervaringen van de bezoekers lezen?";
                
            }
            else 
            {
                recht = "Dank je wel voor uw ervaring over het feestival.";
            }
            return recht;
        }

    }
}
