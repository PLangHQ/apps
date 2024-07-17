# SimpleSyncDemo README

## Introduction
Welcome to the SimpleSyncDemo application! This application is designed to demonstrate the capabilities of syncing tasks across devices using the Plang programming language. It allows users to create tasks, list them, and sync these tasks with another device by setting up a connection through a public address system.
 
## Before you run
Before you can run the SimpleSyncDemo application, you need to ensure that Plang is installed on your system. Plang is a natural language programming language that makes coding more accessible and understandable.

### Installing Plang
To install Plang, follow the instructions provided in the official documentation:
[Plang Installation Guide](https://github.com/PLangHQ/plang/blob/main/Documentation/Install.md)

## How to run
Once Plang is installed, running the SimpleSyncDemo application is straightforward. Navigate to the application's folder in your terminal or command prompt and execute the following command:
```bash
plang
```
This command starts the application and allows you to interact with it.

## How to build
If the application does not run as expected, you may need to rebuild it. To do this, navigate to the application's folder in your terminal or command prompt and execute the following command:
```bash
plang build
```
This command rebuilds the application, potentially resolving any issues that prevented it from running initially.

## Github Repository
For more information about the SimpleSyncDemo application, including source code and updates, visit the Github repository:
[SimpleSyncDemo Repository](https://github.com/PLangHQ/apps/tree/main/SimpleSyncDemo)

If you have questions or need help, feel free to join the Discussion board:
[Plang Discussions](https://github.com/PLangHQ/apps/discussions)

## Help with Plang
To contribute to the development of Plang or to learn more about the project, visit the following resources:
- Plang Repository: [https://github.com/PLangHQ](https://github.com/PLangHQ)
- Plang Website: [https://plang.is](https://plang.is)

## Summary of code
The SimpleSyncDemo application consists of several `.goal` files that define its functionality. Here's a brief overview:

### Setup.goal
- Creates a table named `tasks` with columns for the task text and due date.

### Start.goal
- Checks if the other device's public key is set. If so, it listens for messages; otherwise, it prints the user's public address.
- Prompts the user to choose an action: list tasks, add a task, or set the address of the other device.
- Based on the user's choice, it calls the appropriate function to handle the request.
- Continuously listens for messages and processes them accordingly.

### Key Functions
- **ListenForMessage**: Listens for new messages from the other device and processes them.
- **PrintOutMyPubAddress**: Prints the user's public message address.
- **ShowList**: Lists all tasks.
- **AskForTask**: Prompts the user to enter a new task.
- **Sync**: Syncs events with the other device if the public key is set.
- **ProcessMessage**: Processes received messages.
- **StorePrivateKey**: Stores the private key for encryption.
- **SendSync**: Sends a sync message to the other device.
- **WriteToEventsTable**: Inserts event source data into the database.
- **AddTask**: Adds a new task to the tasks table.
- **SetOtherDevicePublicKey**: Sets the public key of the other device for syncing.

This application demonstrates basic task management and device-to-device communication using Plang's natural language programming capabilities.

**Note**: If you have an OpenAI API key, you can enhance the application's functionality by starting it with the following command:
```bash
plang --llmservice=openai
```
This enables additional features powered by OpenAI's services.