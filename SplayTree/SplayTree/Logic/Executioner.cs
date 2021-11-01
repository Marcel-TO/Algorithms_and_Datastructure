namespace SplayTree.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    public class Executioner : ICommandVisitor
    {
        private ILogger logger;

        public Executioner(ILogger logger)
        {
            this.logger = logger;
        }

        public void Visit(ClearCommand command)
        {
            this.logger.Visit(command);

            if (command.Nodes.Count == 0)
            {
                this.logger.Message("The tree is already empty.");
                this.logger.Continue();
                return;
            }

            command.Nodes = new List<Node>();
            this.logger.Message("The tree is now cleared.");
            this.logger.Continue();
        }

        public void Visit(CountCommand command)
        {
            this.logger.Visit(command);

            int count = command.Nodes.Count;
            this.logger.Message($"The tree contains of {count} nodes.");
            this.logger.Continue();
        }

        public void Visit(InsertCommand command)
        {
            this.logger.Visit(command);

            int value = this.logger.GetValueFromUser();

            if (command.Nodes.Count == 0)
            {
                command.Nodes.Add(new Node(value) { Position = new Position(0,0)});
                this.logger.Message($"The root node of the splay tree starts with the value {value}.");
                this.logger.Continue();
                return;
            }

            Node newRoot = new Node(value) { Position = new Position(0, 0) };
            var attachmentNode = this.FindParentNode(command.Nodes[0], value);

            var sortedL = command.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value < value).ToList();
            var sortedR = command.Nodes.OrderBy(n => n.Position.Y).Where(x => x.Value >= value).ToList();

            command.Nodes = this.SortTree(newRoot, attachmentNode, sortedL, sortedR, command.Nodes);

            this.logger.Message($"The node {value} got added to the tree.");
            this.logger.Continue();
        }

        public void Visit(RemoveCommand command)
        {
            throw new NotImplementedException();
        }

        private Node FindParentNode(Node node, int value)
        {
            // checks if value is smaller than the current node.
            if (value < node.Value)
            {
                if (node.LesserNode != null)
                {
                    return this.FindParentNode(node.LesserNode, value);
                }

                return node;
            }

            // checks if value is bigger than the current node.
            if (node.BiggerNode != null)
            {
                return this.FindParentNode(node.BiggerNode, value);
            }

            return node;
        }

        private List<Node> SortTree(Node newRoot, Node attachmentNode, List<Node> sortedL, List<Node> sortedR, List<Node> nodes)
        {
            // Adds the new root nodes.
            List<Node> newList = new List<Node>();
            (Node, Node) root = this.CreateNode(attachmentNode.Value, newRoot);

            newList.Add(root.Item2);
            newList.Add(root.Item1);

            // Adds the smaller child node of the attachment node.
            if (attachmentNode.LesserNode != null)
            {
                (Node, Node) attachmentChildNode = this.CreateNode(attachmentNode.LesserNode.Value, newList[1]);
                newList[1] = attachmentChildNode.Item2;
                newList.Add(attachmentChildNode.Item1);
            }
            
            // Adds the bigger child node of the attachment node.
            if (attachmentNode.BiggerNode != null)
            {
                (Node, Node) attachmentChildNode = this.CreateNode(attachmentNode.BiggerNode.Value, newList[1]);
                newList[1] = attachmentChildNode.Item2;
                newList.Add(attachmentChildNode.Item1);
            }

            // Adds all nodes smaller than the new root node.
            for (int s = 0; s < sortedL.Count; s++)
            {
                if (sortedL[s] != attachmentNode)
                {
                    for (int n = 0; n < newList.Count; n++)
                    {
                        if (sortedL[s].Value < newList[n].Value)
                        {
                            if (newList[n].LesserNode == null)
                            {
                                (Node, Node) newNode = this.CreateNode(sortedL[s].Value, newList[n]);
                                newList[n] = newNode.Item2;
                                newList.Add(newNode.Item1);
                            }
                        }
                    }
                }
            }

            // Adds all nodes bigger than the new root node.
            for (int s = 0; s < sortedR.Count; s++)
            {
                if (sortedR[s] != attachmentNode)
                {
                    for (int n = 0; n < newList.Count; n++)
                    {
                        if (sortedR[s].Value < newList[n].Value)
                        {
                            if (newList[n].LesserNode == null)
                            {
                                (Node, Node) newNode = this.CreateNode(sortedR[s].Value, newList[n]);
                                newList[n] = newNode.Item2;
                                newList.Add(newNode.Item1);
                            }
                        }
                    }
                }
            }

            return newList;
        }

        private (Node, Node) CreateNode(int value, Node parentNode)
        {
            Node newNode;

            if (value < parentNode.Value)
            {
                newNode = new Node(value, parentNode);
                parentNode.LesserNode = newNode;

                return (newNode, parentNode);
            }

            newNode = new Node(value, parentNode);
            parentNode.BiggerNode = newNode;

            return (newNode, parentNode);
        }
    }
}
