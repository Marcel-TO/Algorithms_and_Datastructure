namespace SplayTree.Commands
{
    using System;

    public abstract class BaseCommand : ICommandVisitable
    {
        private string initializer;

        private string name;

        private List<Node> nodes;

        public BaseCommand(string initializer, List<Node> nodes)
        {
            this.CommandInitializer = initializer;
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
                return this.name 
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

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.nodes = value;
            }
        }

        protected abstract void Accept(ICommandVisitor visitor);

        protected abstract T Accept<T>(ICommandVisitor visitor);
    }
}