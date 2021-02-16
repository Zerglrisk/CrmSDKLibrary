using System;
using WebApi.Definition.Attribute;

namespace WebApi.Definition.Enum
{
    [Flags]
    public enum OperationType : Int32
    {
        [LabelValue("Unknown")]
        Unknown  = 0,
        [LabelValue("Plug-in")]
        PlugIn = 1,
        [LabelValue("Workflow Activity")]
        WorkflowActivity = 2
    }
}
