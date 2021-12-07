//-----------------------------------------------------------------------
// <copyright file="DuplicationCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the duplication command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the duplication command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class DuplicationCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicationCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public DuplicationCommand(BefungeProgram program) : base(":", "duplication", program)
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
        public void Execute(BefungeProgram program)
        {
            // Checks if the parameter is null.
            if (program == null)
            {
                throw new ArgumentNullException($"The {nameof(program)} must not be null.");
            }

            // Checks if there are no values to be popped.
            if (program.Stack.Count == 0)
            {
                program.StackPush(0);
            }

            // Checks the value on top of the stack and pushes the same value again.
            int value = program.Stack.Peek();
            program.StackPush(value);
        }
    }
}
