namespace SplayTree.Commands
{
    using System;
    using SplayTree.Logic;
    using SplayTree.Interfaces;
    using System.Collections.Generic;
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
            logger.Visit(this);
        }
    }
}