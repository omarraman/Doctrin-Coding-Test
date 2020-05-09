using System;
using System.Collections.Generic;
using System.Text;

namespace Doctrin.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ParentId : Attribute
    {
    }
}
