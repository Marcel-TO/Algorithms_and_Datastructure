namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class CountSpecificCommand : BaseCommand
    {
        public CountSpecificCommand(SplayTree_int splaytree) : base ("count specific", splaytree)
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

        public int Execute(int value) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            int count = 0;

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value == value)
                {
                    count++;
                }
            }

            return count;
        }
    }
}