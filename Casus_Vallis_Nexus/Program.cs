using Casus_Vallis_Nexus.Models;
using Vallis_Nexus_Casus26.DataAccess;

namespace Casus_Vallis_Nexus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Homepagina menu = new Homepagina();
            Ervaring ervaringNino = new Ervaring();
            ErvaringOverzicht nieuwSchema = new ErvaringOverzicht(8,4,6,"2026 was beter dan de vorige edities maar de prijs is nog steeds hoog!");
            int keuze = menu.Navigatie();
            if (keuze == 3) 
            {
                Console.Clear();
                Console.WriteLine(ervaringNino.schema());
                Console.WriteLine(nieuwSchema.ErvaringTekst());
            }


            DAL vallis_dal = new DAL();

            try
            {
                vallis_dal.InsertRating(8.7m);
                Console.WriteLine("Verbinding gelukt! Data ingevoegd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fout: " + ex.Message);
            }

        }
    }
}
