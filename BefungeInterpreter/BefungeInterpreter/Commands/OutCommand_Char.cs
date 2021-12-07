//-----------------------------------------------------------------------
// <copyright file="OutCommand_Char.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the character output command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using System.Text;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the character output command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class OutCommand_Char : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutCommand_Char"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public OutCommand_Char(BefungeProgram program) : base(",", "output char", program)
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
                return;
            }

            // Pops the value.
            int value = program.StackPop();

            byte[] byteValue = new byte[] { Convert.ToByte(value) };
            program.Output.Add(Encoding.ASCII.GetString(byteValue));
        }
    }
}
