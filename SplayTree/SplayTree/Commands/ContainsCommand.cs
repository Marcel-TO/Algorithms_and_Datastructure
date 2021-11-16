//-----------------------------------------------------------------------
// <copyright file="ContainsCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the contains command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the contains command for the splay tree.
    /// </summary>
    public class ContainsCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainsCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public ContainsCommand(SplayTree_int splaytree) : base("contains", splaytree)
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
        /// Represents the execution method of the contains command.
        /// </summary>
        /// <param name="value">The value that gets compared.</param>
        /// <returns>True if the splay tree does contain the value, otherwise false.</returns>
        public bool Execute(int value) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The Tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}