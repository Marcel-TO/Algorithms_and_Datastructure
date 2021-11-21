namespace BefungeInterpreter.FileInteractions
{
    using System;
    using System.IO;

    public class FileReader
    {
        public string[] ReadFile(string path)
        {
            string[] content;

            try
            {
                content = File.ReadAllLines(path);
            }
            catch (Exception)
            {
                return null;
            }

            return content;
        }
    }
}
