namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class MaxCommand : BaseCommand
    {
        public MaxCommand(SplayTree_int splaytree) : base ("max", splaytree)
        {
        }
        
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Log(ILogger logger)
        {
            throw new NotImplementedException();
        }

        public int Execute() 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            int counter = 0;
            int max = this.Nodes[counter].Value;

            while (this.Nodes[counter].BiggerNode != null)
            {
                max = this.Nodes[counter].BiggerNode.Value;
                counter++;
            }

            return max;
        }
    }
}