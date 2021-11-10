namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class MinCommand : BaseCommand
    {
        public MinCommand(Splaytree splaytree) : base ("count", splaytree)
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

        public int Execute(Executioner execute) 
        {
            if (this.Nodes.Count == 0)
            {
                // Exception
            }

            int min = this.Nodes[0].Value;

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value < min)
                {
                    min = this.Nodes[i].Value;
                }
            }

            return min;
        }
    }
}