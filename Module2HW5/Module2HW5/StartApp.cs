using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Configs.Abstractions;
using Module2HW5.Configs;
using Module2HW5.Services.Abstractions;
using Module2HW5.Services;

namespace Module2HW5
{
    public class StartApp
    {
        public void Start()
        {
            var serviceProvider = new ServiceCollection()
                            .AddSingleton<IConfig, Config>()
                            .AddSingleton<ILoggerService, LoggerService>()
                            .AddTransient<IActions, Actions>()
                            .AddTransient<IFileService, FileService>()
                            .AddTransient<Starter>()
                            .BuildServiceProvider();

            var appStart = serviceProvider.GetService<Starter>();
            appStart.Run();
        }
    }
}
