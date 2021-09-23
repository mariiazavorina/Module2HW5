using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module2HW5.Enums;
using Module2HW5.Exceptions;
using Module2HW5.Services.Abstractions;
using Module2HW5.Configs.Abstractions;
using Module2HW5.Helpers;

namespace Module2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        private readonly ILoggerService _loggerService;
        private readonly IFileService _fileService;
        private readonly IConfig _config;
        public Starter(IActions actions, ILoggerService loggerService, IFileService fileService, IConfig config)
        {
            _actions = actions;
            _loggerService = loggerService;
            _fileService = fileService;
            _config = config;
        }

        public void Run()
        {
            var config = _config.GetConfig().LoggerConfig;
            if (!Directory.Exists(config.DirectoryPath))
            {
                Directory.CreateDirectory(config.DirectoryPath);
            }

            string[] files = Directory.GetFiles(config.DirectoryPath);
            FileInfo[] filesInfo = new FileInfo[files.Length];
            for (var i = 0; i < files.Length; i++)
            {
                filesInfo[i] = new FileInfo(files[i].ToString());
            }

            Array.Sort(filesInfo, new FileComparer());

            for (var i = files.Length - 1; i >= 3; i--)
            {
                filesInfo[i].Delete();
            }

            for (var i = 0; i < 100; i++)
            {
                var random = new Random().Next(1, 4);
                try
                {
                    switch (random)
                    {
                        case 1:
                            _actions.InformationCheck();
                            break;
                        case 2:
                            _actions.WarningCheck();
                            break;
                        case 3:
                            _actions.ErrorCheck();
                            break;
                    }
                }
                catch (WarningException warningException)
                {
                    _loggerService.Write(LogType.Warning, $"Action got this custom exception: {warningException.Message}");
                }
                catch (Exception exception)
                {
                    _loggerService.Write(LogType.Error, "Action failed by reason:", exception);
                }
            }

            string log = _loggerService.GetLog();
            _fileService.WriteInFile(config.DirectoryPath, $"{DateTime.Now.ToString(config.TimeFormat)}{config.FileExtension}", log);
        }
    }
}
