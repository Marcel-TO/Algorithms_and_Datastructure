namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class DisplayCommand : BaseCommand
    {
        public DisplayCommand(SplayTree_int splaytree) : base ("display", splaytree)
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

        public void Execute()
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("Can't clear an empty tree.");
            }

            this.Nodes = new List<Node>();
        }
    }
}