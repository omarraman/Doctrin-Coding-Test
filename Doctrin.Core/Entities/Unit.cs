using System.Collections.Generic;

namespace Doctrin.Core.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public Unit Parent { get; set; }

        public virtual List<Unit> Children { get; set; }

        public virtual  List<Setting> Settings { get; set; }
        public virtual List<Calendar> Calendars { get; set; }

        //public string GetSetting(string id,DateTime? dateTime, bool inheritedSetting = false)
        //{
        //    var setting = Settings.SingleOrDefault(m => m.Id == id && m.Inheritable == inheritedSetting);
        //    return setting == null ? Parent?.GetSetting(id,dateTime, true) : setting.Value;
        //}

        //public string GetCalendarizedSetting(string id, DateTime dateTime, bool inheritedSetting = false)
        //{
        //    var setting = Settings.SingleOrDefault(m => m.Id == id && m.Inheritable == inheritedSetting);
        //    return setting == null ? Parent?.GetSetting(id, dateTime, true) : setting.GetCalendarizedSettingValue(id, dateTime);
        //}


        //public string GetSettingValueForDate(string settingId, DateTime dateTime)
        //{
        //    var setting = CalendarizedSettings.SingleOrDefault(m => m.Id == settingId);

        //    if (setting!=null)
        //    {
        //        foreach (var calendar in Calendars)
        //        {
        //            if (dateTime >= calendar.StartDateTime && dateTime <= calendar.EndDateTime && !calendar.ExceptionDay.Contains((dateTime))) //if a calendar is active for this date and not on an exception day
        //            {
        //                var settingCalendarValue = setting.SettingCalendarValues.SingleOrDefault(m => m.DateTime == dateTime); //does our scv have a setting for this datetime

        //                if (settingCalendarValue != null)
        //                {
        //                    return settingCalendarValue.Value;
        //                }
        //            }
        //        }
        //    }



        //    return null;
        //}


    }
}
