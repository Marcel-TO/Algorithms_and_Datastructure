//-----------------------------------------------------------------------
// <copyright file="CountCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the count command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the count command of the splay tree.
    /// </summary>
    public class CountCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public CountCommand(SplayTree_int splaytree) : base("count", splaytree)
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
        /// Represents the execution method of the count command.
        /// </summary>
        /// <returns>The amount of nodes in the splay tree.</returns>
        public int Execute() 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            return this.Nodes.Count;
        }
    }
}