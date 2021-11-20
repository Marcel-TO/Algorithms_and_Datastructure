namespace BefungeInterpreter.Logic
{
    using BefungeInterpreter.Commands;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BefungeProgram
    {
        private Stack<int> stack;

        private string[] content;

        private Position position;

        private BaseCommand[] commands;

        public BefungeProgram(Stack<int> stack, string[] content, Position position)
        {
            this.Stack = stack;
            this.Content = content;
            this.Position = position;

            this.commands = new BaseCommand[]
            {
                new AddCommand(this),
                new BridgeCommand(this),
                new DivideCommand(this),
                new DownCommand(this),
                new DuplicationCommand(this),
                new EndCommand(this),
                new GetCommand(this),
                new GreaterCommand(this),
                new IfCommand_H(this),
                new IfCommand_V(this),
                new InputCommand_Char(this),
                new InputCommand_Int(this),
                new LeftCommand(this),
                new ModuloCommand(this),
                new MultiplyCommand(this),
                new NotCommand(this),
                new OutCommand_Char(this),
                new OutCommand_Int(this),
                new PopCommand(this),
                new PutCommand(this),
                new RandomCommand(this),
                new RightCommand(this),
                new StringCommand(this),
                new SubtractCommand(this),
                new SwapCommand(this),
                new UpCommand(this)
            };
        }

        public Stack<int> Stack
        {
            get
            {
                return this.stack;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.stack)} must not be null.");
                }

                this.stack = value;
            }
        }

        public string[] Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.content)} must not be null.");
                }

                this.content = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.position)} must not be null.");
                }

                this.position = value;
            }
        }

        public BaseCommand[] Commands
        {
            get
            {
                return this.commands;
            }
        }
    }
}
