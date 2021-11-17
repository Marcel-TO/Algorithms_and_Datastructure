//-----------------------------------------------------------------------
// <copyright file="ICommandVisitor.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the command visitor pattern interface.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Interfaces
{
    using SplayTree.Commands;

    /// <summary>
    /// Represents the interface of the command visitor pattern.
    /// </summary>
    public interface ICommandVisitor
    {
        /// <summary>
        /// Represents the visit method of the insert command.
        /// </summary>
        /// <param name="command">Represents the insert command of the splay tree.</param>
        void Visit(InsertCommand command);

        /// <summary>
        /// Represents the visit method of the remove command.
        /// </summary>
        /// <param name="command">Represents the remove command of the splay tree.</param>
        void Visit(RemoveCommand command);

        /// <summary>
        /// Represents the visit method of the clear command.
        /// </summary>
        /// <param name="command">Represents the clear command of the splay tree.</param>
        void Visit(ClearCommand command);

        /// <summary>
        /// Represents the visit method of the count command.
        /// </summary>
        /// <param name="command">Represents the count command of the splay tree.</param>
        void Visit(CountCommand command);

        /// <summary>
        /// Represents the visit method of the count specific command.
        /// </summary>
        /// <param name="command">Represents the count specific command of the splay tree.</param>
        void Visit(CountSpecificCommand command);

        /// <summary>
        /// Represents the visit method of the minimum command.
        /// </summary>
        /// <param name="command">Represents the minimum command of the splay tree.</param>
        void Visit(MinCommand command);

        /// <summary>
        /// Represents the visit method of the maximum command.
        /// </summary>
        /// <param name="command">Represents the maximum command of the splay tree.</param>
        void Visit(MaxCommand command);

        /// <summary>
        /// Represents the visit method of the contains command.
        /// </summary>
        /// <param name="command">Represents the contains command of the splay tree.</param>
        void Visit(ContainsCommand command);

        /// <summary>
        /// Represents the visit method of the traverse command.
        /// </summary>
        /// <param name="command">Represents the traverse command of the splay tree.</param>
        void Visit(TraverseCommand command);

        /// <summary>
        /// Represents the visit method of the display command.
        /// </summary>
        /// <param name="command">Represents the display command of the splay tree.</param>
        void Visit(DisplayCommand command);
    }
}