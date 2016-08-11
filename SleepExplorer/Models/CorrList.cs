using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepExplorer.Models
{
    public class CorrList
    {
        public string Belong { get; set; } // characterize the correlation to which sleep attribute    
        public string Name { get; set; }
        public double Coefficient { get; set; }
        public string Note { get; set; }
        // ToDO: Significance test
        // public double significance { get; set;}

    }
}