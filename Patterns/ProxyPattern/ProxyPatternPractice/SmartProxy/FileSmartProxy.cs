using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartProxy
{
    public class FileSmartProxy : IFile
    {
        private Dictionary<string, FileStream> openStreams = new Dictionary<string, FileStream>();
        public FileStream OpenWrite(string path)
        {
            try
            {
                var stream = File.OpenWrite(path);
                openStreams.Add(path, stream);
                return stream;
            }
            catch (IOException)
            {
                if (openStreams.ContainsKey(path))
                {
                    var stream = openStreams[path];
                    if(stream!=null && stream.CanWrite)
                    {
                        return stream;
                    }
                }
                throw;
            }
        }
    }
}
