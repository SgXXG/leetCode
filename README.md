# leetCode

A collection of LeetCode solutions in C# by [SgXXG](https://github.com/SgXXG).

## Overview

This repository contains C# solutions to a wide range of LeetCode coding problems. Each solution is implemented as a class in `Program.cs`, often following the problem's canonical structure and naming conventions. The project is structured as a .NET console application.

## Features

- 📚 **Comprehensive**: Includes solutions for classic LeetCode problems (arrays, strings, linked lists, trees, dynamic programming, etc.).
- 📝 **Well-Commented**: Each class and method is documented with XML-style comments for clarity.
- 🏷️ **Single File**: All solutions are consolidated in `Program.cs` for easy navigation and management.
- 🟦 **.NET Support**: Comes with C# project files (`leetCode.csproj`, `leetCode.sln`) for direct usage in Visual Studio or via CLI.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed (any recent version compatible with your environment).

### Running the Code

Clone the repository:

```bash
git clone https://github.com/SgXXG/leetCode.git
cd leetCode
```

Run the solutions:

```bash
dotnet run
```

You can view and modify the `Main()` method in `Program.cs` to test different solutions or add new ones.

## Repository Structure

```
.
├── .github/              # GitHub workflows and templates
├── .vs/                  # Visual Studio settings (can be ignored)
├── bin/                  # Build output (auto-generated)
├── obj/                  # Build temp files (auto-generated)
├── leetCode.csproj       # C# project file
├── leetCode.sln          # Solution file for Visual Studio
├── Program.cs            # All LeetCode solutions & entry point
└── README.md             # This file
```

## Sample Solutions

Here are a few representative problems implemented in this repo:

- **Remove Zero Sum Sublists** (`LinkedListSolution`)
- **Squares of a Sorted Array** (`SquaresOfASortedArraySolution`)
- **Power of Two / Three / Four** (`PowerOfTwoSolution`, `PoweOfThreeSolution`, `PowerOfFourSolution`)
- **Climbing Stairs** (`ClimbingStairsSolution`)
- **Decode Ways** (`DecodeWaysSolution`)
- **Image Smoother** (`ImageSmootherSolution`)
- **Valid Anagram** (`ValidAnagramSolution`)
- **Product of Array Except Self** (`ProductOfArrayExceptSelfSolution`)
- ...and many more!

Each solution is a self-contained class/method, often with helper classes (`ListNode`, `TreeNode`, etc.) defined as needed.

## Contributing

Contributions and suggestions are welcome! Feel free to fork this repo, add your own solutions, or improve existing ones. Please use clear class and method names that match the problem statement where possible.

## License

This repository is licensed under the MIT License.

---

Happy Coding! 🚀
