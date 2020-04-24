using System.ComponentModel.DataAnnotations;

namespace Doctrin.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        [Required]
        public string GlobalId { get; set; }

        [Required]
        public string Value { get; set; }
        public bool Inheritable { get; set; }

        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }




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
