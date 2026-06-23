using Vallis_Nexus_Casus26;

namespace Casus_Vallis_Nexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL Vallis_dal = new DAL();

            try
            {
                Vallis_dal.InsertRating(8.7m);
                Console.WriteLine("Verbinding gelukt! Data ingevoegd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fout: " + ex.Message);
            }

        }
    }
}
