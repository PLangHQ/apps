# CreateModule README

## Introduction

Welcome to the CreateModule app! This application helps developers create a module to extend the Plang programming language. It generates a `Program.cs` file as a starting point for your module and includes necessary NuGet packages if needed.

## Before you run

Before you can run this application, you need to have Plang installed on your system. Follow the installation instructions provided in the [Plang Installation Guide](https://github.com/PLangHQ/plang/blob/main/Documentation/Install.md).

## How to run

1. Open your terminal or command prompt.
2. Navigate to the folder where the CreateModule app is located.
3. Execute the following command to run the app:
    ```bash
    plang
    ```

## How to build

If the app does not run as expected, you may need to rebuild it. Use the following command to rebuild the app:
```bash
plang build
```

## Github Repository

The repository for this app is located at [CreateModule Repository](https://github.com/PLangHQ/apps/tree/main/CreateModule). If you have any questions or need further assistance, feel free to join the [Discussion board](https://github.com/PLangHQ/apps/discussions).

## Help with Plang

If you want to contribute to the development of Plang or need more information, visit the [Plang repository](https://github.com/PLangHQ) and our [website](https://plang.is).

## Summary of code

### Start.goal

- The app starts by ensuring the user has `dotnet` in their PATH variable.
- It prompts the user for the module name and description.
- It calls the `AskForExamples` goal to gather example steps from the user.
- It optionally fetches documentation from a provided URL.
- It reads the `llm/system.txt` file for system instructions.
- It uses the provided information to generate a `Program.cs` file and a `Start.goal` file for the new module.
- It initializes a new class library project using `dotnet new classlib`.
- It deletes the default `Class1.cs` file.
- It adds any necessary NuGet packages by calling the `AddNuget` goal.

### AskForExamples.goal

- This goal repeatedly asks the user for example steps until the user types "D" (done).
- It collects these examples into a list.

### AddNuget.goal

- This goal adds the specified NuGet package to the new module's project using the `dotnet add package` command.

## Example of usage

Here is an example of creating an EmailModule:

1. Start by giving it a name: `EmailModule`
2. Write a description for it: `Send and receive email using SMTP and POP3.`
3. Provide example Plang code:
    ```plang
    - send email %to%, %subject%, %body%
    - get new emails, write to %emails%
    ```

This will create a `Program.cs` file in the module folder as well as a C# project file.

Note: This app is meant to be a starting point for developers. You may need to modify the generated code to fit your specific needs.