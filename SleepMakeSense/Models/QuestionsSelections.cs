using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public  class QuestionsSelections
    {
        public IEnumerable<SelectListItem> TrueFalse()
        {
            yield return new SelectListItem { Text = "True", Value = "1" };
            yield return new SelectListItem { Text = "False", Value = "0" };
        }

        public IEnumerable<SelectListItem> ToFive()
        {
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }

        public IEnumerable<SelectListItem> ToTen()
        {
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
            yield return new SelectListItem { Text = "6", Value = "6" };
            yield return new SelectListItem { Text = "7", Value = "7" };
            yield return new SelectListItem { Text = "8", Value = "8" };
            yield return new SelectListItem { Text = "9", Value = "9" };
            yield return new SelectListItem { Text = "10", Value = "10" };
        }

        public IEnumerable<SelectListItem> TimeToFive()
        {
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "15 Minutes", Value = "15" };
            yield return new SelectListItem { Text = "30 Minutes", Value = "30" };
            yield return new SelectListItem { Text = "45 Minutes", Value = "45" };
            yield return new SelectListItem { Text = "1 Hour", Value = "60" };
            yield return new SelectListItem { Text = "1 Hour 15 Minutes", Value = "75" };
            yield return new SelectListItem { Text = "1 Hour 30 Minutes", Value = "90" };
            yield return new SelectListItem { Text = "1 Hour 45 Minutes", Value = "105" };
            yield return new SelectListItem { Text = "2 Hour", Value = "120" };
            yield return new SelectListItem { Text = "2 Hour 15 Minutes", Value = "135" };
            yield return new SelectListItem { Text = "2 Hour 30 Minutes", Value = "150" };
            yield return new SelectListItem { Text = "2 Hour 45 Minutes", Value = "165" };
            yield return new SelectListItem { Text = "3 Hour", Value = "180" };
            yield return new SelectListItem { Text = "3 Hour 15 Minutes", Value = "195" };
            yield return new SelectListItem { Text = "3 Hour 30 Minutes", Value = "210" };
            yield return new SelectListItem { Text = "3 Hour 45 Minutes", Value = "225" };
            yield return new SelectListItem { Text = "4 Hour", Value = "240" };
            yield return new SelectListItem { Text = "4 Hour 15 Minutes", Value = "255" };
            yield return new SelectListItem { Text = "4 Hour 30 Minutes", Value = "270" };
            yield return new SelectListItem { Text = "4 Hour 45 Minutes", Value = "285" };
            yield return new SelectListItem { Text = "5 Hour", Value = "300" };

        }

        public IEnumerable<SelectListItem> TimeToTen()
        {
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "30 Minutes", Value = "30" };
            yield return new SelectListItem { Text = "1 Hour", Value = "60" };
            yield return new SelectListItem { Text = "1 Hour 30 Minutes", Value = "90" };
            yield return new SelectListItem { Text = "2 Hours", Value = "120" };
            yield return new SelectListItem { Text = "2 Hours 30 Minutes", Value = "150" };
            yield return new SelectListItem { Text = "3 Hours", Value = "180" };
            yield return new SelectListItem { Text = "3 Hours 30 Minutes", Value = "210" };
            yield return new SelectListItem { Text = "4 Hours", Value = "240" };
            yield return new SelectListItem { Text = "4 Hours 30 Minutes", Value = "270" };
            yield return new SelectListItem { Text = "5 Hours", Value = "300" };
            yield return new SelectListItem { Text = "5 Hours 30 Minutes", Value = "330" };
            yield return new SelectListItem { Text = "6 Hours", Value = "360" };
            yield return new SelectListItem { Text = "6 Hours 30 Minutes", Value = "390" };
            yield return new SelectListItem { Text = "7 Hours", Value = "420" };
            yield return new SelectListItem { Text = "7 Hours 30 Minutes", Value = "450" };
            yield return new SelectListItem { Text = "8 Hours", Value = "480" };
            yield return new SelectListItem { Text = "8 Hours 30 Minutes", Value = "510" };
            yield return new SelectListItem { Text = "9 Hours", Value = "540" };
            yield return new SelectListItem { Text = "9 Hours 30 Minutes", Value = "570" };
            yield return new SelectListItem { Text = "10 Hours", Value = "600" };
        }

        public IEnumerable<SelectListItem> DayHours()
        {
            yield return new SelectListItem { Text = "06:00 AM", Value = "6" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "7" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "8"};
            yield return new SelectListItem { Text = "09:00 AM", Value = "9" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18" };
        }

        public IEnumerable<SelectListItem> NightHours()
        {
            yield return new SelectListItem { Text = "06:00 PM", Value = "18" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23" };
            yield return new SelectListItem { Text = "12:00 AM", Value = "24" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "25" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "26" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "27" };
            yield return new SelectListItem { Text = "04:00 AM", Value = "28" };
            yield return new SelectListItem { Text = "05:00 AM", Value = "29" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "30" };
        }

        public IEnumerable<SelectListItem> AllHours()
        {
            yield return new SelectListItem { Text = "12:00 AM", Value = "0" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "1" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "2" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "3" };
            yield return new SelectListItem { Text = "04:00 AM", Value = "4" };
            yield return new SelectListItem { Text = "05:00 AM", Value = "5" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "6" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "7" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "8" };
            yield return new SelectListItem { Text = "09:00 AM", Value = "9" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23" };

        }
    }
}
