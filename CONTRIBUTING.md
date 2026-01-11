# Contributing to Blazor-ApexSankey

Thank you for your interest in contributing to Blazor-ApexSankey! We welcome contributions from the community.

## Getting Started

### Prerequisites

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   An IDE like Visual Studio 2022, VS Code, or JetBrains Rider

### Setting Up the Development Environment

1. Fork the repository
2. Clone your fork:

    ```bash
    git clone https://github.com/YOUR_USERNAME/Blazor-ApexSankey.git
    cd Blazor-ApexSankey
    ```

3. Restore dependencies:

    ```bash
    dotnet restore
    ```

4. Copy the `apexsankey.min.js` file from the [ApexSankey repository](https://github.com/apexcharts/apexsankey) to:

    ```
    src/Blazor-ApexSankey/wwwroot/apexsankey.min.js
    ```

5. Run the demo project:
    ```bash
    dotnet run --project src/Blazor-ApexSankey.Demo
    ```

## Development Workflow

### Branching Strategy

-   `main` - stable release branch
-   `develop` - development branch
-   Feature branches: `feature/your-feature-name`
-   Bug fix branches: `fix/issue-description`

### Making Changes

1. Create a new branch from `develop`:

    ```bash
    git checkout -b feature/your-feature-name
    ```

2. Make your changes

3. Ensure the code follows our coding standards (see `.editorconfig`)

4. Test your changes by running the demo application

5. Commit your changes with a clear message:
    ```bash
    git commit -m "feat: add new feature description"
    ```

### Commit Message Format

We follow [Conventional Commits](https://www.conventionalcommits.org/):

-   `feat:` - new feature
-   `fix:` - bug fix
-   `docs:` - documentation changes
-   `style:` - formatting, missing semicolons, etc.
-   `refactor:` - code refactoring
-   `test:` - adding tests
-   `chore:` - maintenance tasks

### Pull Requests

1. Push your branch to your fork
2. Open a Pull Request against the `develop` branch
3. Fill out the PR template with:
    - Description of changes
    - Related issues
    - Screenshots (if UI changes)
4. Wait for review and address any feedback

## Code Style

-   Follow the `.editorconfig` settings
-   Use meaningful variable and method names
-   Add XML documentation comments for public APIs
-   Keep methods focused and small

### C# Conventions

```csharp
// use lowercase for private fields with underscore prefix
private string _fieldName;

// use PascalCase for public properties
public string PropertyName { get; set; }

// use camelCase for local variables
var localVariable = "value";

// comments should start with lowercase
// this is a comment
```

### Razor Conventions

-   Use `@code` blocks at the bottom of `.razor` files
-   Keep markup clean and readable
-   Extract complex logic to code-behind or services

## Reporting Issues

When reporting issues, please include:

1. A clear description of the problem
2. Steps to reproduce
3. Expected behavior
4. Actual behavior
5. Browser and .NET version
6. Any relevant code snippets

## Feature Requests

We welcome feature requests! Please:

1. Check existing issues to avoid duplicates
2. Clearly describe the feature and its use case
3. Explain why it would benefit the project

## Questions?

Feel free to open an issue for questions or join the discussion in existing issues.

Thank you for contributing! 🎉
