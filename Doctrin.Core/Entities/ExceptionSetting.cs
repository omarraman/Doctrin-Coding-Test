namespace Doctrin.Core.Entities
{
    public class ExceptionSetting
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public string SettingId { get; set; }
        public int ExceptionDayId { get; set; }

        public virtual Setting Setting { get; set; }
        public virtual ExceptionDay ExceptionDay { get; set; }




        //public string GetCalendarizedSettingValue(string id, DateTime dateTime)
        //{
        //    if (Calendars.Count == 0) //setting not calendarized, always valid
        //    {
        //        return Value;
        //    }

        //    foreach (var calendar in Calendars)
        //    {
        //        if (dateTime >= calendar.StartDateTime && dateTime <= calendar.EndDateTime &&
        //            !calendar.ExceptionDay.Contains((dateTime))
        //        ) //if a calendar is active for this date and not on an exception day
        //        {
        //            return Value;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }



        //    return null;
        //}
    }
}
