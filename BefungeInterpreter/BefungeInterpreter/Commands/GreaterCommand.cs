﻿//-----------------------------------------------------------------------
// <copyright file="GreaterCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the greater command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the greater command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class GreaterCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public GreaterCommand(BefungeProgram program) : base("`", "greater", program)
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

            // Pops the values.
            int value2 = program.StackPop();
            int value1 = program.StackPop();

            // If value 1 is greater than value 2, the interpreter pushes 1.
            if (value1 > value2)
            {
                program.StackPush(1);
                return;
            }

            // If not the interpreter pushes 0.
            program.StackPush(0);
        }
    }
}
