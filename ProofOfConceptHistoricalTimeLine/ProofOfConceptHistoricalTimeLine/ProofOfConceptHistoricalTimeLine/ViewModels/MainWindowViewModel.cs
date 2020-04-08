using ProofOfConceptHistoricalTimeLine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConceptHistoricalTimeLine.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Message { get; set; }
        public ObservableCollection<ProductionDuration> ProductionOn { get; set; }
        public ObservableCollection<ProductionDuration> ProductionOff { get; set; }
        public ProductionPeriodDuration Period { get; set; }


        public MainWindowViewModel()
        {
            Message = "salut";
            Period = new ProductionPeriodDuration();

            ProductionOn = new ObservableCollection<ProductionDuration>(Period.ProductionOn);
            ProductionOff = new ObservableCollection<ProductionDuration>(Period.ProductionOff);

        }
    }
}
