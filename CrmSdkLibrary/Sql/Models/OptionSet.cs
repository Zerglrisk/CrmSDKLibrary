using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Sql.Models
{
    public class OptionSet
    {
        public string OptionSetName { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
    }
}
