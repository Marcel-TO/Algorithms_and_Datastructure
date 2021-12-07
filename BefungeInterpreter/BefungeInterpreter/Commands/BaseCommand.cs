//-----------------------------------------------------------------------
// <copyright file="BaseCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the abstract command class of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Represents the abstract base command class.
    /// </summary>
    public abstract class BaseCommand : ICommandVisitable
    {
        /// <summary>
        /// Defines the command initializer which indicates the current command.
        /// </summary>
        private string commandInitializer;

        /// <summary>
        /// Defines the name of the current command.
        /// </summary>
        private string name;

        /// <summary>
        /// Defines the <see cref="BefungeProgram"/> which gets interpreted.
        /// </summary>
        private BefungeProgram program;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommand"/> class.
        /// </summary>
        /// <param name="initializer">The initializer of the current command.</param>
        /// <param name="name">The name of the current command.</param>
        /// <param name="program">The current <see cref="BefungeProgram"/> which gets interpreted.</param>
        public BaseCommand(string initializer, string name, BefungeProgram program)
        {
            this.CommandInitializer = initializer;
            this.Name = name;
            this.Program = program;
        }

        /// <summary>
        /// Gets the initializer of the current command.
        /// </summary>
        /// <value>The command initializer.</value>
        public string CommandInitializer
        {
            get
            {
                return this.commandInitializer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.commandInitializer)} must not be null.");
                }

                this.commandInitializer = value;
            }
        }

        /// <summary>
        /// Gets the name of the current command.
        /// </summary>
        /// <value>The name of the current command.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.name)} must not be null.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets the current <see cref="BefungeProgram"/> which gets interpreted.
        /// </summary>
        /// <value>The current <see cref="BefungeProgram"/> that gets interpreted.</value>
        public BefungeProgram Program
        {
            get
            {
                return this.program;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.program)} must not be null.");
                }

                this.program = value;
            }
        }

        /// <summary>
        /// Represents the visitor pattern for command execution.
        /// </summary>
        /// <param name="visitor">The used visitor interface.</param>
        public abstract void Accept(ICommandVisitor visitor);
    }
}
