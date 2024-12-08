# Problem Solving with Code

![Drjdelano ebook github](https://github.com/user-attachments/assets/a6f0c52d-2281-4cbd-ace6-08ef9d36108c)

Welcome to the official repository for *Problem Solving with Code*! This repository contains all the code examples and projects featured in the book, organized by chapter.

## About the Book

*Problem Solving with Code* is a hands-on guide to programming that focuses on teaching the fundamentals of coding while tackling real-world problems. Throughout the book, you will:

- Learn key programming concepts like recursion, interfaces, and file input/output.
- Follow along with Alex, the main character, as he develops a game from scratch.
- Explore problem-solving strategies rooted in a biblical perspective, emphasizing faith, perseverance, and purpose.

## Repository Structure

Each chapter in the book is represented as a branch in this repository. This structure allows you to view the code as it evolves throughout the book. To access the code for a specific chapter:

1. Switch to the branch corresponding to the chapter you’re studying.
2. Explore the code examples and projects within that branch.

### Branch Naming Convention
- `chapter-1`
- `chapter-2`
- `chapter-3`
- ...

## Prerequisites

To run the code in this repository, you will need:

- [Visual Studio Code](https://code.visualstudio.com/): The recommended development environment.
- [.NET SDK](https://dotnet.microsoft.com/download): Ensure the correct version is installed.

## How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/jdelano/problem-solving-with-code.git
   ```
2. Switch to the branch of the chapter you’re studying:
   ```bash
   git checkout chapter-1
   ```
3. Open the folder in Visual Studio Code and explore the code.
4. Run the examples using the .NET CLI:
   ```bash
   dotnet run
   ```

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and share the code with proper attribution.

## Questions or Feedback?

If you have questions about the code or suggestions for improvement, feel free to open an issue or contact the author through the book’s official website.

Happy coding!

## Known Errors

The following errors were discovered in the book after it went to press:

- Chapter 8
   - Code Block 8.6: 
      - On line 15, the type of the grid parameter for the Matches method should be `ItemType` instead of `ResourceType`.
      - On line 21, the pattern array name should be lower case `pattern` instead of upper case `Pattern`.
   - Code Block 8.9: The parameters passed into the Equipment constructor were in the wrong order. The correct code should be as follows:
      ```csharp
      Equipment sword = new Equipment(ItemType.Sword, 1, 50, 25);
      ```
- Appendix A
   - Code Block A.5:
      - On line 7, the type of the result parameter should be `Item` instead of `Resource`.
- Appendix B
   - On page 226, coalescing was spelled incorrectly.
   
