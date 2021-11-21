﻿namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public class GreaterCommand : BaseCommand
    {
        public GreaterCommand(BefungeProgram program) : base("`", "greater", program)
        {
        }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute(BefungeProgram program)
        {
            int value2 = program.Stack.Pop();
            int value1 = program.Stack.Pop();
            program.ValueList.RemoveAt(program.ValueList.Count - 1);
            program.ValueList.RemoveAt(program.ValueList.Count - 1);

            if (value1 > value2)
            {
                program.Stack.Push(1);
                program.ValueList.Add(1);
                return;
            }

            program.Stack.Push(0);
            program.ValueList.Add(0);
        }
    }
}