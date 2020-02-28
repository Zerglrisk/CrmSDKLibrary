using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmSdkLibrary.Definition.Attribute;

namespace CrmSdkLibrary.Definition.Enum
{
    public enum SortDirection
    {
        [StringValue("ASC")]
        Ascending = 0,
        [StringValue("DESC")]
        Descending
    }
}
