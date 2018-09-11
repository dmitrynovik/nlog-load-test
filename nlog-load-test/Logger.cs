using NLog;

namespace nlog_load_test
{
    class Logger
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();

        public void Log(LogLevel level = null, string message = "Message unspecified")
        {
            _log.Log(level ?? LogLevel.Info, message);
        }
    }
}
