//-----------------------------------------------------------------------
// <copyright file="Executioner.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the execution class for all supported commands.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using System;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Interfaces;

    /// <summary>
    /// Represents the class for executing commands.
    /// </summary>
    public class Executioner : ICommandVisitor
    {
        /// <summary>
        /// Represents the logger of the application.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Executioner"/> class.
        /// </summary>
        /// <param name="logger">Represents the logger of the application.</param>
        public Executioner(ILogger logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// Gets the logger of the application.
        /// </summary>
        /// <value>The logger of the application.</value>
        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.logger = value;
            }
        }

        /// <summary>
        /// Represents the visitor pattern for the add command.
        /// </summary>
        /// <param name="command">Represents the ad command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(AddCommand command)
        {
            command.Execute(command.Program);
        }

        /// <summary>
        /// Represents the visitor pattern for the bridge command.
        /// </summary>
        /// <param name="command">Represents the bridge command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(BridgeCommand command)
        {
            command.Execute(command.Program, this.Logger);
        }

        /// <summary>
        /// Represents the visitor pattern for the divide command.
        /// </summary>
        /// <param name="command">Represents the divide command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(DivideCommand command)
        {
            command.Execute(command.Program, this.Logger);
        }

         /// <summary>
        /// Represents the visitor pattern for the down command.
        /// </summary>
        /// <param name="command">Represents the down command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(DownCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the duplication command.
        /// </summary>
        /// <param name="command">Represents the duplication command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(DuplicationCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the end command.
        /// </summary>
        /// <param name="command">Represents the end command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(EndCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the get command.
        /// </summary>
        /// <param name="command">Represents the get command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(GetCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the greater command.
        /// </summary>
        /// <param name="command">Represents the greater command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(GreaterCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the horizontal if command.
        /// </summary>
        /// <param name="command">Represents the horizontal if command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(IfCommand_H command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the vertical if command.
        /// </summary>
        /// <param name="command">Represents the vertical if command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(IfCommand_V command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the character input command.
        /// </summary>
        /// <param name="command">Represents the character input command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(InputCommand_Char command)
        {
            char character = this.Logger.GetUserCharInput();

            command.Execute(command.Program, character, this.Logger);
        }

         /// <summary>
        /// Represents the visitor pattern for the integer input command.
        /// </summary>
        /// <param name="command">Represents the integer input command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(InputCommand_Int command)
        {
            int number = this.Logger.GetUserIntInput();

            command.Execute(command.Program, number, this.Logger);
        }

         /// <summary>
        /// Represents the visitor pattern for the left command.
        /// </summary>
        /// <param name="command">Represents the left command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(LeftCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the modulo command.
        /// </summary>
        /// <param name="command">Represents the modulo command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(ModuloCommand command)
        {
            command.Execute(command.Program, this.Logger);
        }

         /// <summary>
        /// Represents the visitor pattern for the multiply command.
        /// </summary>
        /// <param name="command">Represents the multiply command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(MultiplyCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the not command.
        /// </summary>
        /// <param name="command">Represents the not command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(NotCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the character output command.
        /// </summary>
        /// <param name="command">Represents the character output command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(OutCommand_Char command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the integer output command.
        /// </summary>
        /// <param name="command">Represents the integer output command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(OutCommand_Int command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the pop command.
        /// </summary>
        /// <param name="command">Represents the pop command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(PopCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the put command.
        /// </summary>
        /// <param name="command">Represents the put command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(PutCommand command)
        {
            command.Execute(command.Program, this.Logger);
        }

         /// <summary>
        /// Represents the visitor pattern for the random command.
        /// </summary>
        /// <param name="command">Represents the random command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(RandomCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the right command.
        /// </summary>
        /// <param name="command">Represents the right command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(RightCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the string command.
        /// </summary>
        /// <param name="command">Represents the string command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(StringCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the subtract command.
        /// </summary>
        /// <param name="command">Represents the subtract command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(SubtractCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the swap command.
        /// </summary>
        /// <param name="command">Represents the swap command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(SwapCommand command)
        {
            command.Execute(command.Program);
        }

         /// <summary>
        /// Represents the visitor pattern for the up command.
        /// </summary>
        /// <param name="command">Represents the up command of the current <see cref="BefungeProgram"/>.</param>
        public void Visit(UpCommand command)
        {
            command.Execute(command.Program);
        }
    }
}
