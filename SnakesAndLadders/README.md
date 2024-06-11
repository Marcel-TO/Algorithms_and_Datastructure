![snakes-and-ladders-sim](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/eada4914-bad0-40cf-bbd6-eec99c38a741)

# Monte Carlo Simulation

## Task

Simulate individual games of *Snakes and Ladders* using a **Monte Carlo Simulation**.

- Allow for variably sized boards, different distributions of snakes and ladders, and various die sizes.
- Determine the average number of moves needed for a single player to reach the end.
- Record the lowest number of moves and its die rolls.

- Prepare comprehensive unit testsStrive for a unit test coverage of 100% (where sensible).

## Bonus Tasks

- Run simulations in parallel
- Allow for non-uniformly distributed die-rolls.
- Plot the results of your simulations.
- Compare your results to the expected number of moves provided by the fundamental matrix of the corresponding absorbing Markov Chain.

---

## Useful Web-Links

- [Snakes and Ladders | Wikipedia](https://en.wikipedia.org/wiki/Snakes_and_ladders)
    > Any version of Snakes and Ladders can be represented exactly as an [absorbing Markov chain](https://en.wikipedia.org/wiki/Absorbing_Markov_chain), since from any square the odds of moving to any other square are fixed and independent of any previous game history. 
    The Milton Bradley version of *Chutes and Ladders* has 100 squares, with 19 chutes and ladders. A player will need an average of 39.2 spins to move from the starting point, which is off the board, to square 100. A two-player game is expected to end in 47.76 moves with a 50.9% chance of winning for the first player. Those calculations are based on a variant where throwing a six does not lead to an additional roll; and where the player must roll the exact number to reach square 100 and if they overshoot it their counter does not move.
    
- [Markov Chain | WikipediaLink](https://en.wikipedia.org/wiki/Markov_chain)
- [Markov Chain SimulatorLink](https://setosa.io/markov/#%7B"tm"%3A%5B%5B0.5%2C0.5%5D%2C%5B0.5%2C0.5%5D%5D%7D)
- [Analysis of Chutes and LaddersLink](https://www.datagenetics.com/blog/november12011/index.html)
- [Absorbing Markov Chain | WikipediaLink](https://en.wikipedia.org/wiki/Absorbing_Markov_chain)
- [Math.NET NumericsLink](https://numerics.mathdotnet.com)
