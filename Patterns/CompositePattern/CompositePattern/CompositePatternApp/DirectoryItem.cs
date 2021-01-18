using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp
{
    public class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Items { get; } = new List<FileSystemItem>();
        public DirectoryItem(string name) : base(name)
        {
        }

        public override decimal GetSizeInKB()
        {
            return Items.Sum(item => item.GetSizeInKB());
        }

        public void Add(FileSystemItem item)
        {
            Items.Add(item);
        }

        public void Remove(FileSystemItem item)
        {
            Items.Remove(item);
        }
    }
}
