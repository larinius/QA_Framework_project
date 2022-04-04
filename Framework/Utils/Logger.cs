using NLog;
using System;
using System.IO;

namespace Task3.Framework.Utils
{
    internal class Logger
    {
        private static Logger? instance;
        private static NLog.Logger nlog;

        private static NLog.Logger GetNlog()
        {
            if (instance == null)
                instance = new Logger();

            return nlog;
        }

        private Logger()
        {
            var logDir = Path.Combine(AppContext.BaseDirectory, Config.Log["Path"]);

            var logFile = Path.Combine(logDir, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log");

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            var config = new NLog.Config.LoggingConfiguration();

            var fileTarget = new NLog.Targets.FileTarget();

            NLog.Common.InternalLogger.LogFile = Path.Combine(AppContext.BaseDirectory, Config.Log["Path"], @"nlog.log");

            NLog.Common.InternalLogger.LogLevel = LogLevel.Info;

            fileTarget.FileName = logFile;

            fileTarget.Layout = Config.Log["Layout"];

            var asyncWrapper = new NLog.Targets.Wrappers.AsyncTargetWrapper(fileTarget, 1000, NLog.Targets.Wrappers.AsyncTargetWrapperOverflowAction.Grow);

            var rule = new NLog.Config.LoggingRule("*", NLog.LogLevel.Trace, asyncWrapper);

            config.LoggingRules.Add(rule);

            NLog.LogManager.Configuration = config;

            nlog = NLog.LogManager.GetLogger("NUnitTest");
        }

        public static void Info(string message)
        {
            Logger.GetNlog().Log(NLog.LogLevel.Info, message);
        }

        public static void Warning(string message)
        {
            Logger.GetNlog().Log(NLog.LogLevel.Warn, message);
        }

        public static void Error(string message)
        {
            Logger.GetNlog().Log(NLog.LogLevel.Error, message);
        }
    }
}