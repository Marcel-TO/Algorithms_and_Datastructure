//-----------------------------------------------------------------------
// <copyright file="MinCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the minimum command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the minimum command of the splay tree.
    /// </summary>
    public class MinCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public MinCommand(SplayTree_int splaytree) : base("min", splaytree)
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
        /// Represents the execution method of the minimum command.
        /// </summary>
        /// <returns>The minimum value of the tree.</returns>
        public int Execute(Executioner execute) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            int min = this.FindMin(this.Nodes[0]);

            //List<int> values = execute.ExtractValues(this.Nodes);
            //this.Nodes = execute.GenerateTree(values);
            return min;
        }

        /// <summary>
        /// Represents the algorithm for finding the minimum value.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>The value of the current node.</returns>
        private int FindMin(Node node)
        {
            if (node.LesserNode != null)
            {
                return this.FindMin(node.LesserNode);
            }

            return node.Value;
        }
    }
}