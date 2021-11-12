namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class TraverseCommand : BaseCommand
    {
        public TraverseCommand(Splaytree splaytree) : base ("count", splaytree)
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