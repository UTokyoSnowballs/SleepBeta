using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepExplorer.Models
{
    public class MyViewModel
    {
        public List<FitbitData> AllData { get; set; }
        public List<CorrList> CorrCoefficient { get; set; }

    }
}