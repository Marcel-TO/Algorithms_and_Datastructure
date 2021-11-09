
namespace SplayTree.Trees
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Commands;
    using SplayTree.Logic;

    public class Splaytree
    {
        private List<Node> nodes;

        private BaseCommand[] commands;

        public Splaytree(List<Node> nodes)
        {
            this.Nodes = nodes;

            this.commands = new BaseCommand[]
            {
                new ClearCommand(this),
                new CountCommand(this),
                new InsertCommand(this),
                new RemoveCommand(this)
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
