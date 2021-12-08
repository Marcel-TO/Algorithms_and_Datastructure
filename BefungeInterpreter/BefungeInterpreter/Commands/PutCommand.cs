//-----------------------------------------------------------------------
// <copyright file="PutCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the put command of the befunge program interpreter.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Commands
{
    using System;
    using System.Text;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Defines the put command of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class PutCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutCommand"/> class.
        /// </summary>
        /// <param name="program">The current <see cref="BefungeProgram"/> that gets interpreted.</param>
        public PutCommand(BefungeProgram program) : base("p", "put", program)
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
        /// <param name="logger">The current logger of the interpreter.</param>
        public void Execute(BefungeProgram program, ILogger logger)
        {
            // Checks if the parameter is null.
            if (program == null)
            {
                throw new ArgumentNullException($"The {nameof(program)} must not be null.");
            }
            else if (logger == null)
            {
                throw new ArgumentNullException($"The {nameof(logger)} must not be null.");
            }

            char[] lineChars;

            // Checks if there are no values to be popped.
            if (program.Stack.Count == 0)
            {
                lineChars = program.Content[0].ToCharArray();
                lineChars[0] = ' ';
                program.Content[0] = new string(lineChars);

                logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
                return;
            }
            else if (program.Stack.Count < 2)
            {
                for (int i = 0; i < program.Stack.Count; i++)
                {
                    program.StackPop();
                }

                return;
            }

            // Pops the values.
            int y = program.StackPop();
            int x = program.StackPop();
            int value = program.StackPop();

            if (y > program.Content.Length - 1)
            {
                throw new ArgumentOutOfRangeException($"The {y} position is out of range.");
            }
            else if (x > program.Content[y].Length)
            {
                throw new ArgumentOutOfRangeException($"The {x} position is out of range.");
            }
            else if (value > 127)
            {
                throw new ArgumentOutOfRangeException($"The {value} must be an ascii value.");
            }

            var valueChars = Encoding.ASCII.GetChars(new byte[] { Convert.ToByte(value) });

            lineChars = program.Content[y].ToCharArray();
            lineChars[x] = valueChars[0];
            program.Content[y] = new string(lineChars);

            logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
        }
    }
}
