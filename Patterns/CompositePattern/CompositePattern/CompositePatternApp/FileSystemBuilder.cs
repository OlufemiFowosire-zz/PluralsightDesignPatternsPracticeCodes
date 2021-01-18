using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp
{
    public class FileSystemBuilder
    {
        public FileSystemBuilder(string root)
        {
            Root = new DirectoryItem(root);
            currentDirectory = Root;
        }

        public DirectoryItem Root { get; }

        private DirectoryItem currentDirectory;

        public FileSystemItem AddDirectory(string name)
        {
            var subDirectory = new DirectoryItem(name);
            currentDirectory.Add(subDirectory);
            currentDirectory = subDirectory;

            return subDirectory;
        }

        public FileSystemItem AddFile(string name, long fileBytes)
        {
            var file = new FileItem(name, fileBytes);
            currentDirectory.Add(file);

            return file;
        }

        public DirectoryItem SetCurrentDirectory(string directoryName)
        {
            var dirStack = new Stack<DirectoryItem>();
            dirStack.Push(Root);
            while (dirStack.Any())
            {
                var current = dirStack.Pop();
                if(current.Name == directoryName)
                {
                    currentDirectory = current;
                    return current;
                }
                foreach (var item in current.Items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }
            throw new InvalidOperationException($"Directory name: {directoryName} not found!");
        }
    }
}
