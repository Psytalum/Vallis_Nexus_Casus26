using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class ErvaringOverzicht
    {
        public int muziekRating;
        public int consumptiesRating;
        public int festivalVibeRating;
        public string beschrijvingVanRating;

        public ErvaringOverzicht(int muziekRating, int consumptiesRating, int festivalVibeRating, string beschrijvingVanRating)
        {
            this.muziekRating = muziekRating;
            this.consumptiesRating = consumptiesRating;
            this.festivalVibeRating = festivalVibeRating;
            this.beschrijvingVanRating = beschrijvingVanRating;
        }

        public string ErvaringTekst()
        {
            return  $"Uw beoordelingen zijn\n" +
                    $"\nMuziek:           {muziekRating}" +
                    $"\nConsumpties:      {consumptiesRating}" +
                    $"\nVibe:             {festivalVibeRating}" +
                    $"\nbeschrijving:     {beschrijvingVanRating}\n";
        }

    }
}
