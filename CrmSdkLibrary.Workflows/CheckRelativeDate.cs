using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

public class CheckRelativeDate : System.Activities.CodeActivity
{
    [Input("날짜 필드")]
    [RequiredArgument]
    public InArgument<DateTime> DateField { get; set; }

    [Input("조건 (ThisYear/LastYear/NextYear/ThisQuarter/LastQuarter/ThisMonth/LastMonth)")]
    [RequiredArgument]
    [Default("ThisYear")]
    public InArgument<string> Condition { get; set; }

    [Output("조건 충족")]
    public OutArgument<bool> IsConditionMet { get; set; }

    protected override void Execute(CodeActivityContext executionContext)
    {
        ITracingService tracingService = executionContext.GetExtension<ITracingService>();
        IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

        try
        {
            DateTime dateField = DateField.Get(executionContext);
            string condition = Condition.Get(executionContext);
            DateTime today = DateTime.Today;
            bool result = false;

            tracingService.Trace($"[CheckRelativeDate] 입력 날짜: {dateField:yyyy-MM-dd}, 조건: {condition}");

            if (string.IsNullOrWhiteSpace(condition))
            {
                throw new InvalidPluginExecutionException("조건 값이 비어있습니다.");
            }

            // 대소문자 구분 없이 처리
            switch (condition.Trim().ToUpper())
            {
                case "THISYEAR":
                case "올해":
                    result = dateField.Year == today.Year;
                    tracingService.Trace($"올해 체크: {dateField.Year} == {today.Year} = {result}");
                    break;

                case "LASTYEAR":
                case "작년":
                    result = dateField.Year == today.Year - 1;
                    tracingService.Trace($"작년 체크: {dateField.Year} == {today.Year - 1} = {result}");
                    break;

                case "NEXTYEAR":
                case "내년":
                    result = dateField.Year == today.Year + 1;
                    tracingService.Trace($"내년 체크: {dateField.Year} == {today.Year + 1} = {result}");
                    break;

                case "THISQUARTER":
                case "이번분기":
                    int currentQuarter = GetQuarter(today);
                    int dateQuarter = GetQuarter(dateField);
                    result = dateQuarter == currentQuarter && dateField.Year == today.Year;
                    tracingService.Trace($"이번 분기 체크: Q{dateQuarter} == Q{currentQuarter} && {dateField.Year} == {today.Year} = {result}");
                    break;

                case "LASTQUARTER":
                case "지난분기":
                    var lastQuarterDate = today.AddMonths(-3);
                    int lastQuarter = GetQuarter(lastQuarterDate);
                    int dateQuarter2 = GetQuarter(dateField);
                    result = dateQuarter2 == lastQuarter && dateField.Year == lastQuarterDate.Year;
                    tracingService.Trace($"지난 분기 체크: Q{dateQuarter2} == Q{lastQuarter} && {dateField.Year} == {lastQuarterDate.Year} = {result}");
                    break;

                case "THISMONTH":
                case "이번달":
                    result = dateField.Year == today.Year && dateField.Month == today.Month;
                    tracingService.Trace($"이번 달 체크: {dateField:yyyy-MM} == {today:yyyy-MM} = {result}");
                    break;

                case "LASTMONTH":
                case "지난달":
                    var lastMonth = today.AddMonths(-1);
                    result = dateField.Year == lastMonth.Year && dateField.Month == lastMonth.Month;
                    tracingService.Trace($"지난 달 체크: {dateField:yyyy-MM} == {lastMonth:yyyy-MM} = {result}");
                    break;

                default:
                    string errorMsg = $"지원하지 않는 조건: '{condition}'. " +
                                    "사용 가능한 값: ThisYear, LastYear, NextYear, ThisQuarter, LastQuarter, ThisMonth, LastMonth " +
                                    "(또는 한글: 올해, 작년, 내년, 이번분기, 지난분기, 이번달, 지난달)";
                    tracingService.Trace($"오류: {errorMsg}");
                    throw new InvalidPluginExecutionException(errorMsg);
            }

            tracingService.Trace($"[CheckRelativeDate] 최종 결과: {result}");
            IsConditionMet.Set(executionContext, result);
        }
        catch (Exception ex)
        {
            tracingService.Trace($"[CheckRelativeDate] 예외 발생: {ex.ToString()}");
            throw new InvalidPluginExecutionException($"CheckRelativeDate 실행 중 오류: {ex.Message}", ex);
        }
    }

    private int GetQuarter(DateTime date)
    {
        return (date.Month - 1) / 3 + 1;
    }
}