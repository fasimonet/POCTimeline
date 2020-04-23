using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConceptHistoricalTimeLine.Models
{
    public class ProductionPeriodDuration
    {
        #region Properties
        public ProductionDuration TotalPeriod { get; set; } 
        //public List<ProductionDuration> ProductionOn { get; set; }
        //public List<ProductionDuration> ProductionOff { get; set; }
        public List<Item> ProductionOn { get; set; }
        public List<Item> ProductionOff { get; set; }
        #endregion

        #region Constructors
        public ProductionPeriodDuration()
        {
            DateTime now = DateTime.Now;
            DateTime end = now.AddHours(1);
            TotalPeriod = new ProductionDuration(now, end);
            ProductionOn = new List<Item>();
            ProductionOff = new List<Item>();
            ProductionOn.Add(new Item() { Date = now, Duration = new TimeSpan(1, 0, 0) }); 
            /*ProductionOn.Add(new Item(now, now.AddMinutes(20)));
            ProductionOff.Add(new ProductionDuration(now.AddMinutes(20), now.AddMinutes(40)));
            ProductionOn.Add(new ProductionDuration(now.AddMinutes(40), end));*/
        }
        #endregion


    }
}
