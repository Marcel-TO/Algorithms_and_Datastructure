//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the main view model of the sudoku game.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Sudoku_Model;
    using Sudoku_ViewModel.EventArgs;

    /// <summary>
    /// Represents the main view model of the sudoku.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the view model of the current game board.
        /// </summary>
        private BoardVM board;

        /// <summary>
        /// Represents the observable collection of the view model field list.
        /// </summary>
        private ObservableCollection<FieldVM> fields;

        /// <summary>
        /// Represents the amount of rows of the sudoku board.
        /// </summary>
        private int rows;

        /// <summary>
        /// Represents the amount of columns of the sudoku board.
        /// </summary>
        private int columns;

        /// <summary>
        /// Represents the class for solving the current selected sudoku.
        /// </summary>
        private BacktrackingSolverVM solver;

        /// <summary>
        /// Represents the factory for creating a sudoku level.
        /// </summary>
        private LevelFactoryVM lvlFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.rows = 9;
            this.columns = 9;
            this.IsUnsolveable = false;
            this.IsFileNotValid = false;

            this.lvlFactory = new LevelFactoryVM(this.rows * this.columns);
            this.lvlFactory.BoardCreated += this.BoardCreated;
            this.lvlFactory.FileNotValid += this.FileNotValid;
            this.fields = new ObservableCollection<FieldVM>();
            this.Board = new BoardVM(new Board(new List<Field>()), new List<FieldVM>());
            
            this.solver = new BacktrackingSolverVM(this.Board, this.rows, this.columns);
            this.solver.SynchronisingFields += this.SnychronisingFields;
            this.solver.Unsolveable += this.Unsolveable;
        }
        
        /// <summary>
        /// Fires if a value got changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the view model of the game board.
        /// </summary>
        /// <value>The current game board view model instance.</value>
        public BoardVM Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null.");
                }

                this.board = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Board)));
            }
        }

        /// <summary>
        /// Gets the observable collection of the view model field list.
        /// </summary>
        /// <value>The observable collection of the current view model field list.</value>
        public ObservableCollection<FieldVM> Fields
        {
            get
            {
                return this.fields;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.fields = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Fields)));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current sudoku level is solvable.
        /// </summary>
        /// <value>Indicates whether the level is unsolvable.</value>
        public bool IsUnsolveable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current sudoku level is valid.
        /// </summary>
        /// <value>Indicates whether the level is loadable.</value>
        public bool IsFileNotValid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the command for initializing the backtracking algorithm.
        /// </summary>
        /// <value>The command which starts the backtracking algorithm.</value>
        public ICommand BacktrackingStart
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.solver.InitializeSolvingSequence();
                });
            }
        }

        /// <summary>
        /// Gets the command for checking if the current values of the fields are allowed.
        /// </summary>
        /// <value>The command which checks if the current values of the fields are allowed.</value>
        public ICommand CheckCurrentFields
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.ResetAllowingAttributes();

                    List<FieldVM> fields = new List<FieldVM>();

                    for (int i = 0; i < this.Board.FieldVMs.Count; i++)
                    {
                        fields = this.CheckIfPositionIsAllowed(this.Board.FieldVMs, i);
                    }

                    this.Board.FieldVMs = fields;
                    this.Fields = new ObservableCollection<FieldVM>(this.Board.FieldVMs);
                });
            }
        }

        /// <summary>
        /// Gets the command for exiting the game.
        /// </summary>
        /// <value>The command which exits the game.</value>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    Environment.Exit(0);
                });
            }
        }

        /// <summary>
        /// Loads a game level from a file.
        /// </summary>
        /// <param name="path">The path of the selected file.</param>
        public void LoadGameFile(string path)
        {
            this.lvlFactory.LoadLevel(path);
        }

        /// <summary>
        /// Represents a method for creating the field list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        public void BoardCreated(object sender, BoardVMEventArgs e)
        {
            this.Board = e.Board;
            this.Fields = new ObservableCollection<FieldVM>(this.Board.FieldVMs);
            this.solver.Solver.Fields = this.solver.ExtractFieldsFromVM(this.Board.FieldVMs);
        }

        /// <summary>
        /// Occurs if the field list got synchronized.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void SnychronisingFields(object sender, FieldVMListEventArgs e)
        {
            this.Board = new BoardVM(this.Board.Board, e.Fields);
            this.Fields = new ObservableCollection<FieldVM>(this.Board.FieldVMs);
        }

        /// <summary>
        /// Occurs if the sudoku level is not solvable.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void Unsolveable(object sender, UnsolvableVMEventArgs e)
        {
            if (!e.IsSolveable)
            {
                this.IsUnsolveable = true;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsUnsolveable)));
            }
        }

        /// <summary>
        /// Occurs if the sudoku level is not loadable.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void FileNotValid(object sender, FileNotValidVMEventArgs e)
        {
            if (e.IsFileNotValid)
            {
                this.IsFileNotValid = true;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsFileNotValid)));
                this.Board = e.Board;
                this.Fields = new ObservableCollection<FieldVM>(this.Board.FieldVMs);
            }
        }

        /// <summary>
        /// Represents a method resetting the allowing attributes.
        /// </summary>
        private void ResetAllowingAttributes()
        {
            for (int i = 0; i < this.Board.FieldVMs.Count; i++)
            {
                this.Board.FieldVMs[i].IsAllowed = true;
            }
        }

        /// <summary>
        /// Represents a method that checks if the number of the current field is allowed.
        /// </summary>
        /// <param name="fields">The list of the view model fields.</param>
        /// <param name="index">The index of the current view model field.</param>
        /// <returns>The updated view model field list.</returns>
        private List<FieldVM> CheckIfPositionIsAllowed(List<FieldVM> fields, int index)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (i != index)
                {
                    if (fields[i].Field.Column == fields[index].Field.Column && fields[i].Field.Number == fields[index].Field.Number && fields[index].Field.Number != 0 && fields[i].Field.Number != 0)
                    {
                        fields[i].IsAllowed = false;
                        fields[index].IsAllowed = false;
                    }

                    if (fields[i].Field.Row == fields[index].Field.Row && fields[i].Field.Number == fields[index].Field.Number && fields[index].Field.Number != 0 && fields[i].Field.Number != 0)
                    {
                        fields[i].IsAllowed = false;
                        fields[index].IsAllowed = false;
                    }

                    if (fields[i].Field.Block == fields[index].Field.Block && fields[i].Field.Number == fields[index].Field.Number && fields[index].Field.Number != 0 && fields[i].Field.Number != 0)
                    {
                        fields[i].IsAllowed = false;
                        fields[index].IsAllowed = false;
                    }
                }
            }

            return fields;
        }
    }
}
