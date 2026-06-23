using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    internal class ErvaringOverzicht
    {
        private int muziekRating;
        private int consumptiesRating;
        private int festivalVibeRating;
        private string beschrijvingVanRating;

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
                    $"Muziek:           {muziekRating}" +
                    $"Consumpties:      {consumptiesRating}" +
                    $"Vibe:             {festivalVibeRating}" +
                    $"beschrijving:     {beschrijvingVanRating}";
        }

    }
}
