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
        //public ObservableCollection<ProductionDuration> ProductionOn { get; set; }
        //public ObservableCollection<ProductionDuration> ProductionOff { get; set; }
        public ObservableCollection<Item> ProductionOn { get; set; }
        public ObservableCollection<Item> ProductionOff { get; set; }
        public ProductionPeriodDuration Period { get; set; }
        // TEST !!!
        public ObservableCollection<Item> Data { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MainWindowViewModel()
        {
            Message = "salut";
            Period = new ProductionPeriodDuration();

            //ProductionOn = new ObservableCollection<Item>(Period.ProductionOn);
            ProductionOn = new ObservableCollection<Item>(Period.ProductionOn);
            //ProductionOff = new ObservableCollection<Item>(Period.ProductionOff);
            ProductionOff = new ObservableCollection<Item>();

            // TEST !!!
            var startDate = new DateTime(2010, 1, 1);
            var endDate = new DateTime(2012, 2, 1);

            var items = new ObservableCollection<Item>();
            Random r = new Random();
            for (DateTime i = startDate; i < endDate; i = i.AddMonths(1))
            {
                items.Add(new Item() { Date = i, Duration = TimeSpan.FromDays(r.Next(50, 100)), GroupName="Période de production" });
            }

            for (int i = 0; i < 15; i++)
            {
                items.Add(new Item()
                {
                    Date = startDate.AddMonths(r.Next(0, 25)).AddDays(15),
                    GroupName="Période d'arrêt"

                });
            }

            Data = items;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
