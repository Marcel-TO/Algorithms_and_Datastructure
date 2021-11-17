//-----------------------------------------------------------------------
// <copyright file="SplayTree_int.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the splay tree containing integer values.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Trees
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Commands;
    using SplayTree.Logic;

    /// <summary>
    /// Represents the integer splay tree.
    /// </summary>
    public class SplayTree_int
    {
        /// <summary>
        /// Represents the list of all nodes.
        /// </summary>
        private List<Node> nodes;

        /// <summary>
        /// Represents the list of all supported commands.
        /// </summary>
        private BaseCommand[] commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="SplayTree_int"/> class.
        /// </summary>
        /// <param name="nodes">Represents the list of all nodes.</param>
        public SplayTree_int(List<Node> nodes)
        {
            this.Nodes = nodes;

            this.commands = new BaseCommand[]
            {
                new ClearCommand(this),
                new ContainsCommand(this),
                new CountCommand(this),
                new CountSpecificCommand(this),
                new DisplayCommand(this),
                new InsertCommand(this),
                new MaxCommand(this),
                new MinCommand(this),
                new RemoveCommand(this),
                new TraverseCommand(this)
            };
        }

        /// <summary>
        /// Gets or sets the list of all nodes.
        /// </summary>
        /// <value>The list of all nodes.</value>
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.nodes)} must not be null.");
                }

                this.nodes = value;
            }
        }

        /// <summary>
        /// Gets the list of all command.
        /// </summary>
        /// <value>The list of all command.</value>
        public BaseCommand[] Commands
        {
            get
            {
                return this.commands;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.commands)} must not be null.");
                }

                this.commands = value;
            }
        }
    }
}
