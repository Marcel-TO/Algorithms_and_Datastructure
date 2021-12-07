﻿//-----------------------------------------------------------------------
// <copyright file="PopCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the pop command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the pop command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class PopCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public PopCommand(BefungeProgram program) : base("$", "pop", program)
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

            // Checks if there is no value to be popped.
            if (program.Stack.Count == 0)
            {
                return;
            }

            // Pop the value.
            program.StackPop();
        }
    }
}
