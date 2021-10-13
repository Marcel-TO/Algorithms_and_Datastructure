namespace SplayTree.ApplicationLogic
{
    using System;

    public class Node
    {
        private int _value;

        private Node lesserNode;

        private Node biggerNode;

        private Node parentNode;

        public Node(int value, parentNode parent)
        {
            this._Value = value;
            this.ParentNode = parent;
        }

        public int _Value
        {
            get
            {
                return this._value;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(value)} must not be a positve Number!");
                }

                this._value = value;
            }
        }

        public Node lesserNode
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
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.parentNode = value;
            }
        }
    }
}