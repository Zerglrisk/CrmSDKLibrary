using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_ADAL.Definition.Enum
{
    [Flags]
    public enum QualifyLeadEntity
    {
        None = 0,
        Account = 1,
        Contact = 2,
        Opportunity = 4
    }
}
