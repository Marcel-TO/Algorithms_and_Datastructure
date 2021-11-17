//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the logic of the application.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Logic
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.KeyboardWatcher;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the logic of the application.
    /// </summary>
    public class ApplicationLogic
    {
        /// <summary>
        /// Represents the command visitor pattern for execution.
        /// </summary>
        private ICommandVisitor execute;

        /// <summary>
        /// Represents the logger of the application.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Represents the list of nodes from the splay tree.
        /// </summary>
        private List<Node> nodes;

        /// <summary>
        /// Represents the splay tree of the application.
        /// </summary>
        private SplayTree_int splaytree;

        /// <summary>
        /// Represents the keyboard watcher for user input purpose.
        /// </summary>
        private IKeyboardWatcher keyboardWatcher;

        /// <summary>
        /// Represents the index of the command list.
        /// </summary>
        private int index;

        /// <summary>
        /// Represents the duration of the interaction with the application.
        /// </summary>
        private bool loop;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogic"/> class.
        /// </summary>
        /// <param name="logger">Represents the logger for the application.</param>
        /// <param name="watcher">Represents the keyboard watcher for user input.</param>
        public ApplicationLogic(ILogger logger, IKeyboardWatcher watcher)
        {
            this.Logger = logger;
            this.Execute = new Executioner(this.logger);

            this.Nodes = new List<Node>();
            this.Splaytree = new SplayTree_int(this.nodes);
            this.KeyboardWatcher = watcher;
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.Index = 0;
            this.loop = true;
        }

        /// <summary>
        /// Gets the execute visitor for the commands.
        /// </summary>
        /// <value>The execute visitor for the commands.</value>
        public ICommandVisitor Execute
        {
            get
            {
                return this.execute;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.execute)} must not be null.");
                }

                this.execute = value;
            }
        }

        /// <summary>
        /// Gets the logger for the application.
        /// </summary>
        /// <value>The logger for the application.</value>
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
        /// Gets the list of nodes from the splay tree.
        /// </summary>
        /// <value>The list of nodes from the splay tree.</value>
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.nodes)} must not be null.");
                }

                this.nodes = value;
            }
        }

        /// <summary>
        /// Gets the current splay tree of the application.
        /// </summary>
        /// <value>The current splay tree.</value>
        public SplayTree_int Splaytree
        {
            get
            {
                return this.splaytree;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.splaytree)} must not be null.");
                }

                this.splaytree = value;
            }
        }

        /// <summary>
        /// Gets the keyboard watcher of the application.
        /// </summary>
        /// <value>The keyboard watcher for user input.</value>
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
                    throw new ArgumentNullException($"The {nameof(this.keyboardWatcher)} must not be null.");
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
                    this.index = this.splaytree.Commands.Length - 1;
                }
                else if (value > this.splaytree.Commands.Length - 1)
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
        /// Represents start of the application.
        /// </summary>
        public void Start()
        {
            this.Logger.WelcomeMessage();
            this.Logger.ShowCommands(this.Splaytree.Commands);
            this.Logger.ShowCursor(this.Index, this.Splaytree.Commands.Length - 1);

            while (this.loop)
            {
                this.keyboardWatcher.Start();
                this.Logger.ShowCursor(this.Index, this.Splaytree.Commands.Length - 1);
            }

            this.logger.Clear();
        }

        /// <summary>
        /// Occurs if the user pressed a key.
        /// </summary>
        /// <param name="sender">Represents the sender of the event.</param>
        /// <param name="e">Represents the arguments of the event.</param>
        protected void KeyPressed(object sender, KeyboardWatcherKeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.loop = false;
                    break;
                case ConsoleKey.Enter:
                    this.ExecuteCommand(this.Splaytree.Commands, this.Index, this.Execute);
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
        /// Represents the method for executing the selected command.
        /// </summary>
        /// <param name="commands">Represents the list of all supported commands.</param>
        /// <param name="index">Represents the index of the current command list.</param>
        /// <param name="execute">Represents the execute visitor pattern of the current command.</param>
        private void ExecuteCommand(BaseCommand[] commands, int index, ICommandVisitor execute)
        {
            commands[index].Accept(execute);

            this.Logger.Clear();
            this.Logger.ShowCommands(commands);
            this.Logger.ShowCursor(index, commands.Length - 1);
        }
    }
}
