# Dungeons & Dragons App README

Welcome to the Dungeons & Dragons (DnD) App README. This document provides all the necessary information to get you started with using the DnD app, a tool designed to enhance your Dungeons & Dragons gaming experience. Whether you're a Dungeon Master or a player, this app aims to streamline the game setup and storytelling process, making your adventures more immersive and enjoyable.

## Introduction

The DnD app is a Plang-based application that assists users in creating new game sessions, managing storylines, and generating dynamic story arcs for the Dungeons & Dragons: 5th Edition. It allows users to customize their game settings, including the choice of campaign books, roles, themes, tonality, and characters. The app is designed to be user-friendly, catering to both seasoned players and those new to the world of DnD.

## Before You Run

Before running the DnD app, you must have Plang installed on your system. Plang is a natural language programming language that powers the DnD app. To install Plang, follow the installation guide available at:

[Plang Installation Guide](https://github.com/PLangHQ/plang/blob/main/Documentation/Install.md)

Ensure you follow the instructions carefully to avoid any installation issues.

## How to Run

To run the DnD app, navigate to the app's folder in your terminal or command prompt and execute the following command:

```bash
plang
```
*If you have OpenAI key you can start with the parameter `plang --llmservice=openai`*

This command initiates the app, and you will be prompted with options to start a new game or continue with an existing storyline.

## How to Build

If the app does not run as expected, you may need to rebuild it. To rebuild the app, use the following command in the terminal or command prompt while in the app's folder:

```bash
plang build
```

This command compiles the app's source code, ensuring that any changes or updates are included in the build.

## Github Repository

For more information, to view the source code, or to contribute to the development of the DnD app, visit the Github repository at:

[DnD App Repository](https://github.com/PLangHQ/apps/tree/main/DnD)

If you have questions or need help, join the Discussion board at:

[Plang Discussion Board](https://github.com/PLangHQ/apps/discussions)

## Help with Plang

To learn more about Plang, contribute to its development, or seek assistance, visit the following resources:

- [Plang Repository](https://github.com/PLangHQ)
- [Plang Website](https://plang.is)

## Summary of Code

The DnD app's functionality is divided into several `.goal` files, each serving a specific purpose in the app's workflow. Here's a brief overview:

1. **Setup.goal**: Initializes the app by creating necessary tables (`games` and `story_lines`) in the database to store game sessions and their corresponding storylines.

2. **Start.goal**: Presents the user with options to either start a new game or continue with an existing storyline based on the Story Arc Id.

3. **CreateNewGame.goal**: Allows the user to set up a new game by choosing default settings or customizing their game setup. It then proceeds to start the game.

4. **LoadPreferences.goal**: Loads user preferences for the game setup if any custom settings are provided.

5. **StartGame.goal**: Marks the beginning of the game, loading necessary systems and initiating the storytelling process.

6. **CreateStoryLine.goal**: Generates new story arcs based on the game's current state, user input, and predefined story elements.

7. **SaveStoryLine.goal**: Saves the generated storylines to the database for future reference.

8. **ShowStoryLine.goal**: Displays the latest storyline to the user and provides options to continue the game or exit.

Each `.goal` file is designed to interact seamlessly, ensuring a smooth and engaging gaming experience for the user.