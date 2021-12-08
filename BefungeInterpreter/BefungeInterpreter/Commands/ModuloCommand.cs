//-----------------------------------------------------------------------
// <copyright file="ModuloCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the modulo command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the modulo command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class ModuloCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuloCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public ModuloCommand(BefungeProgram program) : base("%", "modulo", program)
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
                return;
            }

            // Pops values from the stack.
            int value2 = program.StackPop();
            int value1 = program.StackPop();

            // Checks if values are zero to avoid dividing by 0.
            if (value2 == 0 || value1 == 0)
            {
                program.StackPush(0);
                return;
            }

            // Calculates the modulo of the values and pushes the result on the stack.
            int res = value1 % value2;
            program.StackPush(res);
        }
    }
}
