namespace SplayTree.Commands
{
    using System;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class ClearCommand : BaseCommand
    {
        public ClearCommand(Splaytree splaytree) : base ("clear", splaytree)
        {
        }
        
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Log(ILogger logger)
        {
            throw new NotImplementedException();
        }

        public bool Execute(Executioner execute)
        {
            throw new NotImplementedException();
        }
    }
}