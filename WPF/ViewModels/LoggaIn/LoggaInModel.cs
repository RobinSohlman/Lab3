using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Commands;

namespace WPF.ViewModels.LoggaIn
{
    public class LoggaInModel : BaseViewModel
    {
        public int InloggadID { get; set; }
        public string Epost { get; set; }
        public string Losenord { get; set; }
        public ICommand OpenNewSkapaAnvandareCommand { get; set; }
        public ICommand NewLoggaInCommand { get; set; }
        public ICommand OpenNewMenynCommand { get; set; }
        public LoggaInModel()
        {
            OpenNewSkapaAnvandareCommand = new OpenSkapaAnvandareCommand(this);
            OpenNewMenynCommand = new OpenMenynCommand(this);
            NewLoggaInCommand = new LoggaInCommand(this);
        }
    }
}
