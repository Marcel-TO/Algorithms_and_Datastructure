//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the logic of the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using System;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    /// <summary>
    /// Represents the application logic of the <see cref="BefungeProgram"/> interpreter.
    /// </summary>
    public class ApplicationLogic
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
        /// Represents the class for collecting the possible programs.
        /// </summary>
        private FileCollector fileCollector;

        /// <summary>
        /// Represents the factory for creating the selected program.
        /// </summary>
        private BefungeProgramFactory factory;

        /// <summary>
        /// Represents the current program.
        /// </summary>
        private BefungeProgram program;

        /// <summary>
        /// Represents the interpreter of the current program.
        /// </summary>
        private Interpreter interpreter;

        /// <summary>
        /// Represents the array of all possible file paths.
        /// </summary>
        private string[] filepaths;

        /// <summary>
        /// Represents the index of the current selected menu.
        /// </summary>
        private int index;

        /// <summary>
        /// Represents a value indicating whether the menu should be stopped.
        /// </summary>
        private bool loop;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogic"/> class.
        /// </summary>
        /// <param name="logger">The logger of the application.</param>
        /// <param name="watcher">The keyboard watcher of the application.</param>
        public ApplicationLogic(ILogger logger, IKeyboardWatcher watcher)
        {
            this.Logger = logger;
            this.KeyboardWatcher = watcher;
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.visitor = new Executioner(this.logger);
            this.Interpreter = new Interpreter(this.logger, this.visitor);

            this.fileCollector = new FileCollector(this.logger);
            this.factory = new BefungeProgramFactory();
            this.loop = true;
        }

        /// <summary>
        /// Gets the current logger of the application.
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
        /// Gets the keyboard watcher of the application.
        /// </summary>
        /// <value>The keyboard watcher.</value>
        public IKeyboardWatcher KeyboardWatcher
        {
            get
            {
                return this.keyboardWatcher;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.keyboardWatcher = value;
            }
        }

        /// <summary>
        /// Gets or sets the interpreter of the <see cref="BefungeProgram"/>.
        /// </summary>
        /// <value>The interpreter of the current program.</value>
        public Interpreter Interpreter
        {
            get
            {
                return this.interpreter;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.interpreter)} must not be null.");
                }

                this.interpreter = value;
            }
        }

        /// <summary>
        /// Gets the index of the current command list.
        /// </summary>
        /// <value>The index of the current command list.</value>
        public int Index
        {
            get
            {
                return this.index;
            }

            private set
            {
                if (value < 0)
                {
                    this.index = this.filepaths.Length - 1;
                }
                else if (value > this.filepaths.Length - 1)
                {
                    this.index = 0;
                }
                else
                {
                    this.index = value;
                }
            }
        }

        /// <summary>
        /// Represents the run method of the application.
        /// </summary>
        public void Run()
        {
            this.filepaths = this.fileCollector.GetFiles();
            this.Index = 0;

            this.Logger.ShowBefungePrograms(this.filepaths);
            this.Logger.ShowCursor(this.Index, this.filepaths.Length - 1);

            while (this.loop)
            {
                this.KeyboardWatcher.Start();
                this.Logger.ShowCursor(this.Index, this.filepaths.Length - 1);
            }

            this.logger.Clear();
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
                    break;
                case ConsoleKey.Enter:
                    this.ExtractBefungeProgram(this.filepaths[this.index]);
                    break;
                case ConsoleKey.UpArrow:
                    this.Index--;
                    break;
                case ConsoleKey.DownArrow:
                    this.Index++;
                    break;
            }
        }

        /// <summary>
        /// Represents the method for creating the <see cref="BefungeProgram"/> and runs the interpreter.
        /// </summary>
        /// <param name="path">The path of the current program.</param>
        private void ExtractBefungeProgram(string path)
        {
            this.program = this.factory.CreateBefungeProgram(path);

            this.Interpreter.RunBefungeProgram(this.program);

            this.Logger.Clear();
            this.Logger.ShowBefungePrograms(this.filepaths);
        }
    }
}
