namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class CountSpecificCommand : BaseCommand
    {
        public CountSpecificCommand(Splaytree splaytree) : base ("count specific", splaytree)
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

        public int Execute(IExecute execute, int value) 
        {
            throw new NotImplementedException();
        }
    }
}