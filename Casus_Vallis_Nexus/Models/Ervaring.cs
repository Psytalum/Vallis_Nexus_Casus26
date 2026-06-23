using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    internal class Ervaring
    {
        public string tekst;
        public Bezoeker bezoeker;
        public List<ErvaringOverzicht> ervaringoverzicht = new List<ErvaringOverzicht>();

        public bool Opslaan(string melding) // Deze controle is niet goed!
        {
            melding = "Uw ervaring is opgeslagen!";
            if (tekst != null) 
            {
                Console.WriteLine($"{melding}");
                return true;
            }
            else 
            {
                Console.WriteLine($"Uw ervaring was geannuleerd");
                return false;
            }
        }
    }
}
