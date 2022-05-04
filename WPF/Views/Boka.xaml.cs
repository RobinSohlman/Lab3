using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModels.SkapaBokning;
using WPF.Model;
using AirBNBDataLayer;
using System.Data;
using System.ComponentModel;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for Boka.xaml
    /// </summary>
    public partial class Boka : Window
    {
        public Boka(BostadOchAnnons ValdAnnons, Anvandare Inloggad, List<Bokning>Bokningar)
        {
            InitializeComponent();
            DataContext = new SkapaBokningModel(ValdAnnons, Inloggad);
            foreach(Bokning b in Bokningar)
            {
                StartCalendar.BlackoutDates.Add(new CalendarDateRange(b.StartDatum, b.SlutDatum));
            }
            foreach (Bokning b in Bokningar)
            {
                SlutCalendar.BlackoutDates.Add(new CalendarDateRange(b.StartDatum, b.SlutDatum));
            }

            /*WebRequest request = WebRequest.Create(ValdAnnons.Annons.BildURL);
            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                }
            }*/

            img.Source = new BitmapImage(new Uri(ValdAnnons.Annons.BildURL, UriKind.Absolute));

        }
    }
}