using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

public class SplitDateParts : System.Activities.CodeActivity
{
    #region Arguments

    #region In Arguments

    [RequiredArgument]
    [Input("DateTime")]
    public InArgument<DateTime> DateTime { get; set; }

    [Input("Convert to User Local Time")]
    [Default("true")]
    public InArgument<bool> ConvertToUserTime { get; set; }

    #endregion In Arguments

    #region Out Arguments

    [Output("Year")]
    public OutArgument<int> Year { get; set; }

    /// <summary>
    /// Single Line Text 출력 시 2,025 로 표시됨 방지
    /// </summary>
    [Output("YearString")]
    public OutArgument<string> YearString { get; set; }

    [Output("Month")]
    public OutArgument<int> Month { get; set; }

    [Output("Day")]
    public OutArgument<int> Day { get; set; }

    [Output("Hour")]
    public OutArgument<int> Hour { get; set; }

    [Output("Minute")]
    public OutArgument<int> Minute { get; set; }

    [Output("Second")]
    public OutArgument<int> Second { get; set; }

    [Output("Day Of Week (Number)")]
    public OutArgument<int> DayOfWeek { get; set; }

    [Output("Quarter")]
    public OutArgument<int> Quarter { get; set; }

    [Output("Day Of Year")]
    public OutArgument<int> DayOfYear { get; set; }

    #endregion Out Arguments

    #endregion Arguments

    protected override void Execute(CodeActivityContext context)
    {
        ITracingService tracingService = context.GetExtension<ITracingService>();
        IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
        IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
        IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

        try
        {
            if (this.DateTime.Get<DateTime?>(context) == null)
            {
                return;
            }

            DateTime inputDateTime = this.DateTime.Get<DateTime>(context);
            var convertToUserTime = this.ConvertToUserTime.Get<bool>(context);

            if (convertToUserTime)
            {
                inputDateTime = Common.GetUserDateTime(service, workflowContext.UserId, inputDateTime);
            }

            int year = inputDateTime.Year;
            int month = inputDateTime.Month;
            int day = inputDateTime.Day;
            int hour = inputDateTime.Hour;
            int minute = inputDateTime.Minute;
            int second = inputDateTime.Second;
            int dayOfWeek = (int)inputDateTime.DayOfWeek;
            int quarter = (inputDateTime.Month - 1) / 3 + 1;
            int dayOfYear = inputDateTime.DayOfYear;

            Year.Set(context, year);
            YearString.Set(context, year.ToString());
            Month.Set(context, month);
            Day.Set(context, day);
            Hour.Set(context, hour);
            Minute.Set(context, minute);
            Second.Set(context, second);
            DayOfWeek.Set(context, dayOfWeek);
            Quarter.Set(context, quarter);
            DayOfYear.Set(context, dayOfYear);

            tracingService.Trace($"[SplitDateParts] Completed");
        }
        catch (Exception ex)
        {
            tracingService.Trace($"[SplitDateParts] Error: {ex.ToString()}");
            throw new InvalidPluginExecutionException($"Error: {ex.Message}", ex);
        }
    }
}