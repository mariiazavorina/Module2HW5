using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Configs.Abstractions
{
    public interface IConfig
    {
        public LoggerConfig LoggerConfig { get; init; }
        public Config GetConfig();
    }
}
