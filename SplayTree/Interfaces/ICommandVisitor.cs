namespace SplayTree.Interfaces
{
    public interface ICommandVisitor
    {
        void Visit(InsertCommand command);

        void Visit(RemoveCommand command);

        void Visit(ClearCommand command);

        void Visit(CountCommand command);
    }

    public interface ICommandVisitor<T>
    {
        T Visit(InsertCommand command);

        T Visit(RemoveCommand command);

        T Visit(ClearCommand command);

        T Visit(CountCommand command);
    }   
}