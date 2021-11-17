//-----------------------------------------------------------------------
// <copyright file="TraverseOrder.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines possible traversal orders of the splay tree.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Logic
{
    /// <summary>
    /// Represents the possible traversal options.
    /// </summary>
    public enum TraverseOrder
    {
        /// <summary>
        /// Represents the in-order traversal option.
        /// </summary>
        inOrder,

        /// <summary>
        /// Represents the pre-order traversal option.
        /// </summary>
        preOrder,

        /// <summary>
        /// Represents the post-order traversal option.
        /// </summary>
        postOrder
    }
}