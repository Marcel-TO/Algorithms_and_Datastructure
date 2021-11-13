namespace SplayTree.Logic
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.KeyboardWatcher;
    using SplayTree.Trees;

    public class ApplicationLogic
    {
        private ICommandVisitor execute;

        private ILogger logger;

        private List<Node> nodes;

        private SplayTree_int splaytree;

        private KeyboardWatcher keyboardWatcher;

        private int index;

        private bool loop;

        public ApplicationLogic()
        {
            this.Logger = new ConsoleLogger();
            this.Execute = new Executioner(this.logger);

            this.Nodes = new List<Node>();
            this.Splaytree = new SplayTree_int(this.nodes);
            this.KeyboardWatcher = new KeyboardWatcher();
            this.KeyboardWatcher.KeyPressed += this.KeyPressed;
            this.Index = 0;
            this.loop = true;
        }

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

        public KeyboardWatcher KeyboardWatcher
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

        public void Start()
        {
            this.Logger.WelcomeMessage();
            this.Logger.ShowCommands(this.Splaytree.Commands);
            this.Logger.ShowCursor(this.Index, this.Splaytree.Commands.Length - 1);

            while(this.loop)
            {
                this.keyboardWatcher.Start();
                this.Logger.ShowCursor(this.Index, this.Splaytree.Commands.Length - 1);
            }
        }

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

        private void ExecuteCommand(BaseCommand[] commands, int index, ICommandVisitor execute)
        {
            commands[index].Accept(execute);

            this.Logger.Clear();
            this.Logger.ShowCommands(commands);
            this.Logger.ShowCursor(index, commands.Length - 1);
        }
    }
}
