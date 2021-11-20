namespace BefungeInterpreter.Factory
{
    using System;
    using System.Collections;
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
            string[] content = this.reader.ReadFile(path); // Check if null
            Stack stack = new Stack();

            BefungeProgram program = new BefungeProgram(stack, content, new Position(0,0));

            return program;
        }
    }
}
