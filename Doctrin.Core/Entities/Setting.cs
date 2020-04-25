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

    }
}
