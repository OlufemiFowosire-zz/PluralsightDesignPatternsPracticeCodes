using SmartProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ProxyPatternTests.SmartProxy
{
    public class FileConcurrentWrites
    {
        private readonly string testFile = "output.txt";

        [Fact]
        public void RaisesExceptionWithDirectFileAccess()
        {
            var fs = new DefaultFile();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. ardalis.com\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

            using var file = fs.OpenWrite(testFile);
            //using var file2 = fs.OpenWrite(testFile);

            Assert.Throws<IOException>(
                () => fs.OpenWrite(testFile)
            );

            file.Write(outputBytes1);

            file.Close();
        }

        [Fact]
        public void ManageReferences()
        {
            var fs = new FileSmartProxy();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. ardalis.com\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

            using var file = fs.OpenWrite(testFile);
            using var file2 = fs.OpenWrite(testFile);

            file.Write(outputBytes1);
            file2.Write(outputBytes2);

            file.Close();
            file2.Close();
        }
    }
}
