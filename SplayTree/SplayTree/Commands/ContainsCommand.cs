namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class ContainsCommand : BaseCommand
    {
        public ContainsCommand(SplayTree_int splaytree) : base ("contains", splaytree)
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

        public bool Execute(int value) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The Tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}