![Splay_Tree_Search_Animation](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/ba939816-c183-4b36-940e-71c55dd9ebed)

# SplayTree

A **splay tree** is a [binary search tree](https://en.wikipedia.org/wiki/Binary_search_tree) with the additional property that recently accessed elements are quick to access again. All normal operations on a binary search tree are combined with one basic operation, called *splaying*.

Splaying the tree for a certain element rearranges the tree so that the element is placed at the root of the tree. One way to do this with the basic search operation is to first perform a standard binary tree search for the element in question, and then use [tree rotations](https://en.wikipedia.org/wiki/Tree_rotation) in a specific fashion to bring the element to the top.
    


Displays the search algorithm of the splay tree.

---

### Task

Provide at least the following functionality:

Implement a **splay tree** for storing integer values

- `# insert a new value into the treefn insert(value: int)`
- `# remove a value from the tree# returns the count of removed valuesfn remove(value: int) -> int`
- `# remove all values from the treefn clear()`
- `# return the total number of stored valuesfn count() -> int`
- `# find the smallest value stored in the treefn minimum() -> int`
- `# find the largest value stored in the treefn maximum() -> int`
- `# return the number of occurances of a specific valuefn count(value: int) -> int`
- `# check for the occurance of a specific valuefn contains(value: int) -> bool`
- `# traverse the tree pre-order, in-order (default) or post-orderfn traverse(order: OrderEnum) -> list«int»`

Prepare comprehensive unit tests.Strive for a unit test coverage of 100% (where sensible.)

### Bonus Tasks

- Implement a generic tree that can store different data types with a defined order relation.
- Implement `traverse` in an iterative fashion.
- Visualize the tree (or even the rotations)

---

### Useful Web-Links

- [Splay Tree | WikipediaLink](https://en.wikipedia.org/wiki/Splay_tree)
- [Splay Tree VisualizationLink](https://www.cs.usfca.edu/~galles/visualization/SplayTree.html)
