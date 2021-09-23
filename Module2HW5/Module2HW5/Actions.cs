using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module2HW5.Services.Abstractions;
using Module2HW5.Exceptions;
using Module2HW5.Enums;

namespace Module2HW5
{
    public class Actions : IActions
    {
        private readonly ILoggerService _loggerService;
        public Actions(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool InformationCheck()
        {
            _loggerService.Write(LogType.Info, $"Start method: {nameof(InformationCheck)}");
            return true;
        }

        public bool ErrorCheck()
        {
            throw new Exception("I broke a logic!");
        }

        public bool WarningCheck()
        {
            throw new WarningException("Skipped logic in method");
        }
    }
}
