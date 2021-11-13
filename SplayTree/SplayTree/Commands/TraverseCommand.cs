namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class TraverseCommand : BaseCommand
    {
        public TraverseCommand(SplayTree_int splaytree) : base ("traverse", splaytree)
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

        public List<Node> Execute(Executioner execute, TraverseOrder order) 
        {
            if (this.Nodes.Count == 0)
            {
                throw new TreeIsEmptyException("The tree is empty. Please consider to add values to the tree before trying to check what's inside the tree.");
            }

            List<Node> traversedNodes = new List<Node>();

            switch(order)
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
    }
}