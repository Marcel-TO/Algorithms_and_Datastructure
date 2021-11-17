//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the program of the application.</summary>
//-----------------------------------------------------------------------
namespace SplayTree
{
    using System.Diagnostics.CodeAnalysis;
    using SplayTree.Logic;

    /// <summary>
    /// Represents the program start of the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Program
    {
        /// <summary>
        /// Represents the main method to start the application.
        /// </summary>
        /// <param name="args">Represents the command line arguments.</param>
        public static void Main(string[] args)
        {
            ApplicationLogic application = new ApplicationLogic(new ConsoleLogger(), new KeyboardWatcher.KeyboardWatcher());
            application.Start();
        }
    }
}
