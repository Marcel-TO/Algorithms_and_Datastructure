//-----------------------------------------------------------------------
// <copyright file="FileCollector.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for collecting all files in the supported directory.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.FileInteractions
{
    using System;
    using System.IO;
    using BefungeInterpreter.Interfaces;

    /// <summary>
    /// Represents the class for collecting all files in the supported directory.
    /// </summary>
    public class FileCollector
    {
        /// <summary>
        /// Represents the logger of the application.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Represents the main path to the supported directory.
        /// </summary>
        private string mainPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCollector"/> class.
        /// </summary>
        /// <param name="logger">The logger of the application.</param>
        public FileCollector(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException($"The {nameof(logger)} must not be null.");
            }

            this.logger = logger;
            this.mainPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms"));
        }

        /// <summary>
        /// Represents the method for collecting all files.
        /// </summary>
        /// <returns>The paths of all files.</returns>
        public string[] GetFiles()
        {
            string[] allPaths;

            // TryCatch
            allPaths = Directory.GetFileSystemEntries(this.mainPath, "*", SearchOption.AllDirectories);

            return allPaths;
        }
    }
}
