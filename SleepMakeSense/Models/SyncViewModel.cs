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


        public DateTime[] DateStamp { get; set; }

        public double[] MinutesAsleep { get; set; }

        public int[] AwakeCount { get; set; }

        public int[] SleepEfficiency { get; set; }


    }
}