namespace BefungeInterpreter.Interfaces
{
    public interface ICommandVisitable
    {
        void Accept(ICommandVisitor visitor);
    }
}
