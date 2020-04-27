using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doctrin.Core.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Unit Parent { get; set; }

        public virtual List<Unit> Children { get; set; }

        public virtual  List<Setting> Settings { get; set; }
        public virtual List<Calendar> Calendars { get; set; }

    }
}
