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
using WPF.ViewModels.SkapaAnvandare;


namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for SkapaAnvandare.xaml
    /// </summary>
    public partial class SkapaAnvandare : Window
    {
        public SkapaAnvandare()
        {
            InitializeComponent();
            DataContext = new SkapaAnvandreModel();
        }
    }
}
