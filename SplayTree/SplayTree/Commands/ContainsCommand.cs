namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class ContainsCommand : BaseCommand
    {
        public ContainsCommand(Splaytree splaytree) : base ("count", splaytree)
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

        public bool Execute(Executioner execute, int value) 
        {
            if (this.Nodes.Count == 0)
            {
                // Exeption
            }

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}