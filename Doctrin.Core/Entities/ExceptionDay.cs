using System;
using System.Collections.Generic;

namespace Doctrin.Core.Entities
{
   public class ExceptionDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CalendarId { get; set; }

        public List<ExceptionSetting> Settings { get; set; }

        public virtual Calendar Calendar
        {
            get;
            set;
        }
    }
}
