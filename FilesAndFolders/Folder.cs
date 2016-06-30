using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndFolders 
{
    public class Folder
    {
        private string name;
        private string fullPath;

        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.Directory = new DirectoryInfo(fullPath);
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }
        public DirectoryInfo Directory { get; set; }

        public long GetSize()
        {
            return this.Files.Sum(file => file.Size) + this.Folders.Sum(folder => folder.GetSize());
        }

        public IEnumerable<List<File>> GetFiles()
        {
            yield return this.Files.ToList();
        }
    }
}