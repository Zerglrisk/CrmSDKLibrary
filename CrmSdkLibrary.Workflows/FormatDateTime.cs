using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

/// <summary>
/// Tested
/// Microsoft.CrmSdk.CoreAssemblies Version v9.0.2.3
/// Microsoft.CrmSdk.Workflow Version 9.0.2.3
/// </summary>
public class FormatDateTime : System.Activities.CodeActivity
{
	#region Arguments

	[RequiredArgument]
	[Default("yyyyMMddHHmmssfff")]
	[Input("Format of DateTime")]
	public InArgument<string> DateFormat { get; set; }

	[RequiredArgument]
	[Input("DateTime to format")]
	public InArgument<DateTime> DateTime { get; set; }

    [Input("Convert to User Local Time")]
    [Default("true")]
    public InArgument<bool> ConvertToUserTime { get; set; }

    [Output("Formatted DateTime")]
	public OutArgument<string> Result { get; set; }

	#endregion Arguments

	protected override void Execute(CodeActivityContext context)
	{
		//Create the tracing service
		ITracingService tracingService = context.GetExtension<ITracingService>();
		IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
        IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
        IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

		try
		{
            if (this.DateTime.Get<DateTime?>(context) == null)
            {
                tracingService.Trace("Input DateTime Is Null");
                return;
            }

            var inputDateTime = this.DateTime.Get<DateTime>(context);
            var convertToUserTime = this.ConvertToUserTime.Get<bool>(context);

            if (convertToUserTime)
            {
                inputDateTime = Common.GetUserDateTime(service, workflowContext.UserId, inputDateTime);
            }

            if (!string.IsNullOrEmpty(this.DateFormat.Get<string>(context)))
            {
                try
                {
                    this.Result.Set(context, inputDateTime.ToString(this.DateFormat.Get<string>(context)));
                }
                catch
                {
                    tracingService.Trace("Failed Format using Provided. Try Format default value : yyyyMMddHHmmssfff");
                    this.Result.Set(context, inputDateTime.ToString("yyyyMMddHHmmssfff"));
                }
            }
            else
            {
                this.Result.Set(context, inputDateTime.ToString("yyyyMMddHHmmssfff"));
            }
        }
        catch(Exception ex)
        {
            tracingService.Trace("Error in FormatDateTime: {0}", ex.ToString());
            throw new InvalidPluginExecutionException("An error occurred in FormatDateTime: " + ex.Message, ex);
        }
    }
}

//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Workflow.Activities;
//using Microsoft.Crm.Workflow;
//using System.Workflow.ComponentModel;
//using Microsoft.Crm.Sdk;

// Microsoft Dynamics CRM 4.0
//[CrmWorkflowActivity("Formats date time with required format", "Formatting Routines")]
//public class FormatDateTime : SequenceActivity
//{
//    protected override System.Workflow.ComponentModel.ActivityExecutionStatus Execute(System.Workflow.ComponentModel.ActivityExecutionContext executionContext)
//    {
//        string result = string.Empty;

//        if (!string.IsNullOrEmpty(DateFormat) && datetime != null)
//        {
//            result = DateTime.Parse(datetime.Value).ToString(DateFormat);
//        }

//        Result = result;

//        return ActivityExecutionStatus.Closed;
//    }

//    public static DependencyProperty DateFormatProperty = DependencyProperty.Register("DateFormat", typeof(string), typeof(FormatDateTime));

//    [CrmInput("Format of DateTime")]
//    public string DateFormat
//    {
//        get
//        {
//            return (string)base.GetValue(DateFormatProperty);
//        }
//        set
//        {
//            base.SetValue(DateFormatProperty, value);
//        }
//    }

//    public static DependencyProperty datetimeProperty = DependencyProperty.Register("datetime", typeof(CrmDateTime), typeof(FormatDateTime));

//    [CrmInput("DateTime to format")]
//    public CrmDateTime datetime
//    {
//        get
//        {
//            return (CrmDateTime)base.GetValue(datetimeProperty);
//        }
//        set
//        {
//            base.SetValue(datetimeProperty, value);
//        }
//    }

//    public static DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string), typeof(FormatDateTime));

//    [CrmOutput("Formatted DateTime")]
//    public string Result
//    {
//        get
//        {
//            return (string)base.GetValue(ResultProperty);
//        }
//        set
//        {
//            base.SetValue(ResultProperty, value);
//        }
//    }
//}