using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConceptHistoricalTimeLine.Models
{
    public class Item
    {
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public string GroupName { get; set; }
    }
}
