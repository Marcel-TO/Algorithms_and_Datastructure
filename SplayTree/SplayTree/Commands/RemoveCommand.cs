//-----------------------------------------------------------------------
// <copyright file="RemoveCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the remove command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the remove command of the splay tree.
    /// </summary>
    public class RemoveCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public RemoveCommand(SplayTree_int splaytree) : base("remove", splaytree)
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
        /// Represents the execution method of the remove command.
        /// </summary>
        /// <param name="execute">The command executioner.</param>
        /// <param name="value">The value that gets removed.</param>
        /// <returns>The amount of removed nodes.</returns>
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