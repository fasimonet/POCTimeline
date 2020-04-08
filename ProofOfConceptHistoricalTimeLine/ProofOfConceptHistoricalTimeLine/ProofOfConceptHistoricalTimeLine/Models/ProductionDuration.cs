using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConceptHistoricalTimeLine.Models
{
    public class ProductionDuration
    {
        public DateTime StartDuration { get; set; }
        public DateTime EndDuration { get; set; }

        public ProductionDuration(DateTime startDuration, DateTime endDuration)
        {
            StartDuration = startDuration;
            EndDuration = endDuration;
        }
    }
}
