namespace SplayTree.Commands
{
    using System;
    using SplayTree.Logic;
    using SplayTree.Interfaces;
    using System.Collections.Generic;

    public class ClearCommand : BaseCommand
    {
        public ClearCommand(List<Node> nodes) : base ("clear", nodes)
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
    }
}