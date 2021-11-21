﻿namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class PopCommand : BaseCommand
    {
        public PopCommand(BefungeProgram program) : base("$", "pop", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            program.Stack.Pop();
            program.ValueList.RemoveAt(program.ValueList.Count - 1);
        }
    }
}