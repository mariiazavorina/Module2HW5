using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        public void WriteInFile(string path, string name, string text)
        {
            File.WriteAllText($"{path}{name}", text);
        }
    }
}
