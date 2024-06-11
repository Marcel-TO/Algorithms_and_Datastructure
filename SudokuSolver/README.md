![Sudoku_solved_by_bactracking](https://github.com/Marcel-TO/Algorithms_and_Datastructure/assets/91308057/70e62c1b-04c0-4c72-b5d0-b13e6c1ecd37)

# SudokuSolver

## Task
Implement a Sudoku solver that takes a Sudoku puzzle as input and returns a valid solution.

```py
fn solve(puzzle: string) -> solution: string
```

Assume the input to be in the form of a string containing multiple liens of comma separated values:
```
5, 3, 0, 0, 7, 0, 0, 0, 0
6, 0, 0, 1, 9, 5, 0, 0, 0
0, 9, 8, 0, 0, 0, 0, 6, 0
8, 0, 0, 0, 6, 0, 0, 0, 3
4, 0, 0, 8, 0, 3, 0, 0, 1
7, 0, 0, 0, 2, 0, 0, 0, 6
0, 6, 0, 0, 0, 0, 2, 8, 0
0, 0, 0, 4, 1, 9, 0, 0, 5
0, 0, 0, 0, 8, 0, 0, 7, 9
```
> The empty fields are designated by the invalid value 0.

Prepare comprehensive unit tests.Strive for a unit test coverage of 100% (where sensible.)

### Minimum Requirements

- Use the **classic Sudoku rules**. [Additional variants](https://en.wikipedia.org/wiki/Sudoku#Variants) are optional.
- Be able to solve **9x9** Sudoku puzzles. Additional sizes are optional.
- Implement at least a [backtracking algorithm](https://en.wikipedia.org/wiki/Sudoku_solving_algorithms#Backtracking). More sophisticated approaches are appreciated.
- Be able to detect invalid/unsolvable puzzles.

---

### Useful Web-Links:

- [Wikipedia | SudokuLink](https://en.wikipedia.org/wiki/Sudoku)
- [Wikipedia | Sudoku Solving AlgorithmsLink](https://en.wikipedia.org/wiki/Sudoku_solving_algorithms)
- [NUnit unit-testing frameworkLink](https://nunit.org)
- [NUnit InstallationLink](https://docs.nunit.org/articles/nunit/getting-started/installation.html)
- [Unit test your code | MSDNLink](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-your-code?view=vs-2022)

---

### Data Driven Unit Tests

```csharp
[TestCase(-1)]
[TestCase(0)]
[TestCase(1)]
public void ReturnFalseGivenValuesLessThan2(int value)
{
    var result = _primeService.IsPrime(value);

    Assert.IsFalse(result, $"{value} should not be prime");
}
```

```csharp
[DataTestMethod]
[DataRow(-1)]
[DataRow(0)]
[DataRow(1)]
public void ReturnFalseGivenValuesLessThan2(int value)
{
    var result = _primeService.IsPrime(value);

    Assert.IsFalse(result, $"{value} should not be prime");
}
```

Sources:
- [Nunit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)
- [MsTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
