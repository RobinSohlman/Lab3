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
using WPF.ViewModels.HanteraEnAnnons;
using WPF.Model;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for HanteraEnAnnons.xaml
    /// </summary>
    public partial class HanteraEnAnnons : Window
    {
        public HanteraEnAnnons(BostadOchAnnons ValdAnnons)
        {
            InitializeComponent();
            DataContext = new HanteraEnAnnonsModel(ValdAnnons);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
