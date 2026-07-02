using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Casus_Vallis_Nexus.Models
{
    public class Plattegrond
    {
        public int PlattegrondId { get; set; }
        public string TerreinNaam { get; set; }
        public List<Locatie> Locaties { get; set; }

        public Plattegrond(int plattegrondId, string terreinNaam)
        {
            PlattegrondId = plattegrondId;
            TerreinNaam = terreinNaam;
            Locaties = new List<Locatie>();
        }

        public void VoegLocatieToe(Locatie locatie)
        {
            Locaties.Add(locatie);
        }

        public void ToonPlattegrond()
        {
            Console.WriteLine($"=== Plattegrond van {TerreinNaam} ===");

            foreach (Locatie locatie in Locaties)
            {
                Console.WriteLine($"{locatie.LocatieId} - {locatie.Naam} ({locatie.GetType().Name})");
            }
        }

        public Locatie ZoekLocatieOpId(int id)
        {
            foreach (Locatie locatie in Locaties)
            {
                if (locatie.LocatieId == id)
                {
                    return locatie;
                }
            }

            return null;
        }
    }
}