namespace SplayTree.Interfaces
{
    public interface ICommandVisitable
    {
        void Accept(ICommandVisitor visitor);
    }
}