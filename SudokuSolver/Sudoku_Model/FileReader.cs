//-----------------------------------------------------------------------
// <copyright file="FileReader.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the file reader of the sudoku board.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model
{
    using System;
    using System.IO;
    using Sudoku_Model.EventArgs;

    /// <summary>
    /// Represents the file reader.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Occurs if the file reader was able to read the file.
        /// </summary>
        public event EventHandler<FileEventArgs> FileRead;

        /// <summary>
        /// Represents the method reading the file.
        /// </summary>
        /// <param name="path">The path of the current file.</param>
        public void ReadFile(string path)
        {
            string content;

            try
            {
                content = File.ReadAllText(path);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (PathTooLongException)
            {
                return;
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }
            catch (FileNotFoundException)
            {
                return;
            }
            catch (IOException)
            {
                return;
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            catch (NotSupportedException)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }

            this.FileRead?.Invoke(this, new FileEventArgs(content));
        }
    }
}
