![maze_demo](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/2dd03467-faea-472e-b2f8-535166beea12)

# Maze Generator

## Task

Generate a sigma (hexagonal) maze of arbitrary size using Wilson's algorithm.

```
fn generate(width: int, height: int) -> Maze
```

**Visualize** the maze in a way of your choosing

Prepare comprehensive unit tests.Strive for a unit test coverage of 100% (where sensible.)

## Bonus Tasks

- Visualize the generation of the maze
- Support different maze and/or room shapes
    
    

---

## Hexagon Grid
To generate hexagon’s you need to work with axial coordinates (q, r, s).

> Hexagons are 6-sided polygons. *Regular* hexagons have all the sides the same length. I'll assume all the hexagons we're working with here are regular. The typical orientations for hex grids are vertical columns (**flat topped**) and horizontal rows (**pointy topped**).
>
> Hexagons have 6 sides and 6 corners. Each side is shared by 2 hexagons. Each corner is shared by 3 hexagons. For more about centers, sides, and corners, see [my article on grid parts](http://www-cs-students.stanford.edu/~amitp/game-programming/grids/) (squares, hexagons, and triangles).

<img width="429" alt="hexagon" src="https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/bc95aa45-7b9e-4ae2-9d71-ad84b4fbb907">

[Full article here!](https://www.redblobgames.com/grids/hexagons/)

---

### Wilson’s Maze Algorithm

> Wilson’s algorithm uses [loop-erased random walks](http://en.wikipedia.org/wiki/Loop-erased_random_walk) to generate a uniform [spanning tree](http://en.wikipedia.org/wiki/Spanning_tree) — an unbiased sample of all possible spanning trees. Most other maze generation algorithms, such as [Prim’s](https://bl.ocks.org/mbostock/11159599), [random traversal](https://bl.ocks.org/mbostock/70a28267db0354261476) and [randomized depth-first traversal](https://bl.ocks.org/mbostock/1ef3b1fb9eb35ca8ffff), do not have this beautiful property.
> 
> 
> The algorithm initializes the maze with an arbitrary starting cell. Then, a new cell is added to the maze, initiating a random walk (shown in magenta). The random walk continues until it reconnects with the existing maze (shown in white). However, if the random walk intersects itself, the resulting loop is erased before the random walk continues.
> 
> Initially, the algorithm can be frustratingly slow to watch, as the early random walks are unlikely to reconnect with the small existing maze. However, as the maze grows, the random walks become more likely to collide with the maze and the algorithm accelerates dramatically.
> 
> Source: https://bl.ocks.org/mbostock/11357811

***The algorithm goes something like this:***

1. Choose any vertex at random and add it to the UST.
2. Select any vertex that is not already in the UST and perform a random walk until you encounter a vertex that is in the UST.
3. Add the vertices and edges touched in the random walk to the UST.
4. Repeat 2 and 3 until all vertices have been added to the UST.
