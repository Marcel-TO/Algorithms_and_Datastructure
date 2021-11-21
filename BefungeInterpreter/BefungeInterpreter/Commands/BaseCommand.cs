namespace BefungeInterpreter.Commands
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using System;

    public abstract class BaseCommand : ICommandVisitable
    {
        private string commandInitializer;

        private string name;

        private BefungeProgram program;

        public BaseCommand(string initializer, string name, BefungeProgram program)
        {
            this.CommandInitializer = initializer;
            this.Name = name;
            this.Program = program;
        }

        public string CommandInitializer
        {
            get
            {
                return this.commandInitializer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.commandInitializer)} must not be null.");
                }

                this.commandInitializer = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.name)} must not be null.");
                }

                this.name = value;
            }
        }

        public BefungeProgram Program
        {
            get
            {
                return this.program;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.program)} must not be null.");
                }

                this.program = value;
            }
        }

        public abstract void Accept(ICommandVisitor visitor);
    }
}
