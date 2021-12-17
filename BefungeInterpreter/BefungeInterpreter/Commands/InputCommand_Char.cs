//-----------------------------------------------------------------------
// <copyright file="InputCommand_Char.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the character input command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using System.Text;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the character input command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class InputCommand_Char : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputCommand_Char"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public InputCommand_Char(BefungeProgram program) : base("~", "input char", program)
        {
        }

        /// <summary>
        /// Represents the visitor pattern for command execution.
        /// </summary>
        /// <param name="visitor">The used visitor interface.</param>
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Represents the execution method of the current command.
        /// </summary>
        /// <param name="program">The <see cref="BefungeProgram"/> that gets interpreted.</param>
        /// <param name="character">The character from the user input.</param>
        /// <param name="logger">The logger of the application.</param>
        public void Execute(BefungeProgram program, char character, ILogger logger)
        {
            // Checks if parameters are null or wrong.
            if (program == null)
            {
                throw new ArgumentNullException($"The {nameof(program)} must not be null.");
            }
            else if (logger == null)
            {
                throw new ArgumentNullException($"The {nameof(logger)} must not be null.");
            }
            else if (character < 32 || character > 127)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(character)} must be in the supported ascii range.");
            }

            program.StackPush(character);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
