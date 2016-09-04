﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public class MyViewModel
    {
        public List<Userdata> AllData { get; set; }
        public List<CorrList> CorrCoefficient { get; set; }

        public UserQuestion UserQuestion { get; set; }

        public Userdata Userdata { get; set; }

        public bool Morning { get; set; }
    }
}