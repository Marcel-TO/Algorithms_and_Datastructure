namespace BefungeInterpreter.Logic
{
    using BefungeInterpreter.Commands;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BefungeProgram
    {
        private Stack<int> stack;

        private List<string> outputStack;

        private List<int> valueList;

        private string[] content;

        private Position position;

        private BaseCommand[] commands;

        public BefungeProgram(Stack<int> stack, string[] content, Position position)
        {
            this.Stack = stack;
            this.ValueList = new List<int>();
            this.Output = new List<string>();
            this.Content = content;
            this.Position = position;
            this.Direction = Direction.Right;
            this.IsInterpreted = false;
            this.IsStringFormat = false;

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

        public List<string> Output
        {
            get
            {
                return this.outputStack;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.outputStack)} must not be null.");
                }

                this.outputStack = value;
            }
        }

        public List<int> ValueList
        {
            get
            {
                return this.valueList;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.valueList)} must not be null.");
                }

                this.valueList = value;
            }
        }

        public string[] Content
        {
            get
            {
                return this.content;
            }

            set
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

        public bool IsInterpreted
        {
            get;
            set;
        }

        public bool IsStringFormat
        {
            get;
            set;
        }

        public Direction Direction
        {
            get;
            set;
        }
    }
}
