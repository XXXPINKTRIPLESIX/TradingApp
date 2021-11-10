using System;
using Serilog;

namespace Trading.Logging
{
    public class Logger
    {
        public static ILogger Create()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.WithClientIp()
                //.WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void LogException(Exception e)
        {
            Log.Logger
                .ForContext("log", "EXCEPTION")
                .Error("Error: {error_message}\nStack trace: {stack_trace}",
                    e.Message,
                    e.StackTrace);
        }
    }
}