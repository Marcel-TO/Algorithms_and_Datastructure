namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class TraverseCommand : BaseCommand
    {
        public TraverseCommand(SplayTree_int splaytree) : base ("traverse", splaytree)
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

        public List<Node> Execute(Executioner execute, TraverseOrder order) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            switch(order)
            {
                case TraverseOrder.inOrder:
                break;
                case TraverseOrder.preOrder:
                break;
                case TraverseOrder.postOrder:
                break;
            }

            return null;
        }
    }
}