using System.Text;

public interface IFileSystem
{
    bool FileExists(string fileName);
    void FileDelete(string fileName);
    void FileWriteAllText(string fileName, string content, Encoding enconding);
}
