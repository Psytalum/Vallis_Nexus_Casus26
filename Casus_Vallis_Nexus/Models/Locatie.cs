using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Casus_Vallis_Nexus.Models
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public string Naam { get; set; }
        public string Informatie { get; set; }
        public string Status { get; set; }

        public Locatie(int locatieId, string naam, string informatie, string status)
        {
            LocatieId = locatieId;
            Naam = naam;
            Informatie = informatie;
            Status = status;
        }

        public virtual void ToonInformatie()
        {
            Console.WriteLine($"Naam: {Naam}");
            Console.WriteLine($"Informatie: {Informatie}");
            Console.WriteLine($"Status: {Status}");
        }
    }
}
