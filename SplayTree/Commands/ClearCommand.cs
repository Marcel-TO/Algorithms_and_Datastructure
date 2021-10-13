namespace SplayTree.Commands
{
    public class ClearCommand : BaseCommand
    {
        public ClearCommand(List<Node> nodes) : base ("clear", nodes)
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