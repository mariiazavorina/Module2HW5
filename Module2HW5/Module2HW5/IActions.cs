using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public interface IActions
    {
        public bool InformationCheck();

        public bool ErrorCheck();

        public bool WarningCheck();
    }
}
