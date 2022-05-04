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
            reviewController = new ReviewController();
            bokningController = new BokningController();
        }
        private void Main()
        {
            airBNBContext = new AirBNBDataLayer.Context.AirBNBContext();
            Update();
            Console.WriteLine("Välkommen till AirBNBRAED");
            while (true)
            {
                try
                {
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
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
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
                Console.WriteLine("-------------------------------------------Annonser---------------------------------------");
                Console.WriteLine("1. Skapa Annons ");
                Console.WriteLine("2. Ta Bort annons ");
                Console.WriteLine("3. Redigera annons ");
                Console.WriteLine("4. Se Alla Anonnser");
                Console.WriteLine("5. Se annonser sorterat");
                Console.WriteLine("-------------------------------------------Bokningar---------------------------------------");
                Console.WriteLine("6. Skapa bokning");
                Console.WriteLine("7. Avbryt Bokning  ");
                Console.WriteLine("8.Lista bokningar");
                Console.WriteLine("-------------------------------------------Recensioner---------------------------------------");
                Console.WriteLine("9. Skapa recension");
                Console.WriteLine("10. Ta bort review");
                Console.WriteLine("11. Visa recensioner och betyg");
                Console.WriteLine("-------------------------------------------Övrigt---------------------------------------");
                Console.WriteLine("12. Logga ut");
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
                        TaBortAnnons();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        RedigeraAnnons();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        VisaAllaAnnonser();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        FiltreraAnnonser();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        SkapaBokning();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        TaBortBokning();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        VisaRelevantaBokningar();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        SkapaReview();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.Clear();
                        TaBortReview();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 11:
                        Console.Clear();
                        VisaAllaReviews();
                        Console.WriteLine("\nTryck Enter för att backa till menyn..");
                        Console.ReadLine();
                        break;
                    case 12:
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
        Console.WriteLine("----------------------------------------------------------------------------------\n");
        Console.WriteLine("Skriv in adress för bostaden du vill skapa annons för: ");
        string adress = Console.ReadLine();                
            Console.WriteLine("Skriv in stad för bostaden du vill skapa annons för: ");
            string stad = Console.ReadLine();
            Bostad bostad = bostadController.BostadSkapning(adress, stad, anvandarController.Inloggad);
            anvandarController.LaggTillNyBostadIListan(bostad, anvandarController.Inloggad);
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
                pSvar = Console.ReadLine().ToUpper();
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
                husdjurSvar = Console.ReadLine().ToUpper();
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
                rokningSvar = Console.ReadLine().ToUpper();
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
            BostadsAnnons annons = bostadsAnnonsController.AnnonsSkapning( ppn, beskrivning, antalRum, wifi, parkering, husdjur, rokning, status, bostad);
            bostadController.LaggTillAnnonsILista(annons, bostad);
            Console.WriteLine("Annonsen är skapad, dit annons-ID är: " + annons.BostadsAnnonsID);
        }
        private void VisaAllaAnnonser()
        {
            List<BostadsAnnons> annonser = bostadsAnnonsController.HamtaAllaAnnonser();
            foreach(BostadsAnnons annons in annonser)
            {
                if(annons.Status == true)
                {
                Console.WriteLine("Address: " + bostadController.HamtaSpecifikBostad(annons.BostadID).Adress + " Pris per natt: " + annons.PPN.ToString() + " Antal rum: " + annons.AntalRum.ToString() + "\n\r" + " Finns WIFI: " + annons.WIFI + " Finns Parkering: " + annons.Parkering + " Får man ha Husdjur: " + annons.Husdjur + " Får man röka: " + annons.Rokning + "\n\r" + " Beskrivning: " + annons.Beskrivning);
                Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }
        private void TaBortAnnons()
        {
            Console.WriteLine("----------------------------------------------------------------------------------\nAnge annons-ID för annonsen du önskar ta bort:");
            int annonsID;
            while (!int.TryParse(Console.ReadLine(), out annonsID))
            {
                Console.WriteLine("\nAnnons-ID anges endast med heltal!");
                Console.WriteLine("\nAnge annons-ID: ");
            }
            BostadsAnnons annons = bostadsAnnonsController.HamtaAnnons(annonsID);
            if(bostadController.KollaOmAnnonsÄgsAvInloggad(annons, anvandarController.Inloggad ) && annons.Status == true)
            {
                if (bostadsAnnonsController.AnnonsBorttagning(annonsID))
                {
                    Console.WriteLine("Annonsen är nu borttagen");
                }
            }
            else
            {
                Console.WriteLine("Du har ingen aktiv annons med angivet ID!");
            }
        }
        private void RedigeraAnnons()
        {
            Console.WriteLine("----------------------------------------------------------------------------------\n\nAnge annons-ID för annonsen som du önskar redigera: ");
            int annonsID;
            while (!int.TryParse(Console.ReadLine(), out annonsID))
            {
                Console.WriteLine("\nAnnons-ID betstår endast av siffror!");
                Console.WriteLine("\nSkriv in annons-ID: ");
            }
            if (bostadsAnnonsController.KollaAnnons(annonsID))
            {
                BostadsAnnons gammalAnnons = bostadsAnnonsController.HamtaAnnons(annonsID);
                if (bostadController.KollaOmAnnonsÄgsAvInloggad(gammalAnnons, anvandarController.Inloggad) && gammalAnnons.Status == true)
                {
                    Console.WriteLine("Ange nytt pris per natt eller X för att skippa:"); 
                    string svarPPN = Console.ReadLine().ToUpper();
                    int nyttPPN;
                    if (svarPPN == "X")
                    {
                        nyttPPN = gammalAnnons.PPN;
                    }
                    else
                    {
                        int answerPPN;
                        while (!int.TryParse(svarPPN, out answerPPN))
                        {
                            Console.WriteLine("\nAnge gärna önskat nytt pris per natt i siffror!");
                            svarPPN = Console.ReadLine();
                        }
                        nyttPPN = answerPPN;
                    }
                    Console.WriteLine("Skriv en ny beskrivning eller X för att skippa:"); 
                    string svarBeskrivning = Console.ReadLine().ToUpper();
                    string nyBeskrivning;
                    if (svarBeskrivning == "X")
                    {
                        nyBeskrivning = gammalAnnons.Beskrivning;
                    }
                    else
                    {
                        nyBeskrivning = svarBeskrivning;
                    }
                    Console.WriteLine("Ange nytt antal rum eller X för att skippa:"); 
                    string svarAntalRum = Console.ReadLine().ToUpper();
                    int nyttAntalRum;
                    if (svarAntalRum == "X")
                    {
                        nyttAntalRum = gammalAnnons.AntalRum;
                    }
                    else
                    {
                        int answerAntalRum;
                        while (!int.TryParse(svarAntalRum, out answerAntalRum))
                        {
                            Console.WriteLine("\nAnge gärna önskat nytt pris per natt i siffror!");
                            svarAntalRum = Console.ReadLine();
                        }
                        nyttAntalRum = answerAntalRum;
                    }
                    Console.WriteLine("Y/N för tillgång till WIFI eller X för att skippa:"); 
                    string svarWIFI = Console.ReadLine().ToUpper();
                    bool wifiStatus = gammalAnnons.WIFI;
                    while (svarWIFI != "Y" && svarWIFI != "N" && svarWIFI != "X")
                    {
                        Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                        Console.WriteLine("\nFinns det WIFI tillgång i bostaden? Y/N eller vill du skippa? X");
                        svarWIFI = Console.ReadLine().ToUpper();
                    }
                    if (svarWIFI == "X")
                    {
                        wifiStatus = gammalAnnons.WIFI;
                    }
                    else if (svarWIFI == "N")
                    {
                        wifiStatus = false;
                    }
                    else if (svarWIFI == "Y")
                    {
                        wifiStatus = true;
                    }
                    Console.WriteLine("Y/N för tillgång till parkering eller X för att skippa:"); 
                    string svarParkering = Console.ReadLine().ToUpper();
                    bool parkeringStatus = gammalAnnons.Parkering;
                    while (svarParkering != "Y" && svarParkering != "N" && svarParkering != "X")
                    {
                        Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                        Console.WriteLine("\nFinns det tillgång till parkering? Y/N eller vill du skippa? X");
                        svarParkering = Console.ReadLine().ToUpper();
                    }
                    if (svarParkering == "X")
                    {
                        parkeringStatus = gammalAnnons.Parkering;
                    }
                    else if (svarParkering == "N")
                    {
                        parkeringStatus = false;
                    }
                    else if (svarParkering == "Y")
                    {
                        parkeringStatus = true;
                    }
                    Console.WriteLine("Y/N för husdjur eller X för att skippa:"); 
                    string svarHusdjur = Console.ReadLine().ToUpper();
                    bool husdjurStatus = gammalAnnons.Husdjur;
                    while (svarHusdjur != "Y" && svarHusdjur != "N" && svarHusdjur != "X")
                    {
                        Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                        Console.WriteLine("\nÄr husdjur tillåtna i bostaden? Y/N eller vill du skippa? X");
                        svarHusdjur = Console.ReadLine().ToUpper();
                    }
                    if (svarHusdjur == "X")
                    {
                        husdjurStatus = gammalAnnons.Husdjur;
                    }
                    else if (svarHusdjur == "N")
                    {
                        husdjurStatus = false;
                    }
                    else if (svarHusdjur == "Y")
                    {
                        husdjurStatus = true;
                    }
                    Console.WriteLine("Y/N för rökning eller X för att skippa:"); 
                    string svarRokning = Console.ReadLine().ToUpper();
                    bool rokningStatus = gammalAnnons.Rokning;
                    while (svarRokning != "Y" && svarRokning != "N" && svarRokning != "X")
                    {
                        Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                        Console.WriteLine("\nÄr rökning tillåten i bostaden? Y/N eller vill du skippa? X");
                        svarRokning = Console.ReadLine().ToUpper();
                    }
                    if (svarRokning == "X")
                    {
                        rokningStatus = gammalAnnons.Rokning;
                    }
                    else if (svarRokning == "N")
                    {
                        rokningStatus = false;
                    }
                    else if (svarRokning == "Y")
                    {
                        rokningStatus = true;
                    }
                    if(nyttPPN == gammalAnnons.PPN && nyBeskrivning == gammalAnnons.Beskrivning && nyttAntalRum == gammalAnnons.AntalRum && wifiStatus == gammalAnnons.WIFI && parkeringStatus == gammalAnnons.Parkering && husdjurStatus == gammalAnnons.Husdjur && rokningStatus == gammalAnnons.Rokning)
                    {
                        Console.WriteLine("Inget ändrades och därför så har inte annonsen uppdaterats");
                    }
                    else
                    {
                        Bostad b = bostadController.HamtaSpecifikBostad(gammalAnnons.BostadID);
                        int NyttannonsID = bostadsAnnonsController.AnnonsSkapning(nyttPPN, nyBeskrivning, nyttAntalRum, wifiStatus, parkeringStatus, husdjurStatus, rokningStatus, gammalAnnons.Status, b).BostadsAnnonsID;
                        bostadsAnnonsController.AnnonsBorttagning(gammalAnnons.BostadsAnnonsID);
                        Console.WriteLine("Annonsen är uppdaterad, ditt nya annons-ID är: " + NyttannonsID);
                    }
                }
                else
                {
                    Console.WriteLine("Du har ingen aktiv annons med angivet ID!");
                }
            }
        }
        private void SkapaReview()
        {
            Console.WriteLine("----------------------------------------------------------------------------------\nAnge Bostads-ID för bostaden du önskar recensera:");
            int bostadsID;
            while (!int.TryParse(Console.ReadLine(), out bostadsID))
            {
                Console.WriteLine("\nBostads-ID anges endast med heltal!");
                Console.WriteLine("\nAnge Bostads-ID: ");
            }
            if(bostadController.KollaBostad(bostadsID))
            {
                Bostad bostad = bostadController.HamtaSpecifikBostad(bostadsID);
                Console.WriteLine("\nVar god att skriv en recension om bostaden:");
                string recension = Console.ReadLine();

                Console.WriteLine("\nPå en skala 1-10, vad skulle du betygsätta bostaden?");
                int betyg;
                while ( !int.TryParse(Console.ReadLine(), out betyg ) && betyg < 1 || betyg > 10)
                {
                    Console.WriteLine("\nBetyget anges endast med heltal mellan 1-10!");
                    Console.WriteLine("\nAnge betyg: ");
                }
                Review review = reviewController.ReviewSkapning(anvandarController.Inloggad, recension, betyg, bostad);
                bostadController.LaggTillReviewILista(review, bostad);
            }
        }
        private void VisaAllaReviews()
        {
            Console.WriteLine("----------------------------------------------------------------------------------\nAnge Bostads-ID för bostaden du önskar recensera:");
            int bostadsID;
            while (!int.TryParse(Console.ReadLine(), out bostadsID))
            {
                Console.WriteLine("\nBostads-ID anges endast med heltal!");
                Console.WriteLine("\nAnge Bostads-ID: ");
            }
            if (bostadController.KollaBostad(bostadsID))
            {
                Bostad bostad = bostadController.HamtaSpecifikBostad(bostadsID);
                foreach (Review review in bostad.ListaAvReview)
                {
                    Console.WriteLine("Recension: " + review.Recension + " Betyg: " + review.Betyg);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }
        private void TaBortReview()
        {
            Console.WriteLine("----------------------------------------------------------------------------------\nAnge recension-ID för den recension du önskar ta bort:");
            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("\nRecension-ID anges endast med heltal!");
                Console.WriteLine("\nAnge recension-ID: ");
            }
            if (reviewController.KollaReview(ID))
            {
                Review review = reviewController.HamtaSpecifikrReview(ID);
                if (bostadController.KollaOmReviewÄgsAvInloggad(review, anvandarController.Inloggad))
                {
                    if (reviewController.ReviewBorttagning(ID))
                    {
                        Console.WriteLine("Recensionen är nu borttagen");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Ingen recension med angivet ID hittades!");
                }
            }
            else
            {
                Console.WriteLine("Ingen recension med angivet ID hittades!");
            }
        }
        private void SkapaBokning()
        {
            Console.WriteLine("\nAnge annons-id för den annons du vill skapa en boking för!");
            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("\n Annons-ID anges endast med heltal!");
                Console.WriteLine("\nAnge annons-ID: ");
            }
            if(bostadsAnnonsController.KollaAnnons(ID) && bostadsAnnonsController.HamtaAnnons(ID).Status == true)
            {
                BostadsAnnons AktuellAnnons = bostadsAnnonsController.HamtaAnnons(ID);
                Console.WriteLine("\nAnge antal personer som ska stanna i bostaden");
                int antalPersoner;
                while (!int.TryParse(Console.ReadLine(), out antalPersoner))
                {
                    Console.WriteLine("\n Personer anges endast med heltal!");
                    Console.WriteLine("\nAnge antal personer: ");
                }
                DateTime StartTid;
                while (!DateTime.TryParse(Console.ReadLine(), out StartTid) || StartTid < DateTime.Today)
                {
                    Console.WriteLine("\nStarttiden måste skrivas i rätt format. ex YY/MM/DD och vara större eller lika med dagens datum");
                    Console.WriteLine("\nSkriv in starttiden korrekt: ");
                }
                if (bokningController.KollaStartDatum(StartTid))
                {
                    Console.WriteLine("När ska lånet Återlämnas: ");
                    DateTime SlutTid;
                    while (!DateTime.TryParse(Console.ReadLine(), out SlutTid) || SlutTid <= StartTid)
                    {
                        Console.WriteLine("\nSluttiden måste skrivas i rätt format. ex YY/MM/DD och vara ett senare datum än starttiden");
                        Console.WriteLine("\nSkriv in sluttiden korrekt: ");
                    }
                    if (bokningController.KollaSlutDatum(SlutTid, StartTid))
                    {
                        bokningController.SkapaBokning(AktuellAnnons, anvandarController.Inloggad, antalPersoner, StartTid, SlutTid, bostadController.HamtaSpecifikBostad(AktuellAnnons.BostadsAnnonsID));
                    }
                    else
                    {
                        Console.WriteLine("\nTiden var på något sätt inte tillänglig");
                    }
                }
                else
                {
                    Console.WriteLine("\nTiden var på något sätt inte tillänglig");
                }
            }
            else
            {
                Console.WriteLine("\nDet fanns ingen annons med det angivna ID:t");
            }
        }
        private void TaBortBokning()   
        {
              Console.WriteLine("\nAnge Boknings-id för den bokning du vill ta bort!"); 
              int ID;
              while (!int.TryParse(Console.ReadLine(), out ID))
              {
                  Console.WriteLine("\n Boknings-ID anges endast med heltal!");
                  Console.WriteLine("\nAnge Boknings-ID: ");
              }
              if (bokningController.BokningsBorttagning(ID))
              {
                Console.WriteLine("\n Bokningen är borttagen");
              }
        }
        private void VisaRelevantaBokningar()
        {
            Console.WriteLine("Dina bokningar av andras bostader");
            Console.WriteLine("----------------------------------------------------------------------------------");
            List<Bokning> SkrivUt = bokningController.HamtaAllaInloggadesBokningar(anvandarController.Inloggad);
            foreach (Bokning bokning in SkrivUt)
            {
                Console.WriteLine(bostadController.HamtaSpecifikBostad(bokning.BostadID).Adress +  bokning.AntalPersoner + bokning.StartDatum + bokning.SlutDatum + bokning.TotalPris + bokning.Status);
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            Console.WriteLine("Andras bokningar av dina bostader");
            Console.WriteLine("----------------------------------------------------------------------------------");
            List<Bostad> InloggadsBostader = bostadController.HamtaAllaSomInloggadÄger(anvandarController.Inloggad);
            SkrivUt = bokningController.HamtaAllaBokningarAvInloggadesAnnonser(InloggadsBostader);
            foreach (Bokning bokning in SkrivUt)
            {
                Console.WriteLine(bostadController.HamtaSpecifikBostad(bokning.BostadID).Adress + bokning.AntalPersoner + bokning.StartDatum + bokning.SlutDatum + bokning.TotalPris + bokning.KundID + bokning.Status);
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
        }
        private void FiltreraAnnonser()
        {
            List<BostadsAnnons> bostadsAnnonsernaSomSkaVisas = new List<BostadsAnnons>(); 
            string stadSvar;
            string rumSvar;
            string rokaSvar;
            string husdjurSvar;
            string wifiSvar;
            string parkeringSvar;
            string betygSvar;
            string ppnSvar;
            Console.WriteLine("Vilken stad ska bostaden ligga i?(Svara X om det inte spelar någon roll)");
            stadSvar = Console.ReadLine();
            if (stadSvar.ToUpper() == "X")
            {
            }
            else
            {
                List<BostadsAnnons> LäggTillStad = bostadController.HamtaAllaAnnonserIStadenX(stadSvar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillStad, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Hur många rum ska finnas?(Svara X om det inte spelar någon roll)");
            rumSvar = Console.ReadLine();
            int filterAntalRum;
            if (rumSvar.ToUpper() == "X")
            {
            }
            else
            {
                int antalRumFilter;
                while (!int.TryParse(rumSvar, out antalRumFilter))
                {
                    Console.WriteLine("\nAnge gärna önskat antal rum i siffror!");
                    rumSvar = Console.ReadLine();
                }
                filterAntalRum = antalRumFilter;
                List<BostadsAnnons> LäggTillRum = bostadsAnnonsController.HamtaAllaAnnonserMedXRum(filterAntalRum).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillRum, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Vad är lägsta önskat betyg på bostaden?(Svara X om det inte spelar någon roll)");
            betygSvar = Console.ReadLine();
            int filterBetyg;
            if (betygSvar.ToUpper() == "X")
            {
            }
            else
            {
                int lagstBetyg;
                while (!int.TryParse(betygSvar, out lagstBetyg))
                {
                    Console.WriteLine("\nAnge gärna önskat lägst betyg i siffror!");
                    betygSvar = Console.ReadLine();
                }
                filterBetyg = lagstBetyg;
                List<BostadsAnnons> LäggTillBetyg = bostadController.FiltreraBetyg(filterBetyg).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillBetyg, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Vad är högsta priset per natt som du vill visas(Svara X om det inte spelar någon roll)");
            ppnSvar = Console.ReadLine();
            int filterPris;
            if (ppnSvar.ToUpper() == "X")
            {
            }
            else
            {
                int hogstBetyg;
                while (!int.TryParse(ppnSvar, out hogstBetyg))
                {
                    Console.WriteLine("\nAnge gärna önskat högst pris i siffror!");
                    ppnSvar = Console.ReadLine();
                }
                filterPris = hogstBetyg;
                List<BostadsAnnons> LäggTillPPN = bostadsAnnonsController.HamtaAllaAnnonserUnderXPris(filterPris).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillPPN, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Ska man kunna röka? (Svara Y/N eller X om det inte spelar någon roll)");
            rokaSvar = Console.ReadLine().ToUpper();
            while (rokaSvar != "Y" && rokaSvar != "N" && rokaSvar != "X")
            {
                Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                Console.WriteLine("\nÄr rökning tillåten i bostaden? Y/N eller vill du skippa? X");
                rokaSvar = Console.ReadLine().ToUpper();
            }
            if (rokaSvar.ToUpper() == "X")
            {
            }
            else if (rokaSvar.ToUpper() == "Y")
            {
                bool svar = true;
                List<BostadsAnnons> LäggTillRöka = bostadsAnnonsController.HamtaAllaAnnonserDarManFarRoka(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillRöka, bostadsAnnonsernaSomSkaVisas);
            }
            else if(rokaSvar.ToUpper() == "N")
            {
                bool svar = false;
                List<BostadsAnnons> LäggTillRöka = bostadsAnnonsController.HamtaAllaAnnonserDarManFarRoka(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillRöka, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Ska man kunna ha husdjur? (Svara Y/N eller X om det inte spelar någon roll)");
            husdjurSvar = Console.ReadLine().ToUpper();
            while (husdjurSvar != "Y" && husdjurSvar != "N" && husdjurSvar != "X")
            {
                Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                Console.WriteLine("\nÄr husdjur tillåtna i bostaden? Y/N eller vill du skippa? X");
                husdjurSvar = Console.ReadLine().ToUpper();
            }
            if (husdjurSvar.ToUpper() == "X")
            {
            }
            else if (husdjurSvar.ToUpper() == "Y")
            {
                bool svar = true;
                List<BostadsAnnons> LäggTillHusdjur = bostadsAnnonsController.HamtaAllaAnnonserDarManFarHaDjur(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillHusdjur, bostadsAnnonsernaSomSkaVisas);
            }
            else if (husdjurSvar.ToUpper() == "N")
            {
                bool svar = false;
                List<BostadsAnnons> LäggTillHusdjur = bostadsAnnonsController.HamtaAllaAnnonserDarManFarHaDjur(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillHusdjur, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Ska man det finnas WiFi? (Svara Y/N eller X om det inte spelar någon roll)");
            wifiSvar = Console.ReadLine().ToUpper();
            while (wifiSvar != "Y" && wifiSvar != "N" && wifiSvar != "X")
            {
                Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                Console.WriteLine("\nFinns det WIFI tillgång i bostaden? Y/N eller vill du skippa? X");
                wifiSvar = Console.ReadLine().ToUpper();
            }
            if (wifiSvar.ToUpper() == "X")
            {
            }
            else if (wifiSvar.ToUpper() == "Y")
            {
                bool svar = true;
                List<BostadsAnnons> LäggTillWifi = bostadsAnnonsController.HamtaAllaAnnonserDarWifiFinns(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillWifi, bostadsAnnonsernaSomSkaVisas);
            }
            else if (wifiSvar.ToUpper() == "N")
            {
                bool svar = false;
                List<BostadsAnnons> LäggTillWifi = bostadsAnnonsController.HamtaAllaAnnonserDarWifiFinns(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillWifi, bostadsAnnonsernaSomSkaVisas);
            }
            Console.WriteLine("Ska man det finnas parkering? (Svara Y/N eller X om det inte spelar någon roll)");
            parkeringSvar = Console.ReadLine().ToUpper();
            while (parkeringSvar != "Y" && parkeringSvar != "N" && parkeringSvar != "X")
            {
                Console.WriteLine("\nSvara antigen med Y för ja, N för nej eller X för att skippa!");
                Console.WriteLine("\nFinns det tillgång till parkering? Y/N eller vill du skippa? X");
                parkeringSvar = Console.ReadLine().ToUpper();
            }
            if (parkeringSvar.ToUpper() == "X")
            {
            }
            else if (parkeringSvar.ToUpper() == "Y")
            {
                bool svar = true;
                List<BostadsAnnons> LäggTillParkering = bostadsAnnonsController.HamtaAllaAnnonserDarParkeringFinns(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillParkering, bostadsAnnonsernaSomSkaVisas);
            }
            else if (parkeringSvar.ToUpper() == "N")
            {
                bool svar = false;
                List<BostadsAnnons> LäggTillParkering = bostadsAnnonsController.HamtaAllaAnnonserDarParkeringFinns(svar).ToList();
                bostadsAnnonsernaSomSkaVisas = ÄndraListan(LäggTillParkering, bostadsAnnonsernaSomSkaVisas);
            }
            foreach (BostadsAnnons annons in bostadsAnnonsernaSomSkaVisas)
            {
                if (annons.Status == true)
                {
                    Console.WriteLine("Address: " + bostadController.HamtaSpecifikBostad(annons.BostadID).Adress + " Pris per natt: " + annons.PPN.ToString() + " Antal rum: " + annons.AntalRum.ToString() + "\n\r" + " Finns WIFI: " + annons.WIFI + " Finns Parkering: " + annons.Parkering + " Får man ha Husdjur: " + annons.Husdjur + " Får man röka: " + annons.Rokning + "\n\r" + " Beskrivning: " + annons.Beskrivning);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }
        private List<BostadsAnnons> ÄndraListan(List<BostadsAnnons> LäggTill, List<BostadsAnnons> bostadsAnnonsernaSomSkaVisas)
        {
            if (bostadsAnnonsernaSomSkaVisas.Count == 0)
            {
                bostadsAnnonsernaSomSkaVisas = LäggTill;
            }
            else
            {
                int x = bostadsAnnonsernaSomSkaVisas.Count() - 1;
                for (int i = 0; i < x; i++)
                {
                if (bostadsAnnonsernaSomSkaVisas.Count > 0 && !LäggTill.Contains(bostadsAnnonsernaSomSkaVisas[i]))
                    {
                        bostadsAnnonsernaSomSkaVisas.Remove(bostadsAnnonsernaSomSkaVisas[i]);
                    }
                }
            }
            return bostadsAnnonsernaSomSkaVisas;
        }
        private void Update()
        {
            bokningController.UpdateraStatus();
            List<Bostad> AllaBostader = bostadController.HamtaAllaBostader();
            anvandarController.UpdateraBostadIListan(AllaBostader);
            List<Review> AllaReviews = reviewController.HamtaAllaReviews().ToList();
            bostadController.UpdateraReviewListan(AllaReviews);
            List<BostadsAnnons> AllaAnnonser = bostadsAnnonsController.HamtaAllaAnnonser().ToList();
            bostadController.UpdateraAnnonsListan(AllaAnnonser);
            List<Bokning> AllaBokningar = bokningController.HamtaAllaBokningar().ToList();
            bostadController.UpdateraBokningsListan(AllaBokningar); 
        }
        private AnvandarController anvandarController;
        private BostadController bostadController;
        private BostadsAnnonsController bostadsAnnonsController;
        private ReviewController reviewController;
        private BokningController bokningController;
    }
}