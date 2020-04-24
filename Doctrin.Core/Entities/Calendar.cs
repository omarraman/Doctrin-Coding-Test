using System;
using System.Collections.Generic;

namespace Doctrin.Core.Entities
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual List<ExceptionDay> ExceptionDays { get; set; }
    }
}
