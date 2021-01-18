using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartProxy
{
    public class DefaultFile : IFile
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}
