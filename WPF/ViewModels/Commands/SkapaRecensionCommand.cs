using AirBNBBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.ViewModels.SkapaBokning;

namespace WPF.ViewModels.Commands
{
    class SkapaRecensionCommand : ICommand
    {
        private readonly SkapaBokningModel skapaBokningModel;
        public SkapaRecensionCommand(SkapaBokningModel skapaBokningModel)
        {
            this.skapaBokningModel = skapaBokningModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            reviewController = new ReviewController();
            int betyg = skapaBokningModel.Betyg;
            string recension = skapaBokningModel.Recension;
            if (betyg > 0 && betyg<11)
            {
                reviewController.ReviewSkapning(skapaBokningModel.Inloggad, recension, betyg, skapaBokningModel.VisaAnnons.Bostad);
                skapaBokningModel.RefreshListor();
            }
            else
            {
                MessageBox.Show("Betyget måste vara mellan 1-10");
            }
        }
        private ReviewController reviewController;
    }
}
