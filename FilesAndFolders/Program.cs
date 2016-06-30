using System;
using System.Linq;
using System.Text;

namespace FilesAndFolders
{
    class Program
    {
        public static void Main(string[] args)
        {
            var entryPoint = new Folder("Help", @"C:\Windows\Help");

            GetSubFolders(entryPoint);

            StringBuilder result = new StringBuilder();

            GetFileSystemString(entryPoint, result, 0);

            Console.WriteLine(result);
        }

        private static void GetFileSystemString(Folder folder, StringBuilder result, int depth)
        {
            string indent = new string('.', depth * 3);

            result.AppendLine(string.Format("{0}{1} size: {2}", indent, folder.Name, folder.GetSize()));

            folder.Files.ForEach(file => result.AppendLine(string.Format(".{0}-{1} size: {2}", indent, file.Name, file.Size)));

            folder.Folders.ForEach(subFolder => GetFileSystemString(subFolder, result, depth + 1));
        }
        private static void GetSubFolders(Folder folder)
        {
            folder.Directory.GetFiles().ToList().ForEach(file => folder.Files.Add(new File(file.Name, file.Length)));

            folder.Directory.GetDirectories().ToList().ForEach(subDir => {
                var subFolder = new Folder(subDir.Name, subDir.FullName);

                folder.Folders.Add(subFolder);

                GetSubFolders(subFolder);
            });
        }
    }
}
