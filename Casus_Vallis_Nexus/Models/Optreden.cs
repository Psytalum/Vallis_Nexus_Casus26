using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class Optreden
    {
        public int OptredenID { get; set; }
        public string Tijdstip { get; set; }
        public string Podium { get; set; }
        public Artiest Artiest { get; set; } // Koppeling met Artiest object (uit je DD)

        public Optreden(int id, string tijd, string podium, Artiest artiest)
        {
            OptredenID = id;
            Tijdstip = tijd;
            Podium = podium;
            Artiest = artiest;
        }

        // Methode om makkelijk de tekst in het menu te printen
        public void ToonDetails()
        {
            Console.WriteLine($"[{OptredenID}] {Artiest.ArtiestNaam} ({Artiest.Genre}) - {Podium} om {Tijdstip}");
        }
    }
}