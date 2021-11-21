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
            this.logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);

            while (true)
            {
                if (this.isInputDesired)
                {
                    this.keyboardWatcher.Start();
                }

                if (!this.loop)
                {
                    return;
                }

                this.GoThroughCode(program);
                this.logger.ShowProgramContent(program.Content, program.Position, program.ValueList, program.Output);
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
            if (program.Position.Y > program.Content.Length || program.Position.X >= program.Content[program.Position.Y].Length)
            {
                this.logger.CursorOutOfRange();
                this.loop = false;
                return;
            }

            for (int i = 0; i < program.Commands.Length; i++)
            {
                // Checks if the current character is equal to any supported command initializer.
                if (program.Content[program.Position.Y][program.Position.X].ToString() == program.Commands[i].CommandInitializer)
                {
                    if (program.IsStringFormat)
                    {
                        if (program.Content[program.Position.Y][program.Position.X].ToString() == "\"")
                        {
                            program.Commands[i].Accept(this.visitor);
                            this.MovePosition(program);
                            return;
                        }

                        break;
                    }

                    program.Commands[i].Accept(this.visitor);

                    if (program.IsInterpreted)
                    {
                        this.loop = false;
                        this.logger.Finished();
                    }

                    this.MovePosition(program);
                    return;
                }
            }

            this.PushNumber(program);
            this.MovePosition(program);
        }

        private void PushNumber(BefungeProgram program)
        {
            if (program.IsStringFormat)
            {
                byte[] byteValue = Encoding.ASCII.GetBytes(program.Content[program.Position.Y][program.Position.X].ToString());
                program.Stack.Push(byteValue[0]);
                program.ValueList.Add(byteValue[0]);
            }

            bool isNumber = int.TryParse(program.Content[program.Position.Y][program.Position.X].ToString(), out int number);

            if (isNumber && number >= 0 && number <= 9)
            {
                program.Stack.Push(number);
                program.ValueList.Add(number);
            }
        }

        private void MovePosition(BefungeProgram program)
        {
            switch (program.Direction)
            {
                case Direction.Up:
                    program.Position.Y--;
                    break;
                case Direction.Right:
                    program.Position.X++;
                    break;
                case Direction.Down:
                    program.Position.Y++;
                    break;
                case Direction.Left:
                    program.Position.X--;
                    break;
            }
        }
    }
}
