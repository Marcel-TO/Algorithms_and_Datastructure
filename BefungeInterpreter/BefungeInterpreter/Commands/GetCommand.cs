//-----------------------------------------------------------------------
// <copyright file="GetCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the get command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using System.Text;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the get command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class GetCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public GetCommand(BefungeProgram program) : base("g", "get", program)
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

            int number;
            int x;
            int y;

            // Checks if there are no values to be popped.
            if (program.Stack.Count == 0)
            {
                x = 0;
                y = 0;
            }
            else
            {
                // Pops the values from the stack.
                y = program.StackPop();
                x = program.StackPop();

                if (y > program.Content.Length)
                {
                    program.StackPush(32);
                    return;
                }
                else if (x > program.Content[y].Length)
                {
                    program.StackPush(32);
                    return;
                }
            }

            // Checks if character is a number.
            bool isNumber = int.TryParse(program.Content[y][x].ToString(), out number);
            
            // If number -> push number.
            if (isNumber)
            {
                program.StackPush(number);
            }

            // If its not a number converts the ascii value of the character and pushes.
            byte[] byteValue = Encoding.ASCII.GetBytes(new char[] { program.Content[y][x] });
            program.StackPush(byteValue[0]);
        }
    }
}
