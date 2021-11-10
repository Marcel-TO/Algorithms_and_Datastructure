namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class RemoveCommand : BaseCommand
    {
        public RemoveCommand(Splaytree splaytree) : base ("remove", splaytree)
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

        public bool Execute(Executioner execute, int value)
        {
            if (this.Nodes.Count == 0)
            {
                return false;
            }

            Node newRoot = execute.FindRemovedNode(this.Nodes, value);

            if (this.Nodes.Count > 0)
            {
                Node attachmentNode = execute.FindAttachmentNode(this.Nodes[0], newRoot.Value);

                // Splits the list of nodes in 2 sides. The Left side containing the smaller nodes and the right side containing the bigger nodes.
                var sortedL = this.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value < newRoot.Value).ToList();
                var sortedR = this.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value > newRoot.Value).ToList(); // Same Number!

                this.Nodes = execute.SortTree(newRoot, attachmentNode, sortedL, sortedR);
            }

            return true;
        }
    }
}