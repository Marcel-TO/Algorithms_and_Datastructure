namespace SplayTree.Commands
{
    public class InsertCommand : BaseCommand
    {
        public InsertCommand(List<Node> nodes) : base ("insert", nodes)
        {
        }

        override void Accept(ICommandVisitor visitor)
        {
            visitor.Accept(this);
        }

        override T Accept<T>(ICommandVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}