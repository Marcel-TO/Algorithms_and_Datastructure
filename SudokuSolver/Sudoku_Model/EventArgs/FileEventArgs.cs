//-----------------------------------------------------------------------
// <copyright file="FileEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the event arguments of an event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model.EventArgs
{
    using System;

    /// <summary>
    /// Represents the arguments of an event.
    /// </summary>
    public class FileEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the content of the selected file.
        /// </summary>
        private string content;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEventArgs"/> class.
        /// </summary>
        /// <param name="content">The content of the selected file.</param>
        public FileEventArgs(string content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets the content of the selected file.
        /// </summary>
        /// <value>The content of the selected file.</value>
        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.content = value;
            }
        }
    }
}
