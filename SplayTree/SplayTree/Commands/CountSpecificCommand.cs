//-----------------------------------------------------------------------
// <copyright file="CountSpecificCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the count specific command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the count specific command of the splay tree.
    /// </summary>
    public class CountSpecificCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountSpecificCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public CountSpecificCommand(SplayTree_int splaytree) : base("count specific", splaytree)
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
        /// Represents the execution method of the count specific command.
        /// </summary>
        /// <param name="value">The value that gets compared.</param>
        /// <returns>The amount of nodes with a specific value.</returns>
        public int Execute(int value) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            int count = 0;

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value == value)
                {
                    count++;
                }
            }

            return count;
        }
    }
}