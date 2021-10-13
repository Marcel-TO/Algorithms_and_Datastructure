namespace SplayTree.Commands
{
    public class CountCommand : BaseCommand
    {
        public CountCommand(List<Node> nodes) : base ("count", nodes)
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