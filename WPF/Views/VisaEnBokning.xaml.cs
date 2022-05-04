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
using WPF.ViewModels.SeparatBokning;
using WPF.Model;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for VisaEnBokning.xaml
    /// </summary>
    public partial class VisaEnBokning : Window
    {
        public VisaEnBokning(BokningOchBostad ValdBokning)
        {
            InitializeComponent();
            DataContext = new SeparatBokningModel(ValdBokning);
        }
    }
}
