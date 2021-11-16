//-----------------------------------------------------------------------
// <copyright file="ClearCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the clear command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the clear command of the splay tree.
    /// </summary>
    public class ClearCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public ClearCommand(SplayTree_int splaytree) : base("clear", splaytree)
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
        /// Represents the execution method of the clear command.
        /// </summary>
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