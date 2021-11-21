namespace BefungeInterpreter.FileInteractions
{
    using BefungeInterpreter.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileCollector
    {
        private ILogger logger;

        private string mainPath;

        public FileCollector(ILogger logger)
        {
            this.logger = logger;
            this.mainPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms"));
        }

        public string[] GetFiles()
        {
            string[] allPaths;

            // TryCatch
            allPaths = Directory.GetFileSystemEntries(this.mainPath, "*", SearchOption.AllDirectories);

            return allPaths;
        }
    }
}
