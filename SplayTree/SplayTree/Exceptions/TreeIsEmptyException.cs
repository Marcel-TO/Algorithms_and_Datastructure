namespace SplayTree.Exceptions
{
    using System;

    public class TreeIsEmptyException : Exception
    {
        public TreeIsEmptyException(string message) : base(message)
        {
        }
    }
}
