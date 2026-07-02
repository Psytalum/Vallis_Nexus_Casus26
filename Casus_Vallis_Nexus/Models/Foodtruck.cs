using Casus_Vallis_Nexus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexusFestival
{
    public class Foodtruck : Locatie
    {
        public Foodtruck(int id, string naam, string info, string status)
            : base(id, naam, info, status)
        {
        }
    }
}