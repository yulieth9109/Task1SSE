using System;
using System.IO;
using System.Text;


namespace HelloWorld
{
    public class CalculatorExtension : Calculator
    {
        public  bool correctExceptionThrown = false;

        private readonly IFileSystem _fileSystem;
        // used for dependancy injection from a unit test
        public CalculatorExtension(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;

        }
        public CalculatorExtension()
        {
            _fileSystem = new FileSystem();
        }

        public void PrintResult()

        {
            string docPath = Environment.CurrentDirectory + "/Result.txt";
            

            try
            {
                if (_fileSystem.FileExists(docPath) == true)
                {
                    _fileSystem.FileDelete(docPath);
                }
                _fileSystem.FileWriteAllText(docPath, result.ToString(), Encoding.UTF8);
            }
            catch
           {
                correctExceptionThrown = true;
            }
        }
    }
}
