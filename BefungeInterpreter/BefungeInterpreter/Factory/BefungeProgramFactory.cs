//-----------------------------------------------------------------------
// <copyright file="BefungeProgramFactory.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the factory for creating the befunge program.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Factory
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Execptions;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Represents the factory for creating the <see cref="BefungeProgram"/>.
    /// </summary>
    public class BefungeProgramFactory
    {
        /// <summary>
        /// Represents the file reader.
        /// </summary>
        private FileReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="BefungeProgramFactory"/> class.
        /// </summary>
        public BefungeProgramFactory()
        {
            this.reader = new FileReader();
        }

        /// <summary>
        /// Represents the method for creating the <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="path">The path of all possible programs.</param>
        /// <returns>The new created program.</returns>
        public BefungeProgram CreateBefungeProgram(string path)
        {
            // Checks if the parameter is null.
            if (path == null)
            {
                throw new ArgumentNullException($"The {nameof(path)} must not be null.");
            }

            // Gets the content of the current file.
            string[] content = this.reader.ReadFile(path);

            // Checks if the file reader can't access the file's content.
            if (content == null)
            {
                throw new BefungeProgramNotPossible($"The file {path} is not a valid for a Befunge program.");
            }

            bool isValid = true;

            // Checks if the lines are not more than 80 characters long.
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Length > 80)
                {
                    isValid = false;
                }
            }

            // Checks if the validation is wrong or the amount of lines are over the supported 25.
            if (!isValid || content.Length > 25)
            {
                throw new BefungeProgramNotPossible($"The file {path} is not a valid for a Befunge program.");
            }

            Stack<int> stack = new Stack<int>();

            // Creates a new program to interpret.
            BefungeProgram program = new BefungeProgram(stack, content, new Position(0, 0));

            return program;
        }
    }
}
