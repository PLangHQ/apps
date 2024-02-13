# Natural Language Command Interface for Windows

## Overview

We, the users, need to adjust to the computer. 

If you want to change the screen timeout on your computer, you need to find where that is done. How do you find it? Maybe you know, maybe you have no clue. Maybe you google it or ask ChatGPT. Then you get the instructions and you need to do multiple clicks and search on the screen where the settings are.

Wouldn't it be better if you just told your computer: 

    Set screen timeout to 45 minutes

That is what this app is for. It's like Google Home/Alexa/Siri for you Windows machine.

If the app doesn't know how to execute your request, it will ask you, to help construct a valid request.

## How to use

Download the content of this repository to your computer. Open terminal/cmd, navigator to the directory and run the command

```bash
plang
```

## Examples
Here are some examples

- set screen timeout to 20 minutes when on battery
- change desktop background to c:\background.jpg
- set font size system wide to 120 dpi
- open example.org
- open spotify
- how much space do I have on my hardrive
- what the current time
- in what timezone am I
- disable wifi
- what users are on my computer
- what the uptime of my computer

You can also write in your own language, and it will understand you and reply in same language

## Flow of app
This application functions as an interactive assistant that processes user input to potentially execute PowerShell commands or provide explanations based on a set of predefined responses. 

Here’s a breakdown of [Start.goal](./Start.goal)

### Start
1. **Initialize Default Prompt**: The application sets a default prompt `%question%` to "What's up?" to initiate interaction with the user.
2. **User Input**: It then prompts the user with `%question%`, requiring a response that is captured and stored in `%userStatement%`.
3. **System Configuration Load**: The app loads configurations or instructions from a file named `powerShell.txt` located in the `llm/powershell/` directory into `%powerShellSystem%`.

4. **Command Decision**:
    - Utilizing a machine learning model (`gpt-4-0125-preview`), the application processes `%userStatement%` against `%powerShellSystem%` to determine if there are any PowerShell commands (`%commands%`) related to the user's statement.
    - If relevant PowerShell commands are identified (`%commands%` is not null or empty), the app proceeds to execute these commands via `!RunPSCommands`.
    - If no relevant commands are found, the app transitions to a fallback system called `!WhatsUpSystem` for further processing.

### WhatsUpSystem
1. **Explanation System Load**: The app reads from an `explain.txt` file within the `llm/powershell/` directory, which likely contains data or logic for explaining concepts or commands, storing this in `%explainSystem%`.
2. **Generate Explanation**:
    - Again leveraging the `gpt-4-0125-preview` model, the app uses `%explainSystem%` and the user's original statement (`%userStatement%`) to generate an explanation, which includes a summary, a command (if applicable), a natural language version of the command, the language used, and the original question.
    - The generated summary and natural language command are displayed to the user.
3. **Loop Back**: After providing the explanation, the app calls `!Start` to loop back to the initial prompt, allowing for continuous interaction.

### RunPSCommands
1. **Execute Commands**: For each command in `%commands%`, the app calls `RunPSCommand` to execute it.
2. **Loop Back**: After executing all commands, the app loops back to the initial prompt by calling `!Start`.

### RunPSCommand
1. **Command Execution Notification**: The app notifies the user that it is running a specific command (`%command%`).
2. **PowerShell Execution**:
    - The command is executed in a PowerShell terminal with parameters set to bypass execution policies, ensuring the command runs without restrictions.
    - The output of the command execution is captured in `%output%`.
3. **Display Output**: The output of the PowerShell command is displayed to the user, providing immediate feedback on the executed command.

