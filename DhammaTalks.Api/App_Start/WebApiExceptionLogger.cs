using System.Web.Http.ExceptionHandling;

namespace DhammaTalks.Api.App_Start
{
    /// <summary>
    /// A global error handler for WebAPI exceptions.
    /// </summary>
    public class WebApiExceptionLogger : ExceptionLogger
    {
        //private readonly ILog logger = LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            //this.logger.Error(
            //    m =>
            //    m(
            //        "Unhandled exception processing {0} for {1}: {2}",
            //        context.Request.Method,
            //        context.Request.RequestUri,
            //    context.Exception));
        }
    }
}