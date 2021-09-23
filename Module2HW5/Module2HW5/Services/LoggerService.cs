using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module2HW5.Enums;
using Module2HW5.Configs.Abstractions;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfig _config;
        private StringBuilder _log = new StringBuilder();
        public LoggerService(IConfig config)
        {
            _config = config;
        }

        public void Write(LogType logType, string message)
        {
            var text = $"{DateTime.Now.ToString(_config.GetConfig().LoggerConfig.TimeFormat)}: {logType}: {message}";
            Console.WriteLine(text);
            _log.AppendLine(text);
        }

        public void Write(LogType logType, string message, Exception exception)
        {
            var text = $"{DateTime.Now.ToString(_config.GetConfig().LoggerConfig.TimeFormat)}: {logType}: {message} {exception}";
            Console.WriteLine(text);
            _log.AppendLine(text);
        }

        public string GetLog()
        {
            string log = _log.ToString();
            return log;
        }
    }
}
