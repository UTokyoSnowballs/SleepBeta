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
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "True", Value = "1" };
            yield return new SelectListItem { Text = "False", Value = "0" };
        }

        public IEnumerable<SelectListItem> ToFive()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }

        public IEnumerable<SelectListItem> ToTen()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
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
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "0", Value = "00:00" };
            yield return new SelectListItem { Text = "15 Minutes", Value = "00:15" };
            yield return new SelectListItem { Text = "30 Minutes", Value = "00:30" };
            yield return new SelectListItem { Text = "45 Minutes", Value = "00:45" };
            yield return new SelectListItem { Text = "1 Hour", Value = "01:00" };
            yield return new SelectListItem { Text = "1 Hour 15 Minutes", Value = "01:15" };
            yield return new SelectListItem { Text = "1 Hour 30 Minutes", Value = "01:30" };
            yield return new SelectListItem { Text = "1 Hour 45 Minutes", Value = "01:45" };
            yield return new SelectListItem { Text = "2 Hour", Value = "02:00" };
            yield return new SelectListItem { Text = "2 Hour 15 Minutes", Value = "02:15" };
            yield return new SelectListItem { Text = "2 Hour 30 Minutes", Value = "02:30" };
            yield return new SelectListItem { Text = "2 Hour 45 Minutes", Value = "02:45" };
            yield return new SelectListItem { Text = "3 Hour", Value = "03:00" };
            yield return new SelectListItem { Text = "3 Hour 15 Minutes", Value = "03:15" };
            yield return new SelectListItem { Text = "3 Hour 30 Minutes", Value = "03:30" };
            yield return new SelectListItem { Text = "3 Hour 45 Minutes", Value = "03:45" };
            yield return new SelectListItem { Text = "4 Hour", Value = "04:00" };
            yield return new SelectListItem { Text = "4 Hour 15 Minutes", Value = "04:15" };
            yield return new SelectListItem { Text = "4 Hour 30 Minutes", Value = "04:30" };
            yield return new SelectListItem { Text = "4 Hour 45 Minutes", Value = "04:45" };
            yield return new SelectListItem { Text = "5 Hour", Value = "05:00" };

        }

        public IEnumerable<SelectListItem> TimeToTen()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "0", Value = "00:00" };
            yield return new SelectListItem { Text = "30 Minutes", Value = "00:30" };
            yield return new SelectListItem { Text = "1 Hour", Value = "01:00" };
            yield return new SelectListItem { Text = "1 Hour 30 Minutes", Value = "01:30" };
            yield return new SelectListItem { Text = "2 Hours", Value = "02:00" };
            yield return new SelectListItem { Text = "2 Hours 30 Minutes", Value = "02:30" };
            yield return new SelectListItem { Text = "3 Hours", Value = "03:00" };
            yield return new SelectListItem { Text = "3 Hours 30 Minutes", Value = "03:30" };
            yield return new SelectListItem { Text = "4 Hours", Value = "04:00" };
            yield return new SelectListItem { Text = "4 Hours 30 Minutes", Value = "04:30" };
            yield return new SelectListItem { Text = "5 Hours", Value = "05:00" };
            yield return new SelectListItem { Text = "5 Hours 30 Minutes", Value = "00:30" };
            yield return new SelectListItem { Text = "6 Hours", Value = "01:00" };
            yield return new SelectListItem { Text = "6 Hours 30 Minutes", Value = "01:30" };
            yield return new SelectListItem { Text = "7 Hours", Value = "02:00" };
            yield return new SelectListItem { Text = "7 Hours 30 Minutes", Value = "02:30" };
            yield return new SelectListItem { Text = "8 Hours", Value = "03:00" };
            yield return new SelectListItem { Text = "8 Hours 30 Minutes", Value = "03:30" };
            yield return new SelectListItem { Text = "9 Hours", Value = "04:00" };
            yield return new SelectListItem { Text = "9 Hours 30 Minutes", Value = "04:30" };
            yield return new SelectListItem { Text = "10 Hours", Value = "05:00" };
        }

        public IEnumerable<SelectListItem> DayHours()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "06:00 AM", Value = "06:00" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "07:00" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "08:00" };
            yield return new SelectListItem { Text = "09:00 AM", Value = "09:00" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10:00" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11:00" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12:00" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13:00" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14:00" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15:00" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16:00" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17:00" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18:00" };
        }

        public IEnumerable<SelectListItem> NightHours()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18:00" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19:00" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20:00" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21:00" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22:00" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23:00" };
            yield return new SelectListItem { Text = "12:00 AM", Value = "00:00" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "01:00" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "02:00" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "03:00" };
            yield return new SelectListItem { Text = "04:00 AM", Value = "04:00" };
            yield return new SelectListItem { Text = "05:00 AM", Value = "05:00" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "06:00" };
        }

        public IEnumerable<SelectListItem> AllHours()
        {
            yield return new SelectListItem { Text = "Please Select", Value = null };
            yield return new SelectListItem { Text = "12:00 AM", Value = "00:00" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "01:00" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "02:00" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "03:00" };
            yield return new SelectListItem { Text = "04:00 AM", Value = "04:00" };
            yield return new SelectListItem { Text = "05:00 AM", Value = "05:00" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "06:00" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "07:00" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "08:00" };
            yield return new SelectListItem { Text = "09:00 AM", Value = "09:00" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10:00" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11:00" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12:00" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13:00" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14:00" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15:00" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16:00" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17:00" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18:00" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19:00" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20:00" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21:00" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22:00" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23:00" };

        }
    }
}