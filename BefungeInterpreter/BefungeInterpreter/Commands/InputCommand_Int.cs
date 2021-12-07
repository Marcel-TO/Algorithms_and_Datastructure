//-----------------------------------------------------------------------
// <copyright file="InputCommand_Int.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the integer input command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the integer input command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class InputCommand_Int : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputCommand_Int"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public InputCommand_Int(BefungeProgram program) : base("&", "input int", program)
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
        /// <param name="number">The number from the user input.</param>
        /// <param name="logger">The logger of the application.</param>
        public void Execute(BefungeProgram program, int number, ILogger logger)
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
            else if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(number)} must be between 0 and 9.");
            }

            // Pushes number on stack.
            program.StackPush(number);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
