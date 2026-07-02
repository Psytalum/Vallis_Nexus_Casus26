using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class Artiest
    {
        public int ArtiestID { get; set; }
        public string ArtiestNaam { get; set; }
        public string Genre { get; set; }

        public Artiest(int id, string naam, string genre)
        {
            ArtiestID = id;
            ArtiestNaam = naam;
            Genre = genre;
        }
    }
}