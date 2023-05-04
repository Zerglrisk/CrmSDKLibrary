using System;
using WebApi_ADAL.Definition.Attribute;

namespace WebApi_ADAL.Definition.Enum
{
    [Flags]
    public enum OperationType : int
    {
        [LabelValue("Unknown")]
        Unknown = 0,
        [LabelValue("Plug-in")]
        PlugIn = 1,
        [LabelValue("Workflow Activity")]
        WorkflowActivity = 2
    }
}
