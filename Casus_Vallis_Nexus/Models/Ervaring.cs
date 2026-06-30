using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class Ervaring 
    {
        public string tekst;
        public Bezoeker Bezoeker { get; set; }
        public List<ErvaringOverzicht> ervaringoverzicht = new List<ErvaringOverzicht>();

        public int schema()
        {
            Console.WriteLine("Leeftijd: ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int getal))
            {
            }
            else
            {
                Console.WriteLine("Dat is geen geldig getal.");
            }
            return 0;
            /*
            Console.WriteLine($"Leeftijd: ");
            string leeftijd = Console.ReadLine();
            Console.WriteLine($"idfestivalkaartje: ");
            string idfestivalkaartje = Console.ReadLine();
            return int.Parse(Console.ReadLine());
            */

        }
        public string Opslaan(string melding) // klassediagram veranderen.
        {
            if (tekst != null) 
            {
                melding = "Uw ervaring is opgeslagen.";
            }
            else
            {
                melding = "Uw ervaring was geannuleerd.";
            }
            return melding;
        }
    }
}
