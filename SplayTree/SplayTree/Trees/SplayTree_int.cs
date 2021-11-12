
namespace SplayTree.Trees
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Commands;
    using SplayTree.Logic;

    public class SplayTree_int
    {
        private List<Node> nodes;

        private BaseCommand[] commands;

        public SplayTree_int(List<Node> nodes)
        {
            this.Nodes = nodes;

            this.commands = new BaseCommand[]
            {
                new ClearCommand(this),
                new ContainsCommand(this),
                new CountCommand(this),
                new CountSpecificCommand(this),
                new InsertCommand(this),
                new MaxCommand(this),
                new MinCommand(this),
                new RemoveCommand(this),
                new TraverseCommand(this)
            };
        }

        public List<Node> Nodes
        {
            get
            {
                return nodes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.nodes)} must not be null.");
                }

                this.nodes = value;
            }
        }

        public BaseCommand[] Commands
        {
            get
            {
                return this.commands;
            }
        }
    }
}
