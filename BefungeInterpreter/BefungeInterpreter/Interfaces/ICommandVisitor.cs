//-----------------------------------------------------------------------
// <copyright file="ICommandVisitor.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the command visitor pattern interface.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Interfaces
{
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Represents the interface of the command visitor pattern.
    /// </summary>
    public interface ICommandVisitor
    {
        /// <summary>
        /// Represents the visit method of the add command.
        /// </summary>
        /// <param name="command">Represents the add command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(AddCommand command);

        /// <summary>
        /// Represents the visit method of the bridge command.
        /// </summary>
        /// <param name="command">Represents the bridge command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(BridgeCommand command);

        /// <summary>
        /// Represents the visit method of the divide command.
        /// </summary>
        /// <param name="command">Represents the divide command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(DivideCommand command);

         /// <summary>
        /// Represents the visit method of the down command.
        /// </summary>
        /// <param name="command">Represents the down command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(DownCommand command);
        
         /// <summary>
        /// Represents the visit method of the duplication command.
        /// </summary>
        /// <param name="command">Represents the duplication command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(DuplicationCommand command);

         /// <summary>
        /// Represents the visit method of the end command.
        /// </summary>
        /// <param name="command">Represents the end command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(EndCommand command);

         /// <summary>
        /// Represents the visit method of the get command.
        /// </summary>
        /// <param name="command">Represents the get command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(GetCommand command);

         /// <summary>
        /// Represents the visit method of the greater command.
        /// </summary>
        /// <param name="command">Represents the greater command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(GreaterCommand command);

         /// <summary>
        /// Represents the visit method of the horizontal if command.
        /// </summary>
        /// <param name="command">Represents the horizontal if command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(IfCommand_H command);

         /// <summary>
        /// Represents the visit method of the vertical if command.
        /// </summary>
        /// <param name="command">Represents the vertical if command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(IfCommand_V command);

         /// <summary>
        /// Represents the visit method of the character input command.
        /// </summary>
        /// <param name="command">Represents the character input command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(InputCommand_Char command);

         /// <summary>
        /// Represents the visit method of the integer input command.
        /// </summary>
        /// <param name="command">Represents the integer input command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(InputCommand_Int command);

         /// <summary>
        /// Represents the visit method of the left command.
        /// </summary>
        /// <param name="command">Represents the left command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(LeftCommand command);

         /// <summary>
        /// Represents the visit method of the modulo command.
        /// </summary>
        /// <param name="command">Represents the modulo command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(ModuloCommand command);

         /// <summary>
        /// Represents the visit method of the multiply command.
        /// </summary>
        /// <param name="command">Represents the multiply command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(MultiplyCommand command);

         /// <summary>
        /// Represents the visit method of the not command.
        /// </summary>
        /// <param name="command">Represents the not command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(NotCommand command);

         /// <summary>
        /// Represents the visit method of the character output command.
        /// </summary>
        /// <param name="command">Represents the character output command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(OutCommand_Char command);

         /// <summary>
        /// Represents the visit method of the integer output command.
        /// </summary>
        /// <param name="command">Represents the integer output command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(OutCommand_Int command);

         /// <summary>
        /// Represents the visit method of the pop command.
        /// </summary>
        /// <param name="command">Represents the pop command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(PopCommand command);

         /// <summary>
        /// Represents the visit method of the put command.
        /// </summary>
        /// <param name="command">Represents the put command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(PutCommand command);

         /// <summary>
        /// Represents the visit method of the random command.
        /// </summary>
        /// <param name="command">Represents the random command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(RandomCommand command);

         /// <summary>
        /// Represents the visit method of the right command.
        /// </summary>
        /// <param name="command">Represents the right command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(RightCommand command);

         /// <summary>
        /// Represents the visit method of the string command.
        /// </summary>
        /// <param name="command">Represents the string command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(StringCommand command);

         /// <summary>
        /// Represents the visit method of the subtract command.
        /// </summary>
        /// <param name="command">Represents the subtract command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(SubtractCommand command);

         /// <summary>
        /// Represents the visit method of the swap command.
        /// </summary>
        /// <param name="command">Represents the swap command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(SwapCommand command);

         /// <summary>
        /// Represents the visit method of the up command.
        /// </summary>
        /// <param name="command">Represents the up command of the <see cref="BefungeProgram"/> interpreter.</param>
        void Visit(UpCommand command);
    }
}
