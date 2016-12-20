using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public class SyncViewModel
    { 
        public List<CorrList> CorrCoefficient { get; set; }


        public List<DateTime> DateStamp { get; set; }

        public List<int> MinutesAsleep { get; set; }

        public List<int> AwakeCount { get; set; }

        public List<int> SleepEfficiency { get; set; }



        }
}

