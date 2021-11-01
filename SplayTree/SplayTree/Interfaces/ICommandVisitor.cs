namespace SplayTree.Interfaces
{
    using System;
    using SplayTree.Commands;

    public interface ICommandVisitor
    {
        void Visit(InsertCommand command);

        void Visit(RemoveCommand command);

        void Visit(ClearCommand command);

        void Visit(CountCommand command);
    }
}