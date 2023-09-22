using Microsoft.AspNetCore.Mvc.Filters;

namespace FlipkartApi.Filters
{
    public class LogActionFilter : ActionFilterAttribute, IActionFilter
    {
        string fileParh = @"E:\RecentRepos\FlipkartApi\LogData\LogFile.txt";

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string methodName=context.HttpContext.Request.Method;
            string dateTime = DateTime.Now.ToString("yyyy-MM_DD HH:mm:ss");

            string logMessage = $"{dateTime}:\t controller:{controllerName}\t action:{actionName}\t Method:{methodName}";
            using (StreamWriter writer = new StreamWriter(fileParh, append: true))//File.AppendText(filePath))
            {
                //writer.WriteLine(logMessage);
                writer.WriteLine(logMessage);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnException(ExceptionContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
