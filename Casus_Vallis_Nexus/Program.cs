using System;
using System.Collections.Generic;
using System.Linq; 
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
            Bezoeker ingelogdeBezoeker = new Bezoeker();

            // Line-up
            List<Optreden> lineUp = new List<Optreden>
            {
                new Optreden(1, "14:00", "Mainstage", new Artiest(1, "Twenty One Pilots", "Alt Rock")),
                new Optreden(2, "16:00", "Mainstage", new Artiest(2, "Billy Eyelash", "Pop")),
                new Optreden(3, "18:00", "Techno Tent", new Artiest(3, "Raxeller", "Techno")),
                new Optreden(4, "20:00", "Mainstage", new Artiest(4, "Rianna", "Pop"))
            };

            Ervaring ervaringNino = new Ervaring();
            DAL vallis_ervaring_test = new DAL();
            ErvaringOverzicht nieuwSchema = new ErvaringOverzicht(8, 4, 6, "2026 was de beste editie ooit");

            // hoofdmenu optie loop
            while (true)
            {
                Console.Clear();
                int keuze = menu.Navigatie();

                if (keuze == 3)
                {
                    Console.Clear();
                    Console.WriteLine(ervaringNino.schema("recht"));
                    DAL vallis_dal = new DAL();

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
                    int VraagRating(string vraag)
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

                    Console.WriteLine("\nDruk op een toets om terug te gaan naar het hoofdmenu...");
                    Console.ReadKey();
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
                                Console.ReadKey(); // Wacht op de gebruiker
                            }
                            else
                            {
                                Console.WriteLine("Locatie niet gevonden.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else if (keuze == 2)
                {
                    Console.Clear();
                    Console.WriteLine("--- Over Vallis Nexus Festival ---");

                   
                    Console.WriteLine("Het Vallis Nexus Festival is een kleinschalig, vrij toegankelijk muziekfestival in Zuid-Limburg.");
                    Console.WriteLine("Het biedt bezoekers een laagdrempelige plek om samen te genieten van live muziek,");
                    Console.WriteLine("lokale artiesten, foodtrucks en een gezellige festivalsfeer.\n");

                    
                    Console.WriteLine("Onze missie:");
                    Console.WriteLine("De missie van Vallis Nexus is om cultuur en muziek bereikbaar te maken voor iedereen.");
                    Console.WriteLine("Door gratis toegang en een open karakter wil het festival mensen uit de regio");
                    Console.WriteLine("samenbrengen en lokaal talent een podium geven.");

                    Console.WriteLine("\n[Druk op een toets om terug te gaan naar het menu]");
                    Console.ReadKey();
                }
                else if (keuze == 4)
                {
                    bool inLineUp = true;
                    while (inLineUp)
                    {
                        Console.Clear();
                        Console.WriteLine("=== PROGRAMMA / LINE-UP ===");
                        foreach (var optreden in lineUp)
                        {
                            optreden.ToonDetails();
                        }

                        Console.WriteLine("\n[OptredenID] = Toevoegen aan favorieten | [0] = Afsluiten");
                        Console.Write("Keuze: ");

                        if (int.TryParse(Console.ReadLine(), out int invoer))
                        {
                            if (invoer == 0)
                            {
                                inLineUp = false;
                            }
                            else
                            {
                                Optreden gekozenOptreden = lineUp.FirstOrDefault(o => o.OptredenID == invoer);
                                if (gekozenOptreden != null)
                                {
                                    ingelogdeBezoeker.VoegFavorietToe(gekozenOptreden);
                                }
                                else
                                {
                                    Console.WriteLine("Optreden ID niet gevonden.");
                                }
                                Console.WriteLine("Druk op een toets om verder te gaan...");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else if (keuze == 5)
                {
                    bool inFavorieten = true;
                    while (inFavorieten)
                    {
                        Console.Clear();
                        Console.WriteLine("=== MIJN FAVORIETEN ===");

                        if (ingelogdeBezoeker.Favorieten.Count == 0)
                        {
                            Console.WriteLine("Je hebt nog geen favorieten toegevoegd.");
                        }
                        else
                        {
                            foreach (var fav in ingelogdeBezoeker.Favorieten)
                            {
                                fav.ToonDetails();
                            }
                        }

                        Console.WriteLine("\n[OptredenID] = Verwijderen uit favorieten | [0] = Afsluiten");
                        Console.Write("Keuze: ");

                        if (int.TryParse(Console.ReadLine(), out int invoer))
                        {
                            if (invoer == 0)
                            {
                                inFavorieten = false;
                            }
                            else
                            {
                                Optreden teVerwijderen = ingelogdeBezoeker.Favorieten.FirstOrDefault(o => o.OptredenID == invoer);
                                if (teVerwijderen != null)
                                {
                                    ingelogdeBezoeker.VerwijderFavoriet(teVerwijderen);
                                }
                                else
                                {
                                    Console.WriteLine("Dit optreden staat niet in je lijst.");
                                }
                                Console.WriteLine("Druk op een toets om verder te gaan...");
                                Console.ReadKey();
                            }
                        }
                    }
                }
            } 
        } 
    } 
} 