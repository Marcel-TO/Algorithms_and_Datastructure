namespace SplayTree.Commands
{
    using System;
    using System.Collections.Generic;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    public class MaxCommand : BaseCommand
    {
        public MaxCommand(Splaytree splaytree) : base ("count", splaytree)
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

            int counter = 0;
            int max = this.Nodes[counter].Value;

            while (this.Nodes[counter].BiggerNode != null)
            {
                max = this.Nodes[counter].BiggerNode.Value;
                counter++;
            }

            return max;
        }
    }
}