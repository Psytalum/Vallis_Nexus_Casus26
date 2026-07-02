using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus_Vallis_Nexus.Models
{
    public class Podium : Locatie
    {
        public Podium(int id, string naam, string info, string status)
            : base(id, naam, info, status)
        {
        }
    }
}