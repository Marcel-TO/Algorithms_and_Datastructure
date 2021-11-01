namespace SplayTree.Commands
{
    using SplayTree.Logic;
    using SplayTree.Interfaces;
    using System;
    using System.Collections.Generic;

    public abstract class BaseCommand : ICommandVisitable, ILogable
    {
        private string name;

        private List<Node> nodes;

        public BaseCommand(string commandInitializer, List<Node> nodes)
        {
            this.Name = commandInitializer;
            this.Nodes = nodes;
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

        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.nodes = value;
            }
        }

        public abstract void Accept(ICommandVisitor visitor);

        public abstract void Log(ILogger logger);
    }
}