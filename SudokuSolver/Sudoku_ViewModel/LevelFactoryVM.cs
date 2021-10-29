//-----------------------------------------------------------------------
// <copyright file="LevelFactoryVM.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the view model of the level factory which is used for creating the sudoku level.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel
{
    using System;
    using System.Collections.Generic;
    using Sudoku_Model;
    using Sudoku_Model.EventArgs;
    using Sudoku_Model.Exceptions;
    using Sudoku_ViewModel.EventArgs;

    /// <summary>
    /// Represents the view model of the level factory.
    /// </summary>
    public class LevelFactoryVM
    {
        /// <summary>
        /// Represents the model of the level factory.
        /// </summary>
        private LevelFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelFactoryVM"/> class.
        /// </summary>
        /// <param name="amount">The amount of the field size.</param>
        public LevelFactoryVM(int amount)
        {
            this.factory = new LevelFactory(amount);
        }

        /// <summary>
        /// Occurs if the list of fields got created.
        /// </summary>
        public event EventHandler<BoardVMEventArgs> BoardCreated;

        /// <summary>
        /// Occurs if the loaded file is not valid.
        /// </summary>
        public event EventHandler<FileNotValidVMEventArgs> FileNotValid;

        /// <summary>
        /// Loads the level content from the a file.
        /// </summary>
        /// <param name="path">The path of the current file.</param>
        public void LoadLevel(string path)
        {
            Board board;

            try
            {
                board = this.factory.LoadLevel(path);
            }
            catch (BoardNotPossibleException)
            {
                BoardVM emptyVM = this.CreateBoardVM(new Board(new List<Field>()));
                this.FileNotValid?.Invoke(this, new FileNotValidVMEventArgs(true, emptyVM));
                return;
            }

            BoardVM boardVM = this.CreateBoardVM(board);

            this.BoardCreated?.Invoke(this, new BoardVMEventArgs(boardVM));
        }

        /// <summary>
        /// Represents the method for creating the view model of the game board.
        /// </summary>
        /// <param name="board">The current model of the game board.</param>
        /// <returns>The new created view model of the game board.</returns>
        private BoardVM CreateBoardVM(Board board)
        {
            List<FieldVM> fieldVMs = new List<FieldVM>();

            for (int i = 0; i < board.Fields.Count; i++)
            {
                fieldVMs.Add(new FieldVM(board.Fields[i]));
            }

            return new BoardVM(board, fieldVMs);
        }
    }
}
