﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Services.Abstractions
{
    public interface IFileService
    {
        public void WriteInFile(string path, string name, string text);
    }
}
