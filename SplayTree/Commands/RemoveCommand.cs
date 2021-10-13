namespace SplayTree.Commands
{
    public class RemoveCommand : BaseCommand
    {
        public RemoveCommand(List<Node> nodes) : base ("remove", nodes)
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