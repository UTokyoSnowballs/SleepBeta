using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public  class QuestionsSelections
    {
        public IEnumerable<SelectListItem> WatchTV()
        {
            yield return new SelectListItem { Text = "Did Not Watch TV", Value = "0" };
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

        public IEnumerable<SelectListItem> Coffee()
        {
            yield return new SelectListItem { Text = "Did Not Drink Coffee", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }
        public IEnumerable<SelectListItem> CoffeeTime()
        {
            yield return new SelectListItem { Text = "Did Not Drink Coffee", Value = "0" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "06.00" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "07.00" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "08.00" };
            yield return new SelectListItem { Text = "09:00 AM", Value = "09.00" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10.00" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11.00" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12.00" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13.00" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14.00" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15.00" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16.00" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17.00" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18.00" };
        }
        public IEnumerable<SelectListItem> ExerciseDuration()
        {
            yield return new SelectListItem { Text = "Did Not Exersise", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }

        public IEnumerable<SelectListItem> ExerciseIntensity()
        {
            yield return new SelectListItem { Text = "Did Not Exersise", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }

        public IEnumerable<SelectListItem> ExerciseType()
        {
            yield return new SelectListItem { Text = "Did Not Exersise", Value = "0" };
            yield return new SelectListItem { Text = "Running", Value = "1" };
            yield return new SelectListItem { Text = "Swimming", Value = "2" };
            yield return new SelectListItem { Text = "Dancing", Value = "3" };
            yield return new SelectListItem { Text = "Gym", Value = "4" };
            yield return new SelectListItem { Text = "Yoga", Value = "5" };
            yield return new SelectListItem { Text = "Gymnastics", Value = "6" };
            yield return new SelectListItem { Text = "Rugby", Value = "7" };
            yield return new SelectListItem { Text = "Soccer", Value = "8" };
            yield return new SelectListItem { Text = "AFL", Value = "9" };
            yield return new SelectListItem { Text = "Other", Value = "10" };
        }

        public IEnumerable<SelectListItem> SnackTime()
        {
            yield return new SelectListItem { Text = "Did Not Snack", Value = "" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18.00" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19.00" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20.00" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21.00" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22.00" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23.00" };
            yield return new SelectListItem { Text = "12:00 AM", Value = "00.00" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "01.00" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "02.00" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "03.00" };
        }

        public IEnumerable<SelectListItem> SnackType()
        {
            yield return new SelectListItem { Text = "None", Value = "0" };
            yield return new SelectListItem { Text = "Healthy Food", Value = "1" };
            yield return new SelectListItem { Text = "Unhealthy Food", Value = "2" };

        }

        public IEnumerable<SelectListItem> NapDuration()
        {
            yield return new SelectListItem { Text = "0 - 10 minutes", Value = "0" };
            yield return new SelectListItem { Text = "11 - 20 minutes", Value = "15" };
            yield return new SelectListItem { Text = "21 - 30 minutes", Value = "25" };
            yield return new SelectListItem { Text = "31 - 40 minutes", Value = "35" };
            yield return new SelectListItem { Text = "41 - 50 minutes", Value = "45" };
            yield return new SelectListItem { Text = "51 - 60 minutes", Value = "55" };
            yield return new SelectListItem { Text = "61 - 70 minutes", Value = "65" };
            yield return new SelectListItem { Text = "71 - 80 minutes", Value = "75" };
            yield return new SelectListItem { Text = "81 - 90 minutes", Value = "85" };
            yield return new SelectListItem { Text = "91 - 100 minutes", Value = "95" };
        }

        public IEnumerable<SelectListItem> NapTime()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "06:00 AM", Value = "06.00" };
            yield return new SelectListItem { Text = "07:00 AM", Value = "07.00" };
            yield return new SelectListItem { Text = "08:00 AM", Value = "08.00" };
            yield return new SelectListItem { Text = "09:00 AM", Value = "09.00" };
            yield return new SelectListItem { Text = "10:00 AM", Value = "10.00" };
            yield return new SelectListItem { Text = "11:00 AM", Value = "11.00" };
            yield return new SelectListItem { Text = "12:00 PM", Value = "12.00" };
            yield return new SelectListItem { Text = "01:00 PM", Value = "13.00" };
            yield return new SelectListItem { Text = "02:00 PM", Value = "14.00" };
            yield return new SelectListItem { Text = "03:00 PM", Value = "15.00" };
            yield return new SelectListItem { Text = "04:00 PM", Value = "16.00" };
            yield return new SelectListItem { Text = "05:00 PM", Value = "17.00" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18.00" };
        }

        public IEnumerable<SelectListItem> Alcohol()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
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

        public IEnumerable<SelectListItem> WorkTime()
        {
            yield return new SelectListItem { Text = "Did Not Snack", Value = "" };
            yield return new SelectListItem { Text = "06:00 PM", Value = "18.00" };
            yield return new SelectListItem { Text = "07:00 PM", Value = "19.00" };
            yield return new SelectListItem { Text = "08:00 PM", Value = "20.00" };
            yield return new SelectListItem { Text = "09:00 PM", Value = "21.00" };
            yield return new SelectListItem { Text = "10:00 PM", Value = "22.00" };
            yield return new SelectListItem { Text = "11:00 PM", Value = "23.00" };
            yield return new SelectListItem { Text = "12:00 AM", Value = "00.00" };
            yield return new SelectListItem { Text = "01:00 AM", Value = "01.00" };
            yield return new SelectListItem { Text = "02:00 AM", Value = "02.00" };
            yield return new SelectListItem { Text = "03:00 AM", Value = "03.00" };
        }
        public IEnumerable<SelectListItem> WorkDuration()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "1 Hour", Value = "1" };
            yield return new SelectListItem { Text = "2 Hours", Value = "2" };
            yield return new SelectListItem { Text = "3 Hours", Value = "3" };
            yield return new SelectListItem { Text = "4 Hours", Value = "4" };
            yield return new SelectListItem { Text = "5 Hours", Value = "5" };
            yield return new SelectListItem { Text = "6 Hours", Value = "6" };
            yield return new SelectListItem { Text = "7 Hours", Value = "7" };
            yield return new SelectListItem { Text = "8 Hours", Value = "8" };
            yield return new SelectListItem { Text = "9 Hours", Value = "9" };
            yield return new SelectListItem { Text = "10 Hours", Value = "10" };
        }

        public IEnumerable<SelectListItem> Phone()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "1 Hour", Value = "1" };
            yield return new SelectListItem { Text = "2 Hours", Value = "2" };
            yield return new SelectListItem { Text = "3 Hours", Value = "3" };
            yield return new SelectListItem { Text = "4 Hours", Value = "4" };
            yield return new SelectListItem { Text = "5 Hours", Value = "5" };
            yield return new SelectListItem { Text = "6 Hours", Value = "6" };
            yield return new SelectListItem { Text = "7 Hours", Value = "7" };
            yield return new SelectListItem { Text = "8 Hours", Value = "8" };
            yield return new SelectListItem { Text = "9 Hours", Value = "9" };
            yield return new SelectListItem { Text = "10 Hours", Value = "10" };
        }

        public IEnumerable<SelectListItem> SleepDiary()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "Yes", Value = "1" };
            yield return new SelectListItem { Text = "No", Value = "2" };

        }

        public IEnumerable<SelectListItem> Music()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "1 Hour", Value = "1" };
            yield return new SelectListItem { Text = "2 Hours", Value = "2" };
            yield return new SelectListItem { Text = "3 Hours", Value = "3" };
            yield return new SelectListItem { Text = "4 Hours", Value = "4" };
            yield return new SelectListItem { Text = "5 Hours", Value = "5" };
        }

        public IEnumerable<SelectListItem> MusicType()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "Electronic", Value = "1" };
            yield return new SelectListItem { Text = "Hip Hop", Value = "2" };
            yield return new SelectListItem { Text = "Rock", Value = "3" };
            yield return new SelectListItem { Text = "Pop", Value = "4" };
            yield return new SelectListItem { Text = "Jazz", Value = "5" };
            yield return new SelectListItem { Text = "Easy Listerning", Value = "6" };
            yield return new SelectListItem { Text = "Blues", Value = "7" };
            yield return new SelectListItem { Text = "Others", Value = "8" };
        }

        public IEnumerable<SelectListItem> SocialMedia()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "1 Hour", Value = "1" };
            yield return new SelectListItem { Text = "2 Hours", Value = "2" };
            yield return new SelectListItem { Text = "3 Hours", Value = "3" };
            yield return new SelectListItem { Text = "4 Hours", Value = "4" };
            yield return new SelectListItem { Text = "5 Hours", Value = "5" };
            yield return new SelectListItem { Text = "6 Hours", Value = "6" };
            yield return new SelectListItem { Text = "7 Hours", Value = "7" };
            yield return new SelectListItem { Text = "8 Hours", Value = "8" };
            yield return new SelectListItem { Text = "9 Hours", Value = "9" };
            yield return new SelectListItem { Text = "10 Hours", Value = "10" };
        }

        public IEnumerable<SelectListItem> VideoGames()
        {
            yield return new SelectListItem { Text = "N/A", Value = "0" };
            yield return new SelectListItem { Text = "1 Hour", Value = "1" };
            yield return new SelectListItem { Text = "2 Hours", Value = "2" };
            yield return new SelectListItem { Text = "3 Hours", Value = "3" };
            yield return new SelectListItem { Text = "4 Hours", Value = "4" };
            yield return new SelectListItem { Text = "5 Hours", Value = "5" };
            yield return new SelectListItem { Text = "6 Hours", Value = "6" };
            yield return new SelectListItem { Text = "7 Hours", Value = "7" };
            yield return new SelectListItem { Text = "8 Hours", Value = "8" };
            yield return new SelectListItem { Text = "9 Hours", Value = "9" };
            yield return new SelectListItem { Text = "10 Hours", Value = "10" };
        }

        public IEnumerable<SelectListItem> Assignments()
        {
            yield return new SelectListItem { Text = "No", Value = "0" };
            yield return new SelectListItem { Text = "Yes", Value = "1" };

        }

        public IEnumerable<SelectListItem> Stress()
        {
            yield return new SelectListItem { Text = "0", Value = "0" };
            yield return new SelectListItem { Text = "1", Value = "1" };
            yield return new SelectListItem { Text = "2", Value = "2" };
            yield return new SelectListItem { Text = "3", Value = "3" };
            yield return new SelectListItem { Text = "4", Value = "4" };
            yield return new SelectListItem { Text = "5", Value = "5" };
        }
    }
}