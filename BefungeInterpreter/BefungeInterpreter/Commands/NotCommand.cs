//-----------------------------------------------------------------------
// <copyright file="NotCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the not command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the not command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class NotCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public NotCommand(BefungeProgram program) : base("!", "not", program)
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
                program.StackPush(1);
                return;
            }

            // Pops the value.
            int value = program.StackPop();

            // If value is not 0 the interpreter will push 0, otherwise it will push 1.
            if (value != 0)
            {
                program.StackPush(0);
                return;
            }

            program.StackPush(1);
        }
    }
}
