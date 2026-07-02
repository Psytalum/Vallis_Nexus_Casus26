using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class Homepagina


    {

        public int Navigatie()
        {
            Console.WriteLine($"\t\t\t\t\t\tHomepagina");
            Console.WriteLine($"\nWaar wil je naar toe? \n( Type het nummer in!)\n");
            Console.WriteLine("[1] Festival plattegrond");
            Console.WriteLine("[2] Festival informatie");
            Console.WriteLine("[3] Ervaring delen / Lezen");
            Console.WriteLine("[4] Line-up bekijken");
            Console.WriteLine("[5] Mijn Favoriete Line-up");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int keuze))
            {
                return keuze;
            }

            Console.WriteLine("Ongeldige invoer, probeer opnieuw.");
            return 0;
        }
    }
}

