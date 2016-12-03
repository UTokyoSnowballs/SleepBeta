using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public class MyViewModel
    {
        public List<Userdata> AllData { get; set; }
        public List<CorrList> CorrCoefficient { get; set; }

        public UserQuestion UserQuestion { get; set; }

        public  List<Userdata> Userdata { get; set; }

        public DiaryData DiaryData { get; set; }

        public bool QuestionsSetup { get; set; }

        public bool TodaySync { get; set; }

        public QuestionsSelections questionSelection { get; set; }

    }
}