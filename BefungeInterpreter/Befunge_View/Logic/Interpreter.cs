namespace BefungeInterpreter.Logic
{
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;
    using System;
    using System.Text;

    public class Interpreter
    {
        private ILogger logger;

        private IKeyboardWatcher keyboardWatcher;

        private ICommandVisitor visitor;

        private bool loop;

        private bool isInputDesired;

        public Interpreter(ILogger logger, ICommandVisitor visitor)
        {
            this.logger = logger;
            this.keyboardWatcher = new KeyboardWatcher();
            this.keyboardWatcher.KeyPressed += this.KeyPressed;
            this.visitor = visitor;

            this.loop = true;
            this.isInputDesired = true;
        }

        public void RunBefungeProgram(BefungeProgram program)
        {
            this.logger.ShowProgramContent(program.Content, program.Position);

            while (true)
            {
                if (this.isInputDesired)
                {
                    this.keyboardWatcher.Start();

                    if (!this.loop)
                    {
                        return;
                    }
                }

                this.GoThroughCode(program);
                this.logger.ShowProgramContent(program.Content, program.Position);
            }
        }

        protected void KeyPressed(object sender, KeyboardWatcherKeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case ConsoleKey.Escape:
                    this.loop = false;
                    break;
                case ConsoleKey.Enter:
                    this.isInputDesired = false;
                    break;
            }
        }

        private void GoThroughCode(BefungeProgram program)
        {
            bool isCommand = false;

            for (int i = 0; i < program.Commands.Length; i++)
            {
                // Checks if the current character is equal to any supported command initializer.
                if (program.Content[program.Position.Y][program.Position.X].ToString() == program.Commands[i].CommandInitializer)
                {
                    isCommand = true;
                    program.Commands[i].Accept(this.visitor);
                }
            }

            if (!isCommand)
            {
                program.Stack.Push(program.Content[program.Position.Y][program.Position.X]);
                program.Position.X++;
            }
        }
    }
}
