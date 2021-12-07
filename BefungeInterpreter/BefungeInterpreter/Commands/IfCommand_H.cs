//-----------------------------------------------------------------------
// <copyright file="IfCommand_H.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the horizontal if command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the horizontal if command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class IfCommand_H : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IfCommand_H"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public IfCommand_H(BefungeProgram program) : base("_", "if_horizontal", program)
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
                program.Direction = Direction.Right;
                return;
            }

            // Pops value
            int boolValue = program.StackPop();

            // If value is not 0 the direction changes to left, otherwise right.
            if (boolValue != 0)
            {
                program.Direction = Direction.Left;
                return;
            }

            program.Direction = Direction.Right;
        }
    }
}
