//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the start program of the application.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Logic
{
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
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLogger(), new KeyboardWatcher());
            logic.Run();
        }
    }
}
