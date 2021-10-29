//-----------------------------------------------------------------------
// <copyright file="BacktrackingSolverVM.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the view model of the backtracking algorithm which is used for solving the sudoku level.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel
{
    using System;
    using System.Collections.Generic;
    using Sudoku_Model;
    using Sudoku_Model.EventArgs;
    using Sudoku_ViewModel.EventArgs;

    /// <summary>
    /// Represents the view model of the backtracking algorithm.
    /// </summary>
    public class BacktrackingSolverVM
    {
        /// <summary>
        /// Represents the used backtracking solving algorithm.
        /// </summary>
        private BacktrackingSolver solver;

        /// <summary>
        /// Initializes a new instance of the <see cref="BacktrackingSolverVM"/> class.
        /// </summary>
        /// <param name="board">The view model of the game board.</param>
        /// <param name="rows">The amount of rows of the sudoku game.</param>
        /// <param name="columns">The amount of columns of the sudoku game.</param>
        public BacktrackingSolverVM(BoardVM board, int rows, int columns)
        {
            this.Solver = new BacktrackingSolver(board.Board.Fields);
            this.Solver.Unsolvable += this.FireUnsolveableEvent;
        }

        /// <summary>
        /// Occurs if the solved list gets synchronized.
        /// </summary>
        public event EventHandler<FieldVMListEventArgs> SynchronisingFields;

        /// <summary>
        /// Occurs if the current level is not solvable.
        /// </summary>
        public event EventHandler<UnsolvableVMEventArgs> Unsolveable;

        /// <summary>
        /// Gets the used backtracking algorithm.
        /// </summary>
        /// <value>The backtracking solving algorithm.</value>
        public BacktrackingSolver Solver
        {
            get
            {
                return this.solver;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.solver = value;
            }
        }

        /// <summary>
        /// Represents the start of the solving algorithm.
        /// </summary>
        public void InitializeSolvingSequence()
        {
            List<Field> fields = this.Solver.InitializeSolvingSequence();
            List<FieldVM> fieldVMs = this.ConvertToVMList(fields);

            this.SynchronisingFields?.Invoke(this, new FieldVMListEventArgs(fieldVMs));
        }

        /// <summary>
        /// Extracts the model field list of the current view model field list.
        /// </summary>
        /// <param name="fieldVMs">The view model field list.</param>
        /// <returns>The model field list of the current level.</returns>
        public List<Field> ExtractFieldsFromVM(List<FieldVM> fieldVMs)
        {
            List<Field> fields = new List<Field>();

            for (int i = 0; i < fieldVMs.Count; i++)
            {
                fields.Add(fieldVMs[i].Field);
            }

            return fields;
        }

        /// <summary>
        /// Represents the event that fires if the level is not solvable.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void FireUnsolveableEvent(object sender, UnsolvableEventArgs e)
        {
            this.Unsolveable?.Invoke(this, new UnsolvableVMEventArgs(e.IsSolveable));
        }

        /// <summary>
        /// Converts the current model list into a view model list.
        /// </summary>
        /// <param name="fields">The model field list.</param>
        /// <returns>The view model field list of the current level.</returns>
        private List<FieldVM> ConvertToVMList(List<Field> fields)
        {
            List<FieldVM> fieldVMs = new List<FieldVM>();

            for (int i = 0; i < fields.Count; i++)
            {
                fieldVMs.Add(new FieldVM(fields[i]));
            }

            return fieldVMs;
        }
    }
}
