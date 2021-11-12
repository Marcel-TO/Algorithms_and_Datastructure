namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class RemoveCommand : BaseCommand
    {
        public RemoveCommand(SplayTree_int splaytree) : base ("remove", splaytree)
        {
        }
        
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Log(ILogger logger)
        {
            logger.Visit(this);
        }

        public int Execute(Executioner execute, int value)
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to remove them.");
            }

            int removeCount = execute.FindRemovedNode(this.Nodes, value);
            List<int> values = execute.ExtractValues(this.Nodes);
            this.Nodes = execute.GenerateTree(values);

            return removeCount;
        }
    }
}