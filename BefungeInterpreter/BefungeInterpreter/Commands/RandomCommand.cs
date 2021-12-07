//-----------------------------------------------------------------------
// <copyright file="RandomCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the random command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the random command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class RandomCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public RandomCommand(BefungeProgram program) : base("?", "random", program)
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

            Random random = new Random();
            int r = random.Next(0, 4);

            // Switches to a random direction.
            switch (r)
            {
                case 0:
                    program.Direction = Direction.Up;
                    break;
                case 1:
                    program.Direction = Direction.Right;
                    break;
                case 2:
                    program.Direction = Direction.Down;
                    break;
                case 3:
                    program.Direction = Direction.Left;
                    break;
            }
        }
    }
}
