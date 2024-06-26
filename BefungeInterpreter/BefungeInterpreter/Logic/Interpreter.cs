﻿//-----------------------------------------------------------------------
// <copyright file="Interpreter.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interpreter for befunge programs.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using System;
    using System.Text;
    using System.Threading;
    using BefungeInterpreter.EventArgs;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    /// <summary>
    /// Represents the interpreter for the current <see cref="BefungeProgram"/>.
    /// </summary>
    public class Interpreter
    {
        /// <summary>
        /// Represents the logger of the application.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Represents the keyboard watcher of the application.
        /// </summary>
        private IKeyboardWatcher keyboardWatcher;

        /// <summary>
        /// Represents the visitor pattern for the interpreter commands.
        /// </summary>
        private ICommandVisitor visitor;

        /// <summary>
        /// Represents the thread for awaiting information to stop.
        /// </summary>
        private Thread stopThread;

        /// <summary>
        /// Represents the thread arguments of the thread.
        /// </summary>
        private ExitThreadArguments threadArguments;

        /// <summary>
        /// Represents a value indicating whether the interpreter should continue to loop.
        /// </summary>
        private bool loop;

        /// <summary>
        /// Represents a value indicating whether input from the user is desired.
        /// </summary>
        private bool isInputDesired;

        /// <summary>
        /// Initializes a new instance of the <see cref="Interpreter"/> class.
        /// </summary>
        /// <param name="logger">The logger of the current program.</param>
        /// <param name="visitor">The visitor pattern of the current program.</param>
        public Interpreter(ILogger logger, ICommandVisitor visitor)
        {
            this.Logger = logger;
            this.KeyboardWatcher = new KeyboardWatcher();
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.Visitor = visitor;

            this.loop = true;
            this.isInputDesired = true;

            this.threadArguments = new ExitThreadArguments();
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
        /// Gets the visitor pattern of the commands.
        /// </summary>
        /// <value>The visitor pattern of the commands.</value>
        public ICommandVisitor Visitor
        {
            get
            {
                return this.visitor;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.visitor)} must not be null.");
                }

                this.visitor = value;
            }
        }

        /// <summary>
        /// Gets or sets the keyboard watcher of the current program.
        /// </summary>
        /// <value>The keyboard watcher.</value>
        public IKeyboardWatcher KeyboardWatcher
        {
            get
            {
                return this.keyboardWatcher;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.keyboardWatcher)} must not be null.");
                }

                this.keyboardWatcher = value;
            }
        }

        /// <summary>
        /// Represents the method for interpreting the program.
        /// </summary>
        /// <param name="program">The current program.</param>
        public void RunBefungeProgram(BefungeProgram program)
        {
            this.Logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);

            if (this.stopThread != null && this.stopThread.IsAlive)
            {
                throw new InvalidOperationException($"The {nameof(this.stopThread)} is already running!");
            }

            this.stopThread = new Thread(this.ListenForStop);

            while (true)
            {
                if (this.isInputDesired)
                {
                    this.KeyboardWatcher.Start();
                }

                if (!this.loop)
                {
                    this.StopExitThread();
                    this.isInputDesired = true;
                    this.loop = true;
                    return;
                }

                this.GoThroughCode(program);
                this.Logger.UpdateContent(program, program.ValueList, program.Output);
            }
        }

        /// <summary>
        /// Represents the method which fires if a key got pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void KeyPressed(object sender, KeyboardWatcherKeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.loop = false;
                    this.StopExitThread();
                    break;
                case ConsoleKey.Enter:
                    this.SetUpRun();
                    break;
            }
        }

        /// <summary>
        /// Represents the method for resetting the thread.
        /// </summary>
        private void SetUpRun()
        {
            this.isInputDesired = false;
            this.stopThread = new Thread(this.ListenForStop);
            this.threadArguments.IsExit = false;
            this.stopThread.Start(this.threadArguments);
        }

        /// <summary>
        /// Represents the method for starting the thread.
        /// </summary>
        /// <param name="data">The arguments of the thread.</param>
        private void ListenForStop(object data)
        {
            if (!(data is ExitThreadArguments))
            {
                throw new ArgumentOutOfRangeException(nameof(data), $"The specified arguments must be of the type {nameof(ExitThreadArguments)}");
            }

            ExitThreadArguments args = (ExitThreadArguments)data;

            while (!args.IsExit)
            {
                ConsoleKey key = this.KeyboardWatcher.ReadKey();

                if (key == ConsoleKey.Enter)
                {
                    // Stops running the program and waits for user to step further as before.
                    this.isInputDesired = true;
                    this.StopExitThread();
                }
                else if (key == ConsoleKey.Escape)
                {
                    this.loop = false;
                    this.StopExitThread();
                }
            }
        }

        /// <summary>
        /// Represents the method for starting the thread.
        /// </summary>
        private void StopExitThread()
        {
            this.threadArguments.IsExit = true;
        }

        /// <summary>
        /// Represents the method for checking if the character is a command or if it gets pushed on the stack.
        /// </summary>
        /// <param name="program">The current program.</param>
        private void GoThroughCode(BefungeProgram program)
        {
            for (int i = 0; i < program.Commands.Length; i++)
            {
                // Checks if the current character is equal to any supported command initializer.
                if (program.Content[program.Position.Y][program.Position.X].ToString() == program.Commands[i].CommandInitializer)
                {
                    // Checks if the string format is activated, so no unwanted commands will get executed.
                    if (program.IsStringFormat)
                    {
                        // Checks if the current character is the same as the string format command, to end the string format.
                        if (program.Content[program.Position.Y][program.Position.X].ToString() == "\"")
                        {
                            program.Commands[i].Accept(this.Visitor);
                            this.MovePosition(program);
                            return;
                        }

                        break;
                    }

                    // If the string format is not activated the current command gets executed.
                    program.Commands[i].Accept(this.Visitor);

                    // Checks if the befunge program is finished.
                    if (program.IsInterpreted)
                    {
                        this.loop = false;
                        this.Logger.Finished();
                        return;
                    }

                    // Moves the position of the cursor.
                    this.MovePosition(program);
                    return;
                }
            }

            // If current character is no command, the number gets pushed on the stack.
            this.PushNumber(program);
            this.MovePosition(program);
        }

        /// <summary>
        /// Represents the method for pushing a number on the stack.
        /// </summary>
        /// <param name="program">The current program.</param>
        private void PushNumber(BefungeProgram program)
        {
            // Checks if the string format is activated and pushes the ascii value on the stack.
            if (program.IsStringFormat)
            {
                byte[] byteValue = Encoding.ASCII.GetBytes(program.Content[program.Position.Y][program.Position.X].ToString());
                program.StackPush(byteValue[0]);
            }

            bool isNumber = int.TryParse(program.Content[program.Position.Y][program.Position.X].ToString(), out int number);

            // Checks if the character is a number and pushes it on the stack.
            if (isNumber && number >= 0 && number <= 9)
            {
                program.StackPush(number);
            }

            ////// Checks if the character is hexadecimal and pushes it on the stack.
            ////if ((program.Content[program.Position.Y][program.Position.X] >= 'a' && program.Content[program.Position.Y][program.Position.X] <= 'f') ||
            ////    (program.Content[program.Position.Y][program.Position.X] >= 'A' && program.Content[program.Position.Y][program.Position.X] <= 'F'))
            ////{
            ////    program.StackPush(Convert.ToInt32(program.Content[program.Position.Y][program.Position.X].ToString(), 16));
            ////}
        }

        /// <summary>
        /// Represents the method for moving the cursor.
        /// </summary>
        /// <param name="program">The current program.</param>
        private void MovePosition(BefungeProgram program)
        {
            Position newPosition = new Position(program.Position.X, program.Position.Y);

            switch (program.Direction)
            {
                case Direction.Up:
                    newPosition = new Position(program.Position.X, program.Position.Y - 1);
                    break;
                case Direction.Right:
                    newPosition = new Position(program.Position.X + 1, program.Position.Y);
                    break;
                case Direction.Down:
                    newPosition = new Position(program.Position.X, program.Position.Y + 1);
                    break;
                case Direction.Left:
                    newPosition = new Position(program.Position.X - 1, program.Position.Y);
                    break;
            }

            program.Position = newPosition;
        }
    }
}
