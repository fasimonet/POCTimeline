using ProofOfConceptHistoricalTimeLine.Commands;
using ProofOfConceptHistoricalTimeLine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private Item _productionOnSelectedItem;
        public Item ProductionOnSelectedItem
        {
            get
            {
                return _productionOnSelectedItem;
            }
            set
            {
                _productionOnSelectedItem = value;
                OnPropertyChanged(nameof(ProductionOnSelectedItem));
            }
        }

        private Item _productionOffSelectedItem;
        public Item ProductionOffSelectedItem
        {
            get
            {
                return _productionOffSelectedItem;
            }
            set
            {
                _productionOffSelectedItem = value;
                OnPropertyChanged(nameof(ProductionOffSelectedItem));
            }
        }

        /*private static bool IsSelectedProductionOnItemNotNull(object o) {
            return false;
        }*/
        // TEST !!!
        public ObservableCollection<Item> Data { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SimpleCommand DeleteProductionOnItemCommand { get; set; }
        public SimpleCommand AddProductionOnItemCommand { get; set; }
        public SimpleCommand DeleteProductionOffItemCommand { get; set; }
        public SimpleCommand AddProductionOffItemCommand { get; set; }

        private ObservableCollection<Item> _timelineItems;
        public ObservableCollection<Item> TimelineItems
        {
            get
            {
                return _timelineItems;
            }
            set
            {
                _timelineItems = value;
                OnPropertyChanged(nameof(TimelineItems));
            }
        }


        public MainWindowViewModel()
        {
            Message = "salut";
            Period = new ProductionPeriodDuration();

            //Predicate<object> predicate = IsSelectedProductionOnItemNotNull;

            DeleteProductionOnItemCommand = new SimpleCommand(DeleteProductionOnItem);
            AddProductionOnItemCommand = new SimpleCommand(AddProductionOnItem);
            DeleteProductionOffItemCommand = new SimpleCommand(DeleteProductionOffItem);
            AddProductionOffItemCommand = new SimpleCommand(AddProductionOffItem);

            //ProductionOn = new ObservableCollection<Item>(Period.ProductionOn);
            ProductionOn = new ObservableCollection<Item>(Period.ProductionOn);
            //ProductionOff = new ObservableCollection<Item>(Period.ProductionOff);
            ProductionOff = new ObservableCollection<Item>(Period.ProductionOff);

            UpdateTimeline();

            // TEST !!!
            /*var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2012, 2, 1);*/



            //var items = new ObservableCollection<Item>();
            /*Random r = new Random();
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
            EndDate = endDate;*/
        }

        /*
         *
         */
        private void DeleteProductionOnItem(object o)
        {
            if(ProductionOn.Count != 0 && ProductionOnSelectedItem != null)
            {
                ProductionOn.Remove(ProductionOnSelectedItem);
            }
            UpdateTimeline();
        }

        private void AddProductionOnItem(object o)
        {
            ProductionOn.Add(new Item { Date = DateTime.Now, Duration = new TimeSpan(1, 0, 0), GroupName = "Période de production" });
            UpdateTimeline();
        }

        private void DeleteProductionOffItem(object o)
        {
            if (ProductionOff.Count != 0 && ProductionOffSelectedItem != null)
            {
                ProductionOff.Remove(ProductionOffSelectedItem);
            }
            UpdateTimeline();
        }

        private void AddProductionOffItem(object o)
        {
            ProductionOff.Add(new Item { Date = DateTime.Now, Duration = new TimeSpan(1, 0, 0), GroupName = "Période de production" });
            UpdateTimeline();
        }

        private void UpdateTimeline()
        {
            /*var items = new ObservableCollection<Item>(ProductionOn);
            foreach (var elt in ProductionOff)
            {
                items.Add(elt);
            }

            Data = items;
            StartDate = Period.TotalPeriod.StartDuration;
            EndDate = Period.TotalPeriod.EndDuration;*/
            Data = new ObservableCollection<Item>(ProductionOn);
            foreach (var elt in ProductionOff)
            {
                Data.Add(elt);
            }

            //Data = TimelineItems;
            StartDate = Period.TotalPeriod.StartDuration;
            EndDate = Period.TotalPeriod.EndDuration;
        }
    }
}
