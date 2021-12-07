//-----------------------------------------------------------------------
// <copyright file="ExitThreadArguments.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the event args for the running thread.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.EventArgs
{
    /// <summary>
    /// Represents the event arguments for the exiting thread.
    /// </summary>
    public class ExitThreadArguments
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitThreadArguments"/> class.
        /// </summary>
        public ExitThreadArguments()
        {
            this.IsExit = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the thread is allowed to exit.
        /// </summary>
        /// <value>The value indicating whether the thread is allowed to exit.</value>
        public bool IsExit
        {
            get;
            set;
        }
    }
}
