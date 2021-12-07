//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the program class of the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    /// <summary>
    /// Represents the program class of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents the main method of the application.
        /// </summary>
        /// <param name="args">The arguments of the application.</param>
        public static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            IKeyboardWatcher keyboardWatcher = new KeyboardWatcher();

            ApplicationLogic logic = new ApplicationLogic(logger, keyboardWatcher);
            logic.Run();
        }
    }
}
