//-----------------------------------------------------------------------
// <copyright file="TraverseCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the traverse command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the traverse command of the splay tree.
    /// </summary>
    public class TraverseCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraverseCommand"/> class.
        /// </summary>
        /// <param name="splaytree">The current splay tree.</param>
        public TraverseCommand(SplayTree_int splaytree) : base("traverse", splaytree)
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
        /// Represents the execution method of the traverse command.
        /// </summary>
        /// <param name="execute">The command executioner.</param>
        /// <param name="order">The order of the traverse command.</param>
        /// <returns>The list of the new traversed nodes.</returns>
        public List<Node> Execute(Executioner execute, TraverseOrder order) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            List<Node> traversedNodes = new List<Node>();

            switch (order)
            {
                case TraverseOrder.inOrder:
                    traversedNodes = this.InOrder(this.Nodes[0], traversedNodes);
                break;
                case TraverseOrder.preOrder:
                    traversedNodes = this.PreOrder(this.Nodes[0], traversedNodes);
                break;
                case TraverseOrder.postOrder:
                    traversedNodes = this.PostOrder(this.Nodes[0], traversedNodes);
                break;
            }

            List<int> values = execute.ExtractValues(traversedNodes);
            return execute.GenerateTree(values);
        }

        /// <summary>
        /// Represents the in order traversal.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="traversedNodes">The list of the traversed nodes.</param>
        /// <returns>The complete traversed nodes.</returns>
        private List<Node> InOrder(Node currentNode, List<Node> traversedNodes)
        {
            if (currentNode.LesserNode != null)
            {
                this.InOrder(currentNode.LesserNode, traversedNodes);
            }

            traversedNodes.Add(currentNode);

            if (currentNode.BiggerNode != null)
            {
                this.InOrder(currentNode.BiggerNode, traversedNodes);
            }

            return traversedNodes;
        }

        /// <summary>
        /// Represents the pre order traversal.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="traversedNodes">The list of the traversed nodes.</param>
        /// <returns>The complete traversed nodes.</returns>
        private List<Node> PreOrder(Node currentNode, List<Node> traversedNodes)
        {
            traversedNodes.Add(currentNode);

            if (currentNode.LesserNode != null)
            {
                this.PreOrder(currentNode.LesserNode, traversedNodes);
            }

            if (currentNode.BiggerNode != null)
            {
                this.PreOrder(currentNode.BiggerNode, traversedNodes);
            }

            return traversedNodes;
        }

        /// <summary>
        /// Represents the post order traversal.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="traversedNodes">The list of the traversed nodes.</param>
        /// <returns>The complete traversed nodes.</returns>
        private List<Node> PostOrder(Node currentNode, List<Node> traversedNodes)
        {
            if (currentNode.LesserNode != null)
            {
                this.PostOrder(currentNode.LesserNode, traversedNodes);
            }

            if (currentNode.BiggerNode != null)
            {
                this.PostOrder(currentNode.BiggerNode, traversedNodes);
            }

            traversedNodes.Add(currentNode);

            return traversedNodes;
        }

        private List<Node> InOrder_Iterativ(Node root)
        {
            List<Node> traversedNodes = new List<Node>();

            var sortedL = this.Nodes.OrderBy(n => n.Value).Where(n => n.Value < root.Value).Reverse().ToList();
            var sortedR = this.Nodes.OrderBy(n => n.Value).Where(n => n.Value >= root.Value).Where(n => n != root).Reverse().ToList();

            traversedNodes = traversedNodes.Concat(sortedL).Concat(new List<Node> {root}).Concat(sortedR).ToList();
            return traversedNodes;
        }

        private List<Node> PreOrder_Iterativ(Node root)
        {
            List<Node> traversedNodes = new List<Node>();

            var sortedL = this.Nodes.OrderBy(n => n.Position.Y).OrderBy(n => n.Position.X).Where(n => n.Value < root.Value).ToList();
            var sortedR = this.Nodes.OrderBy(n => n.Position.Y).OrderBy(n => n.Position.X).Where(n => n.Value >= root.Value).Where(n => n != root).ToList();

            traversedNodes = traversedNodes.Concat(new List<Node> {root}).Concat(sortedL).Concat(sortedR).ToList();
            return traversedNodes;
        }

        private List<Node> PostOrder_Iterativ(Node root)
        {
            List<Node> traversedNodes = new List<Node>();

            var extracted = this.Nodes.OrderBy(n => n.Position.Y).OrderBy(n => n.Position.X).Where(n => n != root).Reverse().ToList();

            traversedNodes = traversedNodes.Concat(extracted).Concat(new List<Node> {root}).ToList();
            return traversedNodes;
        }
    }
}