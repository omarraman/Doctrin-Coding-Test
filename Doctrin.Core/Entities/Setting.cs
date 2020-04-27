using System.ComponentModel.DataAnnotations;

namespace Doctrin.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string GlobalId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Value { get; set; }
        public bool Inheritable { get; set; }

        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }

    }
}
