namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Logic;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    public abstract class BaseCommand : ICommandVisitable, ILogable
    {
        private string name;

        private Splaytree splaytree;

        public BaseCommand(string commandInitializer, Splaytree splaytree)
        {
            this.Name = commandInitializer;
            this.SplayTree = splaytree;
        }

        public string Initializer
        {
            get
            {
                return "fn";
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.name = value;
            }
        }

        public Splaytree SplayTree
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

        public List<Node> Nodes
        {
            get
            {
                return this.SplayTree.Nodes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.SplayTree.Nodes = value;
            }
        }

        public abstract void Accept(ICommandVisitor visitor);

        public abstract void Log(ILogger logger);
    }
}