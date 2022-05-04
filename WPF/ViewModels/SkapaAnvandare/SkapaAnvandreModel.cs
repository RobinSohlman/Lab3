using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Commands;
using System.Windows.Input;


namespace WPF.ViewModels.SkapaAnvandare
{
    public class SkapaAnvandreModel : BaseViewModel
    {
        public string Namn { get; set; }
        public string Epost { get; set; }
        public string Losenord { get; set; }
        public ICommand SkapaNewAnvandareCommand { get; set; }

        public SkapaAnvandreModel()
        {
            SkapaNewAnvandareCommand = new SkapaAnvandareCommand(this);
        }
    }
}
