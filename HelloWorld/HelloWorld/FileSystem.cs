using System;
using System.Text;

public class FileSystem : IFileSystem
{
    public bool FileExists(string fileName)
    {
        return System.IO.File.Exists(fileName);
    }

    public void  FileDelete(string fileName)
    {
        System.IO.File.Delete(fileName);
    }

    public void FileWriteAllText(string fileName, string content, Encoding enconding)
    {
        System.IO.File.WriteAllText(fileName, content, enconding);
    }
}
