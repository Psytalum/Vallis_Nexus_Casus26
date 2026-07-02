using Casus_Vallis_Nexus.DataAccess;
using Casus_Vallis_Nexus.Models;
using VallisNexusFestival;

namespace Casus_Vallis_Nexus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Homepagina menu = new Homepagina();
            Ervaring ervaringNino = new Ervaring();
            DAL vallis_ervaring_test = new DAL();
            ErvaringOverzicht nieuwSchema = new ErvaringOverzicht(8, 4, 6, "2026 was de beste editie ooit");
            int keuze = menu.Navigatie();

            if (keuze == 3)
            {
                Console.Clear();
                Console.WriteLine(ervaringNino.schema("recht"));
                //Console.WriteLine(nieuwSchema.ErvaringTekst()); dit voerd uit de methode voor ervaringen maar slaat het niet op in de database.
                //Console.WriteLine(ervaringNino.Tekst());
                //Console.WriteLine(ervaringNino.Opslaan("melding"));
                DAL vallis_dal = new DAL(); //slaat de invoer meteen op in de database

                int muziekrating = VraagRating("Muziekrating (1-10): ");
                Console.WriteLine("Beschrijving muziek: ");
                string muziekbeschrijving = Console.ReadLine();

                int consumptierating = VraagRating("Consumptierating (1-10): ");
                Console.WriteLine("Beschrijving consumptie: ");
                string consumptiebeschrijving = Console.ReadLine();

                int festivalviberating = VraagRating("Festivalviberating (1-10): ");
                Console.WriteLine("Beschrijving festivalvibe: ");
                string festivalvibebeschrijving = Console.ReadLine();

                try
                {
                    int ratingnummer = vallis_dal.GetNextRatingnummer();
                    vallis_dal.InsertRating(ratingnummer, muziekrating, consumptierating, festivalviberating,
                        muziekbeschrijving, consumptiebeschrijving, festivalvibebeschrijving);
                    Console.WriteLine("Ervaringen is opgeslagen in de database!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fout: " + ex.Message);
                }
                // functie voor controle rating tussen 1 en 10
                static int VraagRating(string vraag) // static wat deze functie moet samen met de vorige gevoerd worden.
                {
                    int rating;
                    bool geldig = false;

                    do
                    {
                        Console.WriteLine(vraag);
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out rating))
                        {
                            if (rating < 1 || rating > 10)
                            {
                                Console.WriteLine("Vul een getal in tussen 1 en 10.");
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
                    } while (!geldig);

                    return rating;
                }
                menu.Navigatie();
            }
            else if (keuze == 1)


            {
                Plattegrond plattegrond = new Plattegrond(1, "Vallis Nexus Festival");

                plattegrond.VoegLocatieToe(new Podium(1, "Main Stage", "Hoofdpodium voor optredens", "Open"));
                plattegrond.VoegLocatieToe(new Toilet(2, "WC Noord", "Toiletten bij de ingang", "Bezet"));
                plattegrond.VoegLocatieToe(new Foodtruck(3, "Burger Truck", "Burgers en friet", "Open"));

                bool doorgaan = true;

                while (doorgaan)
                {
                    Console.Clear();
                    plattegrond.ToonPlattegrond();

                    Console.WriteLine();
                    Console.Write("Kies een locatie ID (of 0 om af te sluiten): ");

                    int id;
                    bool geldigGetal = int.TryParse(Console.ReadLine(), out id);

                    if (!geldigGetal)
                    {
                        Console.WriteLine("Ongeldige invoer. Druk op een toets om opnieuw te proberen.");
                        Console.ReadKey();
                        continue;
                    }

                    if (id == 0)
                    {
                        doorgaan = false;
                        Console.WriteLine("Programma afgesloten.");
                    }
                    else
                    {
                        Locatie gekozenLocatie = plattegrond.ZoekLocatieOpId(id);

                        if (gekozenLocatie != null)
                        {
                            Console.WriteLine();
                            gekozenLocatie.ToonInformatie();
                        }
                        else
                        {
                            Console.WriteLine("Locatie niet gevonden.");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
