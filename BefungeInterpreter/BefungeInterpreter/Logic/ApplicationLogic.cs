namespace BefungeInterpreter.Logic
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    public class ApplicationLogic
    {
        private ILogger logger;

        private IKeyboardWatcher keyboardWatcher;

        private ICommandVisitor visitor;

        private FileCollector fileCollector;

        private BefungeProgramFactory factory;

        private BefungeProgram program;

        private string[] filepaths;

        private int index;

        private bool loop;

        public ApplicationLogic(ILogger logger, IKeyboardWatcher watcher)
        {
            this.Logger = logger;
            this.KeyboardWatcher = watcher;
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.visitor = new Executioner(this.logger);

            this.fileCollector = new FileCollector(this.logger);
            this.factory = new BefungeProgramFactory();
            this.loop = true;
        }

        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.logger = value;
            }
        }

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
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.keyboardWatcher = value;
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

        public void Start()
        {
            this.filepaths = this.fileCollector.GetFiles();
            this.Index = 0;

            this.Logger.ShowBefungePrograms(this.filepaths);
            this.Logger.ShowCursor(this.Index, this.filepaths.Length - 1);

            while (loop)
            {
                this.KeyboardWatcher.Start();
                this.Logger.ShowCursor(this.Index, this.filepaths.Length - 1);
            }

            this.logger.Clear();
        }

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

        private void ExtractBefungeProgram(string path)
        {
            this.program = this.factory.CreateBefungeProgram(path);

            Interpreter interpreter = new Interpreter(this.Logger, this.visitor);
            interpreter.RunBefungeProgram(this.program);

            this.Logger.Clear();
            this.Logger.ShowBefungePrograms(this.filepaths);
        }
    }
}
