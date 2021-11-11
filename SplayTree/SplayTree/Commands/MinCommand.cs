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

            int counter = 0;
            int min = this.Nodes[counter].Value;

            while (this.Nodes[counter].LesserNode != null)
            {
                min = this.Nodes[counter].LesserNode.Value;
                counter++;
            }

            return min;
        }
    }
}