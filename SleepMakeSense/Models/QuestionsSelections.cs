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
            yield return new SelectListItem { Text = "Please Select", Value = null };
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



                if (Convert.ToDouble(userData.FitbitData.Steps) > 0) CNTSteps++;
                if (Convert.ToDouble(userData.FitbitData.Distance) >= 0) CNTDistance++;
                if (Convert.ToDouble(userData.FitbitData.MinutesSedentary) > 0) CNTMinutesSedentary++;
                if (Convert.ToDouble(userData.FitbitData.MinutesLightlyActive) > 0) CNTMinutesLightlyActive++;
                if (Convert.ToDouble(userData.FitbitData.MinutesFairlyActive) > 0) CNTMinutesFairlyActive++;
                if (Convert.ToDouble(userData.FitbitData.MinutesVeryActive) > 0) CNTMinutesVeryActive++;
                if (Convert.ToDouble(userData.FitbitData.Water) > 0) CNTWater++;

                //Diary Data Counter
                if (Convert.ToDouble(userData.DiaryData.WakeUpFreshness) > 0) CNTWakeUpFreshness++;
                if (Convert.ToDouble(userData.DiaryData.Mood) >= 0) CNTMood++;
                if (Convert.ToDouble(userData.DiaryData.Stress) > 0) CNTStress++;
                if (Convert.ToDouble(userData.DiaryData.Tiredness) > 0) CNTTiredness++;
                if (Convert.ToDouble(userData.DiaryData.Dream) > 0) CNTDream++;
                if (Convert.ToDouble(userData.DiaryData.BodyTemp) > 0) CNTBodyTemp++;
                if (Convert.ToDouble(userData.DiaryData.Hormone) > 0) CNTHormone++; 
                if (Convert.ToDouble(userData.DiaryData.CoffeeAmt) >= 0) CNTCoffeeAmt++;
                if (Convert.ToDateTime(userData.DiaryData.CoffeeTime) != null) CNTCoffeeTime++;
                if (Convert.ToDouble(userData.DiaryData.AlcoholAmt) > 0) CNTAlcoholAmt++;
                if (Convert.ToDateTime(userData.DiaryData.AlcoholTime) != null) CNTAlcoholTime++;
                if (Convert.ToDateTime(userData.DiaryData.NapTime) != null) CNTNapTime++;
                if (Convert.ToDouble(userData.DiaryData.NapDuration) > 0) CNTNapDuration++; 
                if (Convert.ToDouble(userData.DiaryData.DigDeviceDuration) > 0) CNTDigDeviceDuration++;
                if (Convert.ToDouble(userData.DiaryData.GamesDuration) > 0) CNTGamesDuration++;
                if (Convert.ToDouble(userData.DiaryData.SocialActivites) > 0) CNTSocialActivites++;
                if (Convert.ToDouble(userData.DiaryData.SocialActivity) > 0) CNTSocialActivity++;
               // if (Convert.ToDouble(userData.DiaryData.SocialMediaActivity) > 0) CNTSocialMediaActivity++;  Need to Fix the DB and the view for this one
                if (Convert.ToDouble(userData.DiaryData.MusicDuration) >= 0) CNTMusicDuration++;
                if (Convert.ToDouble(userData.DiaryData.TVDuration) > 0) CNTTVDuration++;
                if (Convert.ToDateTime(userData.DiaryData.WorkTime) != null) CNTWorkTime++;
                if (Convert.ToDouble(userData.DiaryData.ExerciseDuration) > 0) CNTExerciseDuration++;
                if (Convert.ToDouble(userData.DiaryData.ExerciseIntensity) > 0) CNTExerciseIntensity++;
                if (Convert.ToDateTime(userData.DiaryData.DinnerTime) != null) CNTDinnerTime++;
                if (Convert.ToDateTime(userData.DiaryData.SnackTime) != null) CNTSnackTime++;
                if (Convert.ToDouble(userData.DiaryData.AmbientTemp) > 0) CNTAmbientTemp++;
                if (Convert.ToDouble(userData.DiaryData.AmbientHumd) > 0) CNTAmbientHumd++;
                if (Convert.ToDouble(userData.DiaryData.Light) > 0) CNTLight++;
                if (Convert.ToDateTime(userData.DiaryData.SunRiseTime) != null) CNTSunRiseTime++;
                if (Convert.ToDateTime(userData.DiaryData.SunSetTime) != null) CNTSunSetTime++;
















