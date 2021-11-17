//-----------------------------------------------------------------------
// <copyright file="Node.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines a single node from the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Logic
{
    using System;

    /// <summary>
    /// Represents the class of a node instance.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Represents the value of the current node.
        /// </summary>
        private int value;

        /// <summary>
        /// Represents the smaller child of the current node.
        /// </summary>
        private Node lesserNode;

        /// <summary>
        /// Represents the bigger child of the current node.
        /// </summary>
        private Node biggerNode;

        /// <summary>
        /// Represents the parent of the current node.
        /// </summary>
        private Node parentNode;

        /// <summary>
        /// Represents the position of the current node.
        /// </summary>
        private Position position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Represents the value of the current node.</param>
        public Node(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Represents the value of the current node.</param>
        /// <param name="parent">Represents parent node of the current node.</param>
        public Node(int value, Node parent)
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

        /// <summary>
        /// Gets the value of the current node.
        /// </summary>
        /// <value>The value of the current node.</value>
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

        /// <summary>
        /// Gets or sets the smaller child of the current node.
        /// </summary>
        /// <value>The smaller child of the current node.</value>
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

        /// <summary>
        /// Gets or sets the bigger child of the current node.
        /// </summary>
        /// <value>The bigger child of the current node.</value>
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

        /// <summary>
        /// Gets the parent node of the current node.
        /// </summary>
        /// <value>The parent node of the current node.</value>
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

        /// <summary>
        /// Gets or sets the position of the current node.
        /// </summary>
        /// <value>The position of the current node.</value>
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