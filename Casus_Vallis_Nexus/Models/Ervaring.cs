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

        public int schema(string recht)
        {
            int getal;
            bool geldig = false;
            Console.WriteLine("\t\t\t\t\t\tErvaring delen");
            do
            {
                Console.WriteLine("Leeftijd: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out getal))
                {
                    if (getal >= 100)
                    {
                        Console.WriteLine("U bent te oud voor het festival!");
                        
                    }
                    else
                    {
                        geldig = true;
                    }
                }
                else
                {
                    Console.WriteLine("Dat is geen geldig getal.");
                    
                }

            } while (!geldig); //!geldig = is niet geldig
            Console.WriteLine($"Leeftijd {getal} geaccepteerd.");
            {

                int idfestival;
                bool geldig_idfestival = false;

                do
                {
                    Console.WriteLine("\nidfestival: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out idfestival))
                    {
                        if (idfestival > 0 && idfestival < 5)
                        {
                            recht = "\n\nJe hebt voldoende rechten om de ervaringen van de bezoekers te lezen!" +
                                    "\nWil je de ervaringen van de bezoekers lezen?";

                        }
                        else
                        {
                            geldig = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dat is geen geldig getal.");
                    }
                } while (!geldig); //!geldig betekent is niet geldig

                Console.WriteLine($"idfestival: {idfestival} is geaccepteerd.");
                return 0;
            }
        }
        public string Tekst()
        {
            Console.WriteLine("Type uw ervaring in: ");
            tekst = Console.ReadLine();
            return "";
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
