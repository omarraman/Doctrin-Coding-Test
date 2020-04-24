using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrin.Api.Resources
{
    public class SaveSettingResource
    {
        public string GlobalId { get; set; }
        public string Value { get; set; }
        public bool Inheritable { get; set; }
    }
}
