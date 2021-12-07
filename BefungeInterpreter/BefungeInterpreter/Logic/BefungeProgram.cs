//-----------------------------------------------------------------------
// <copyright file="BefungeProgram.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the current befunge program of the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{  
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;

    /// <summary>
    /// Represents the current program that gets interpreted.
    /// </summary>
    public class BefungeProgram
    {
        /// <summary>
        /// Represents the current stack of the program.
        /// </summary>
        private Stack<int> stack;

        /// <summary>
        /// Represents the output stack of the program.
        /// </summary>
        private List<string> outputStack;

        /// <summary>
        /// Represents the list of all values from the stack.
        /// </summary>
        private List<int> valueList;

        /// <summary>
        /// Represents the content of the program.
        /// </summary>
        private string[] content;

        /// <summary>
        /// Represents the position of the current program cursor.
        /// </summary>
        private Position position;

        /// <summary>
        /// Represents the list of all supported commands for the interpreter.
        /// </summary>
        private BaseCommand[] commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="BefungeProgram"/> class.
        /// </summary>
        /// <param name="stack">The stack of the program.</param>
        /// <param name="content">The content of the program.</param>
        /// <param name="position">The position of the cursor.</param>
        public BefungeProgram(Stack<int> stack, string[] content, Position position)
        {
            this.Stack = stack;
            this.ValueList = new List<int>();
            this.Output = new List<string>();
            this.Content = content;
            this.Position = position;
            this.Direction = Direction.Right;
            this.IsInterpreted = false;
            this.IsStringFormat = false;

            this.commands = new BaseCommand[]
            {
                new AddCommand(this),
                new BridgeCommand(this),
                new DivideCommand(this),
                new DownCommand(this),
                new DuplicationCommand(this),
                new EndCommand(this),
                new GetCommand(this),
                new GreaterCommand(this),
                new IfCommand_H(this),
                new IfCommand_V(this),
                new InputCommand_Char(this),
                new InputCommand_Int(this),
                new LeftCommand(this),
                new ModuloCommand(this),
                new MultiplyCommand(this),
                new NotCommand(this),
                new OutCommand_Char(this),
                new OutCommand_Int(this),
                new PopCommand(this),
                new PutCommand(this),
                new RandomCommand(this),
                new RightCommand(this),
                new StringCommand(this),
                new SubtractCommand(this),
                new SwapCommand(this),
                new UpCommand(this)
            };
        }

        /// <summary>
        /// Gets the stack of the current program.
        /// </summary>
        /// <value>The stack of the current program.</value>
        public Stack<int> Stack
        {
            get
            {
                return this.stack;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.stack)} must not be null.");
                }

                this.stack = value;
            }
        }

        /// <summary>
        /// Gets the output of the current program.
        /// </summary>
        /// <value>The list of all output values.</value>
        public List<string> Output
        {
            get
            {
                return this.outputStack;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.outputStack)} must not be null.");
                }

                this.outputStack = value;
            }
        }

        /// <summary>
        /// Gets the list of all values from the stack.
        /// </summary>
        /// <value>The list of all values from the stack.</value>
        public List<int> ValueList
        {
            get
            {
                return this.valueList;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.valueList)} must not be null.");
                }

                this.valueList = value;
            }
        }

        /// <summary>
        /// Gets or sets the content of the current program.
        /// </summary>
        /// <value>The content of the current program.</value>
        public string[] Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.content)} must not be null.");
                }

                this.content = value;
            }
        }

        /// <summary>
        /// Gets or sets the position of the cursor.
        /// </summary>
        /// <value>The position of the current program cursor.</value>
        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.position)} must not be null.");
                }
                else if (value.Y < 0)
                {
                    value.Y = this.Content.Length - 1;
                }
                else if (value.Y > this.Content.Length - 1)
                {
                    value.Y = 0;
                }
                else if (value.X < 0)
                {
                    value.X = this.Content[value.Y].Length - 1;
                }
                else if (value.X > this.Content[value.Y].Length - 1)
                {
                    value.X = 0;
                }

                this.position = value;
            }
        }

        /// <summary>
        /// Gets the list of all commands supported from the interpreter.
        /// </summary>
        /// <value>The list of all commands.</value>
        public BaseCommand[] Commands
        {
            get
            {
                return this.commands;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the program is interpreted.
        /// </summary>
        /// <value>True if the program is interpreted, otherwise false.</value>
        public bool IsInterpreted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the program is currently in string format or not.
        /// </summary>
        /// <value>True if the program is in string format, otherwise false.</value>
        public bool IsStringFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the direction of the cursor.
        /// </summary>
        /// <value>The current direction of the cursor.</value>
        public Direction Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a method for popping a value from the stack and the value list.
        /// </summary>
        /// <returns>The value that got popped.</returns>
        public int StackPop()
        {
            if (this.Stack.Count == 0)
            {
                return 0;
            }

            int value = this.Stack.Pop();
            this.ValueList.RemoveAt(this.ValueList.Count - 1);

            return value;
        }

        /// <summary>
        /// Represents a method for pushing a value on the stack and the value list.
        /// </summary>
        /// <param name="value">The value that gets pushed.</param>
        public void StackPush(int value)
        {
            this.Stack.Push(value);
            this.ValueList.Add(value);
        }
    }
}
