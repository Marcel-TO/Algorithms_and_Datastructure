namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class InsertCommand : BaseCommand
    {
        public InsertCommand(Splaytree splaytree) : base ("insert", splaytree)
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

        public void Execute(Executioner execute, int value)
        {
            if (this.Nodes.Count == 0)
            {
                this.Nodes.Add(new Node(value) { Position = new Position(0, 0) });
                return;
            }

            Node newRoot = new Node(value) { Position = new Position(0, 0) };
            Node attachmentNode = execute.FindAttachmentNode(this.Nodes[0], value);

            // Splits the list of nodes in 2 sides. The Left side containing the smaller nodes and the right side containing the bigger nodes.
            var sortedL = this.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value < value).ToList();
            var sortedR = this.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value >= value).ToList();

            this.Nodes = execute.SortTree(newRoot, attachmentNode, sortedL, sortedR);
            return;
        }
    }
}