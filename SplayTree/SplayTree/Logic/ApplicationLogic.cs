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
            this.nodes = new List<Node>();
            this.splaytree = new SplayTree_int(this.nodes);
            this.logger = new ConsoleLogger();
            this.execute = new Executioner(this.logger);
            this.keyboardWatcher = new KeyboardWatcher();
            this.keyboardWatcher.KeyPressed += this.KeyPressed;
            this.index = 0;
            this.loop = true;
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
            this.logger.WelcomeMessage();
            this.logger.ShowCommands(this.splaytree.Commands);
            this.logger.ShowCursor(this.index, this.splaytree.Commands.Length - 1);


            while(this.loop)
            {
                this.keyboardWatcher.Start();
                this.logger.ShowCursor(this.index, this.splaytree.Commands.Length - 1);
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
                    this.ExecuteCommand(this.splaytree.Commands, this.index, this.execute);
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

            this.logger.Clear();
            this.logger.ShowCommands(commands);
            this.logger.ShowCursor(index, commands.Length - 1);
        }
    }
}
