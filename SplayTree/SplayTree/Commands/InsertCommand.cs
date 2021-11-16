//-----------------------------------------------------------------------
// <copyright file="InsertCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the insert command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using System;
    using System.Linq;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the insert command of the splay tree.
    /// </summary>
    public class InsertCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public InsertCommand(SplayTree_int splaytree) : base("insert", splaytree)
        {
        }

        /// <summary>
        /// Represents the visitor pattern for command execution.
        /// </summary>
        /// <param name="visitor">The used visitor interface.</param>
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Represents the visitor pattern for command logging.
        /// </summary>
        /// <param name="logger">The used logging interface.</param>
        public override void Log(ILogger logger)
        {
            logger.Visit(this);
        }

        /// <summary>
        /// Represents the execution method of the insert command.
        /// </summary>
        /// <param name="execute">The command executioner.</param>
        /// <param name="value">The inserted value.</param>
        public void Execute(Executioner execute, int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"The tree only supports positive numbers.");
            }

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