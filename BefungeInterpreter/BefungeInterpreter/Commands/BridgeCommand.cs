//-----------------------------------------------------------------------
// <copyright file="BridgeCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the bridge command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the bridge command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class BridgeCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> which gets interpreted.</param>
        public BridgeCommand(BefungeProgram program) : base("#", "bridge", program)
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
        /// <param name="logger">The logger of the current program.</param>
        public void Execute(BefungeProgram program, ILogger logger)
        {
            // Checks if the parameter is null.
            if (program == null)
            {
                throw new ArgumentNullException($"The {nameof(program)} must not be null.");
            }

            // Jumps over the next character.
            switch (program.Direction)
            {
                case Direction.Up:
                    program.Position.Y--;
                    break;
                case Direction.Right:
                    program.Position.X++;
                    break;
                case Direction.Down:
                    program.Position.Y++;
                    break;
                case Direction.Left:
                    program.Position.X--;
                    break;
            }

            program.Position = program.Position.ValidatePosition(program.Position, program.Content);

            logger.UpdateContent(this.Program, this.Program.ValueList, this.Program.Output);
        }
    }
}
