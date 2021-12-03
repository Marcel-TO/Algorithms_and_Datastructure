//-----------------------------------------------------------------------
// <copyright file="MaxCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the maximum command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the maximum command of the splay tree.
    /// </summary>
    public class MaxCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaxCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public MaxCommand(SplayTree_int splaytree) : base("max", splaytree)
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
        /// Represents the execution method of the maximum command.
        /// </summary>
        /// <returns>The maximum value of the tree.</returns>
        public int Execute() 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            return this.FindMax(this.Nodes[0]);
        }

        /// <summary>
        /// Represents the finding algorithm for the maximum value.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>The value of the current node.</returns>
        private int FindMax(Node node)
        {
            if (node.BiggerNode != null)
            {
                return this.FindMax(node.BiggerNode);
            }



            return node.Value;
        }
    }
}