using System;
using AirBNBDataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBBL;

namespace AirBNBConsole
{
    class Program
    {
        static AirBNBDataLayer.Context.AirBNBContext airBNBContext;

        [STAThread]
        static void Main(string[] args)
        {
            new Program().Main();
        }
        private Program()
        {
            anvandarController = new AnvandarController();
            bostadsAnnonsController = new BostadsAnnonsController();
            bostadController = new BostadController();
        }
        private void Main()
        {

            airBNBContext = new AirBNBDataLayer.Context.AirBNBContext();
            //airBNBContext.seed();
            Console.WriteLine("Välkommen till AirBNBRAED");
            while (true)
            {
                //try
                //{
                Console.WriteLine("1. Logga in ");
                Console.WriteLine("2. Skapa Användare ");
                Console.WriteLine("Välj menyalternativ: ");
                int menuSelection;
                while (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("\nMata gärna in önskat menyval som en siffra mellan 1-2!");
                }
                switch (menuSelection)
                {
                    case 1:
                        bool a = true;
                        while (a == true)
                        {
                            Console.Clear();
                            if (LoggaIn())
                            {
                                MainMenu();
                            }
                            else
                            {
                                Console.WriteLine("Inloggningen misslyckades, försök igen!");
                                string svar = Console.ReadLine();
                                if (svar == "x")
                                {
                                    a = false;
                                }
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        SkapaAnvandare();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                }
                //}
               /* catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }*/
            }
        }
        private void MainMenu()
        {
            bool keepAlive = true;
            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine("Du är nu inloggad som {0}.", anvandarController.Inloggad.Namn);
                Console.WriteLine("Välkommen till AirBNB: \n");
                Console.WriteLine("1. Skapa Annons ");
                Console.WriteLine("2. Ta Bort och Redigera Annons ");
                Console.WriteLine("3. Se Anonnser och Boka ");
                Console.WriteLine("4. Avbryt Bokning  ");
                Console.WriteLine("5.  Logga ut\n");
                Console.WriteLine("Välj menyalternativ: ");
                int menuSelection;
                while (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("\nMata gärna in önskat menyval som en siffra mellan 1-5!");
                }
                switch (menuSelection)
                {
                    case 1:
                        Console.Clear();
                        SkapaAnnons();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        // Ta bort eller redigera en existerande annons för användaren
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        VisaAllaAnnonser();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 5:
                        keepAlive = false;
                        Console.Clear();
                        break;
                }
            }
        }
        private bool LoggaIn()
        {
            Console.WriteLine("Skriv in din email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Skriv in dit lösenord: ");
            string losenord = Console.ReadLine();
            return anvandarController.LoggaInAnvandare(Email, losenord);
        }
        private void SkapaAnvandare()
        {
            bool a = true;
            while (a == true)
            {
                Console.WriteLine("Skriv in din email: ");
                string Epost = Console.ReadLine();
                if (Epost == "x")
                {
                    a = false;
                }
                if (anvandarController.kollaEpost(Epost))
                {
                    Console.WriteLine("Skriv in det lösenord du vill ha: ");
                    string Losenord = Console.ReadLine();
                    if (Losenord == "x")
                    {
                        a = false;
                    }
                    Console.WriteLine("Skriv in ditt namn: ");
                    string Namn = Console.ReadLine();
                    if (Namn == "x")
                    {
                        a = false;
                    }
                    anvandarController.AnvandarSkapning(Namn, Epost, Losenord);
                    a = false;
                }

                else
                {
                    Console.WriteLine("\nEmailen fanns redan, testa att använda en annan");
                }
            }

        }



        private void SkapaAnnons()
        {
            bool alive = true;
            while (alive == true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------\n");
                {
                    Console.WriteLine("Skriv in adress för bostaden du vill skapa annons för: ");
                    string adress = Console.ReadLine();
                    {
                        Console.WriteLine("Skriv in stad för bostaden du vill skapa annons för: ");
                        string stad = Console.ReadLine();
                        Bostad bostad = bostadController.BostadSkapning(adress, stad, anvandarController.Inloggad);

                        Console.WriteLine("Ange pris per natt: ");
                        int ppn;
                        while (!int.TryParse(Console.ReadLine(), out ppn))
                        {
                            Console.WriteLine("\nPriset anges endast med heltal!");
                            Console.WriteLine("\nSkriv in pris per natt: ");
                        }
                        Console.WriteLine("Skriv en beskrivning för annonsen: ");
                        string beskrivning = Console.ReadLine();
                        Console.WriteLine("Ange antal rum som uthyres: ");
                        int antalRum;
                        while (!int.TryParse(Console.ReadLine(), out antalRum))
                        {
                            Console.WriteLine("\nAntal rum anges endast med heltal!");
                            Console.WriteLine("\nSkriv in antalet rum som uthyres: ");
                        }
                        Console.WriteLine("WIFI tillgång? svara Y/N ");
                        string wifiSvar = Console.ReadLine().ToUpper();
                        bool wifi = false;
                        while (wifiSvar != "Y" && wifiSvar != "N")
                        {
                            Console.WriteLine("\nSvara antigen med Y för ja eller N för nej!");
                            Console.WriteLine("\nFinns det WIFI tillgång i bostaden? Y/N");
                            wifiSvar = Console.ReadLine().ToUpper();
                        }
                        if (wifiSvar == "N")
                        {
                            wifi = false;
                        }
                        else if (wifiSvar == "Y")
                        {
                            wifi = true;
                        }
                        Console.WriteLine("Parkering tillgänglig? svara Y/N ");
                        string pSvar = Console.ReadLine().ToUpper();
                        bool parkering = false;
                        while (pSvar != "Y" && pSvar != "N")
                        {
                            Console.WriteLine("\nSvara antigen med Y för ja eller N för nej!");
                            Console.WriteLine("\nFinns det parkering tillgänglig med bostaden? Y/N");
                            wifiSvar = Console.ReadLine().ToUpper();
                        }
                        if (pSvar == "N")
                        {
                            parkering = false;
                        }
                        else if (pSvar == "Y")
                        {
                            parkering = true;
                        }
                        Console.WriteLine("Är husdjur tillåtna? svara Y/N ");
                        string husdjurSvar = Console.ReadLine().ToUpper();
                        bool husdjur = false;
                        while (husdjurSvar != "Y" && husdjurSvar != "N")
                        {
                            Console.WriteLine("\nSvara antigen med Y för ja eller N för nej!");
                            Console.WriteLine("\nÄr husdjur tillåtna i bostaden? Y/N");
                            wifiSvar = Console.ReadLine().ToUpper();
                        }
                        if (husdjurSvar == "N")
                        {
                            husdjur = false;
                        }
                        else if (husdjurSvar == "Y")
                        {
                            husdjur = true;
                        }
                        Console.WriteLine("Är rökning tillåten i bostaden? svara Y/N ");
                        string rokningSvar = Console.ReadLine().ToUpper();
                        bool rokning = false;
                        while (rokningSvar != "Y" && rokningSvar != "N")
                        {
                            Console.WriteLine("\nSvara antigen med Y för ja eller N för nej!");
                            Console.WriteLine("\nÄr husdjur tillåtna i bostaden? Y/N");
                            wifiSvar = Console.ReadLine().ToUpper();
                        }
                        if (rokningSvar == "N")
                        {
                            rokning = false;
                        }
                        else if (rokningSvar == "Y")
                        {
                            rokning = true;
                        }
                        bool status = true;
                        int annonsID = bostadsAnnonsController.AnnonsSkapning(anvandarController.Inloggad, bostad, ppn, beskrivning, antalRum, wifi, parkering, husdjur, rokning, status);
                        Console.WriteLine("Annonsen är skapad, dit annons-ID är: " + annonsID);
                    }
                }
            }
        }
    
        private void VisaAllaAnnonser()
        {
            IEnumerable<BostadsAnnons> annonser = bostadsAnnonsController.HamtaAllaAnnonser();
            const string format = "\n{0, -20} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10} | {7, -10} | {8, -10} | \n{9, -500}";
            foreach (BostadsAnnons annons in annonser)
            {
                Console.WriteLine(format, /*annons.Bostad.Adress,*/ annons.PPN.ToString() ,annons.AntalRum.ToString() , annons.WIFI , annons.Parkering , annons.Husdjur , annons.Rokning , annons.Status , annons.Beskrivning); ;
            };
        }

       /* private void TaBortAnnons()
        {
            airBNB.AnnonsBorttagning(annonsID);
        }
        private void RedigeraAnnons()
        {
            airBNB.AnnonsRedigering(annonsID, ppn, beskrivning, antalRum, wifi, parkering, husdjur);
        }
        private void BokaBostad()
        {
            airBNB.BostadsBokning(annonsID, antalpersoner, startTid, slutTid );
        }
        private void AvbrytBokning()
        {
            airBNB.BokningsAvbrytning(bokningsID);
        } */
        private AnvandarController anvandarController;
        private BostadController bostadController;
        private BostadsAnnonsController bostadsAnnonsController;
    }

}
