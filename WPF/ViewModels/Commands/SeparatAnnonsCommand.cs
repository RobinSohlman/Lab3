using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AirBNBBL;
using System.Windows;
using WPF.ViewModels.SeparatAnnons;
using System.Windows.Input;

namespace WPF.ViewModels.Commands
{
    class SeparatAnnonsCommand : ICommand
    {
        private readonly SeparatAnnonsModel separatAnnonsModel;

        public SeparatAnnonsCommand(SeparatAnnonsModel separatAnnonsModel)
        {
            this.separatAnnonsModel = separatAnnonsModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {

        }
    }
}


