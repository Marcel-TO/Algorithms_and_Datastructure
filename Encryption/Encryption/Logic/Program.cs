//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the program class of the application.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the program class of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents the main method of the application.
        /// </summary>
        /// <param name="args">The arguments of the application.</param>
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args)
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLogger(), new KeyboardWatcher());
            logic.Run();
        }
    }
}
