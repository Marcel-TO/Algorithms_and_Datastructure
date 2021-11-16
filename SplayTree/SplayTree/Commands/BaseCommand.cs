//-----------------------------------------------------------------------
// <copyright file="BaseCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the abstract base command of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the abstract base command class.
    /// </summary>
    public abstract class BaseCommand : ICommandVisitable, ILogable
    {
        /// <summary>
        /// Represents the name of the current command.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the current splay tree.
        /// </summary>
        private SplayTree_int splaytree;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommand"/> class.
        /// </summary>
        /// <param name="commandInitializer">Represents the command initializer for the command.</param>
        /// <param name="splaytree">Represents the current splay tree.</param>
        public BaseCommand(string commandInitializer, SplayTree_int splaytree)
        {
            this.Name = commandInitializer;

            if (splaytree == null)
            {
                throw new ArgumentNullException($"The {nameof(splaytree)} must not be null.");
            }

            this.SplayTree = splaytree;
        }

        /// <summary>
        /// Gets the initializer of the current command.
        /// </summary>
        /// <value>The initializer of the current command.</value>
        public string Initializer
        {
            get
            {
                return "fn";
            }
        }

        /// <summary>
        /// Gets the name of the current command.
        /// </summary>
        /// <value>The name of the current command.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets the current used splay tree.
        /// </summary>
        /// <value>The current splay tree.</value>
        public SplayTree_int SplayTree
        {
            get
            {
                return this.splaytree;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.splaytree)} must not be null.");
                }

                this.splaytree = value;
            }
        }

        /// <summary>
        /// Gets or sets the nodes of the current splay tree.
        /// </summary>
        /// <value>The nodes of the current splay tree.</value>
        public List<Node> Nodes
        {
            get
            {
                return this.SplayTree.Nodes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.SplayTree.Nodes = value;
            }
        }

        /// <summary>
        /// Represents the visitor pattern for command execution.
        /// </summary>
        /// <param name="visitor">The used visitor interface.</param>
        public abstract void Accept(ICommandVisitor visitor);

        /// <summary>
        /// Represents the visitor pattern for command logging.
        /// </summary>
        /// <param name="logger">The used logging interface.</param>
        public abstract void Log(ILogger logger);
    }
}