namespace SplayTree.Logic
{
    using System;

    public class Node
    {
        private int value;

        private Node lesserNode;

        private Node biggerNode;

        private Node parentNode;

        private Position position;

        public Node(int value)
        {
            this.Value = value;
        }

        public Node(int value, Node parent) // Properties checken?
        {
            this.Value = value;
            this.ParentNode = parent;

            if (value < parent.Value)
            {
                this.Position = new Position(parent.Position.X - 1, parent.Position.Y + 1);
            }
            else
            {
                this.Position = new Position(parent.Position.X + 1, parent.Position.Y + 1);
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(value)} must not be a positve Number!");
                }

                this.value = value;
            }
        }

        public Node LesserNode
        {
            get
            {
                return this.lesserNode;
            }

            set
            {
                this.lesserNode = value;
            }
        }

        public Node BiggerNode
        {
            get
            {
                return this.biggerNode;
            }

            set
            {
                this.biggerNode = value;
            }
        }

        public Node ParentNode
        {
            get
            {
                return this.parentNode;
            }

            private set
            {
                this.parentNode = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.Position)} must not be null.");
                }

                this.position = value;
            }
        }
    }
}