using System.ComponentModel.DataAnnotations;
using Doctrin.Core.Attributes;

namespace Doctrin.Core.Entities
{
    public class Crapping
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(200)]
        public string Value { get; set; }
        public bool Inheritable { get; set; }


    }
}
