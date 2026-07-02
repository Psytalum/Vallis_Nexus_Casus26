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

        public List<Optreden> Favorieten = new List<Optreden>();

        public void VoegFavorietToe(Optreden optreden)
        {
            if (!Favorieten.Contains(optreden))
            {
                Favorieten.Add(optreden);
                Console.WriteLine($"{optreden.Artiest.ArtiestNaam} is toegevoegd aan je favorieten!");
            }
            else
            {
                Console.WriteLine($"{optreden.Artiest.ArtiestNaam} staat al in je favorieten.");
            }
        }

        public void VerwijderFavoriet(Optreden optreden)
        {
            if (Favorieten.Contains(optreden))
            {
                Favorieten.Remove(optreden);
                Console.WriteLine($"{optreden.Artiest.ArtiestNaam} is verwijderd uit je favorieten.");
            }
            else
            {
                Console.WriteLine("Dit optreden staat niet in je favorieten.");
            }
        }
        public string Toegang(string recht) // klassediagram veranderen.
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
