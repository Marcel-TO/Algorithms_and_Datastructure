namespace BefungeInterpreter.Factory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using BefungeInterpreter.Execptions;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Logic;

    public class BefungeProgramFactory
    {
        private FileReader reader;

        public BefungeProgramFactory()
        {
            this.reader = new FileReader();
        }

        public BefungeProgram CreateBefungeProgram(string path)
        {
            string[] content = this.reader.ReadFile(path);

            if (content == null)
            {
                throw new BefungeProgramNotPossible($"The file {path} is not a valid for a Befunge program.");
            }

            bool isValid = true;

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Length > 80)
                {
                    isValid = false;
                }
            }

            if (!isValid || content.Length > 25)
            {
                throw new BefungeProgramNotPossible($"The file {path} is not a valid for a Befunge program.");
            }

            Stack<int> stack = new Stack<int>();

            BefungeProgram program = new BefungeProgram(stack, content, new Position(0,0));

            return program;
        }
    }
}
