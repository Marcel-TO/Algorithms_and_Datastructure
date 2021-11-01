namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;

    public class InsertCommand : BaseCommand
    {
        public InsertCommand(List<Node> nodes) : base ("insert", nodes)
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