using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    public class OnlyForViewing : Attribute
    {
        
    }
}
