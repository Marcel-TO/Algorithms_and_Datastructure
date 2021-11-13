namespace SplayTree.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SplayTree.Commands;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;

    public class Executioner : ICommandVisitor
    {
        private ILogger logger;

        public Executioner(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.logger = value;
            }
        }

        public void Visit(ClearCommand command)
        {
            this.Logger.Visit(command);

            try
            {
                command.Execute();

                this.Logger.Message("The tree is now cleared.");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
        }

        public void Visit(ContainsCommand command)
        {
            this.Logger.Visit(command);
            int value = this.Logger.GetValueFromUser();
            bool isExisting = false;

            try
            {
                isExisting = command.Execute(value);

                if (isExisting)
                {
                    this.Logger.Message($"The tree does contain the value {value}.");
                }
                else
                {
                    this.Logger.Message($"The tree does not contain the value {value}");
                }
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
            }

            this.Logger.Continue();
        }

        public void Visit(CountCommand command)
        {
            this.Logger.Visit(command);

            try
            {
                int count = command.Execute();
                this.Logger.Message($"The tree contains of {count} nodes.");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
        }

        public void Visit(CountSpecificCommand command) 
        {
            this.Logger.Visit(command);
            int value = this.Logger.GetValueFromUser();

            try
            {
                int count = command.Execute(value);
                this.Logger.Message($"The tree contains a node with the value {value} about {count} times.");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
        }

        public void Visit(DisplayCommand command)
        {
            try
            {
                command.Execute();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
                return;
            }

            this.Logger.Visit(command);
        }

        public void Visit(InsertCommand command)
        {
            this.Logger.Visit(command);
            int value = this.Logger.GetValueFromUser();

            try
            {
                command.Execute(this, value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
                return;
            }
           

            this.Logger.Message($"The node {value} got added to the tree.");
            this.Logger.Continue();
        }

        public void Visit(MaxCommand command)
        {
            this.Logger.Visit(command);

            try
            {
                int max = command.Execute();
                this.Logger.Message($"The maximum value of the tree is {max}");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
        }

        public void Visit(MinCommand command)
        {
            this.Logger.Visit(command);

            try
            {
                int min = command.Execute();
                this.Logger.Message($"The minimum value of the tree is {min}.");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
            
        }

        public void Visit(RemoveCommand command)
        {
            this.Logger.Visit(command);

            if (command.Nodes.Count == 0)
            {
                this.Logger.Message($"I am sorry, but the splay tree is empty. Please consider to add values to the tree before trying to remove them.");
                this.Logger.Continue();
                return;
            }

            int value = this.Logger.GetValueFromUser();

            try
            {
                int count = command.Execute(this, value);

                if (count == 0)
                {
                    this.Logger.Message($"There is no node with the {value} in the tree.");
                    this.Logger.Continue();
                    return;
                }

                this.Logger.Message($"The value {value} got removed from the tree {count} times.");
                this.Logger.Continue();
            }
            catch (TreeIsEmptyException e)
            {
                this.Logger.Message(e.Message);
                this.Logger.Continue();
            }
        }

        public void Visit(TraverseCommand command)
        {
            this.Logger.Visit(command);
            int orderIndex = this.Logger.ChooseTraverseOrder();

            switch (orderIndex)
            {
                case 1:
                command.Nodes = command.Execute(this, TraverseOrder.inOrder);
                break;

                case 2:
                command.Nodes = command.Execute(this, TraverseOrder.preOrder);
                break;

                case 3:
                command.Nodes = command.Execute(this, TraverseOrder.postOrder);
                break;
            }
        }

        public Node FindAttachmentNode(Node node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException($"The {nameof(node)} must not be null.");
            }

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(value)} must be a positive number.");
            }

            // checks if value is smaller than the current node.
            if (value < node.Value)
            {
                if (node.LesserNode != null)
                {
                    return this.FindAttachmentNode(node.LesserNode, value);
                }

                return node;
            }

            // checks if value is bigger than the current node.
            if (node.BiggerNode != null)
            {
                return this.FindAttachmentNode(node.BiggerNode, value);
            }

            return node;
        }

        public List<Node> SortTree(Node newRoot, Node attachmentNode, List<Node> sortedL, List<Node> sortedR)
        {
            if (newRoot == null || attachmentNode == null || sortedL == null || sortedR == null)
            {
                throw new ArgumentNullException("All parameters must not be null.");
            }

            // Creates the new root node.
            List<Node> newList = new List<Node>();
            (Node, Node) root = this.CreateNode(attachmentNode.Value, newRoot);

            // Adds the new root node and the attachment node.
            newList.Add(root.Item2);
            newList.Add(root.Item1);

            // Adds all nodes that are smaller than the root node.
            for (int s = 0; s < sortedL.Count; s++)
            {
                if (sortedL[s] != attachmentNode)
                {
                    newList = this.AddNode(sortedL[s], newList[0], newList);
                }
            }

            // Adds all nodes that are bigger than the root node.
            for (int s = 0; s < sortedR.Count; s++)
            {
                if (sortedR[s] != attachmentNode)
                {
                    newList = this.AddNode(sortedR[s], newList[0], newList);
                }
            }

            newList = newList.OrderBy(x => x.Position.Y).ToList();

            return newList;
        }

        public List<Node> AddNode(Node newNode, Node node, List<Node> allNodes)
        {
            if (newNode == null || node == null || allNodes == null)
            {
                throw new ArgumentNullException("All parameters must not be null.");
            }

            // Checks if value is smaller than the comparing node.
            if (newNode.Value < node.Value)
            {
                // Checks if the comparing node already contains a smaller child node.
                if (node.LesserNode != null)
                {
                    this.AddNode(newNode, node.LesserNode, allNodes);
                    return allNodes;
                }

                // Adds the smaller child node to the comparing node.
                (Node, Node) nodesL = this.CreateNode(newNode.Value, node);
                node = nodesL.Item2;
                node.LesserNode = nodesL.Item1;
                allNodes.Add(nodesL.Item1);

                return allNodes;
            }

            // Checks if the comparing node already contains a bigger child node.
            if (node.BiggerNode != null)
            {
                this.AddNode(newNode, node.BiggerNode, allNodes);
                return allNodes;
            }

            // Adds the bigger child node to the comparing node.
            (Node, Node) nodesR = this.CreateNode(newNode.Value, node);
            node = nodesR.Item2;
            node.BiggerNode = nodesR.Item1;
            allNodes.Add(nodesR.Item1);

            return allNodes;
        }

        public (Node, Node) CreateNode(int value, Node parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException($"The {nameof(parentNode)} must not be null.");
            }

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(value)} must be a positive number.");
            }

            Node newNode;

            // Checks if the new node is smaller than the parent node.
            if (value < parentNode.Value)
            {
                // Creates the smaller child node for the parent node.
                newNode = new Node(value, parentNode);
                parentNode.LesserNode = newNode;

                return (newNode, parentNode);
            }

            // Creates the bigger child node for the parent node.
            newNode = new Node(value, parentNode);
            parentNode.BiggerNode = newNode;

            return (newNode, parentNode);
        }

        public int RemoveNodes(List<Node> nodes, int removedValue)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException($"The {nameof(nodes)} must not be null.");
            }

            if (removedValue < 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(removedValue)} must be a positive number.");
            }

            int count = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Value == removedValue)
                {
                    nodes.Remove(nodes[i]);
                    count++;
                    i--;
                }
            }

            return count;
        }

        public int FindRemovedNode(List<Node> nodes, int userInput)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException($"The {nameof(nodes)} must not be null.");
            }

            if (userInput < 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(userInput)} must be a positive number.");
            }

            int removeCount = this.RemoveNodes(nodes, userInput);

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].LesserNode?.Value == userInput)
                {
                    nodes[i].LesserNode = null;
                }

                if (nodes[i].BiggerNode?.Value == userInput)
                {
                    nodes[i].BiggerNode = null;
                }
            }

            return removeCount;
        }

        public List<Node> GenerateTree(List<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"The {nameof(values)} must not be null.");
            }

            if (values.Count == 0)
            {
                return new List<Node>();
            }

            List<Node> tempNodes = new List<Node>();

            for (int i = 0; i < values.Count; i++)
            {
                tempNodes.Add(new Node(values[i]));
            }

            List<Node> sortedNodes = new List<Node>();
            sortedNodes.Add(new Node(tempNodes[0].Value) { Position = new Position(0, 0) });
            
            for (int i = 1; i < tempNodes.Count; i++)
            {
                sortedNodes = this.AddNode(tempNodes[i], sortedNodes[0], sortedNodes);
            }

            return sortedNodes;
        }

        public List<int> ExtractValues(List<Node> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException($"The {nameof(nodes)} must not be null.");
            }

            List<int> values = new List<int>();

            for (int i = 0; i < nodes.Count; i++)
            {
                values.Add(nodes[i].Value);
            }

            return values;
        }
    }
}
