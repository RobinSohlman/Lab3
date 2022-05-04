
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModels.MinaAnnonser;
using AirBNBDataLayer;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for MinaAnnonser.xaml
    /// </summary>
    public partial class MinaAnnonser : Window
    {
        public MinaAnnonser(Anvandare Inloggad)
        {
            InitializeComponent();
            DataContext = new MinaAnnonserModel(Inloggad);
        }
    }
}

