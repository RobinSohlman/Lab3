using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using AirBNBDataLayer;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModels.Menyn;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for Menyen.xaml
    /// </summary>
    public partial class Menyn : Window
    {
        public Menyn(Anvandare Inloggad)
        {
            InitializeComponent();
            DataContext = new MenyModel(Inloggad);
        }
    }
}
