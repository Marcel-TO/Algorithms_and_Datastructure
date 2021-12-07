//-----------------------------------------------------------------------
// <copyright file="FileReader.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the file reader of the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.FileInteractions
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents the class for reading from file.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Represents the method for reading from the file.
        /// </summary>
        /// <param name="path">The path of the current file.</param>
        /// <returns>The content of the file.</returns>
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
