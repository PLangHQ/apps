# SimpleSyncDemo Application README

Welcome to the SimpleSyncDemo application! This guide will help you set up and run the application, even if you're new to using command-line interfaces. Follow the steps below to get started.

## Prerequisites

Before you begin, you need to install Plang. Follow the installation guide here: [Install Plang](https://github.com/PLangHQ/plang/blob/main/Documentation/Install.md).

## Installation and Setup

1. **Clone the Repository:**
   To see the syncing feature in action, clone the repository to your computer. You can find the repository at [SimpleSyncDemo Repository](https://github.com/PLangHQ/apps/tree/main/SimpleSyncDemo).

2. **Create Two Copies:**
   Create a copy of the `SimpleSyncDemo` folder so that you have two folders of `SimpleSyncDemo`. This will allow you to simulate synchronization between two instances of the application.

## Running the Application

To run the application, follow these steps for each copy of the `SimpleSyncDemo` folder:

1. **Open Terminal or Command Prompt:**
   Navigate to the folder where you have the application using the terminal or command prompt.

2. **Execute the Application:**
   Run the application by typing the following command and pressing Enter:
   ```bash
   plang
   ```

   If the application does not run, try rebuilding it with:
   ```bash
   plang build
   ```

3. **Follow On-Screen Instructions:**
   - The application will start by asking for the other computer's public key. Simply press Enter to leave it empty initially.
   - When the application runs, it will display the public address it has.
   - Type `3` from the menu and paste in the public address of the other app instance.

4. **Add a New Task:**
   Try to add a new task in one of the instances, and you should see the app sync the task to the other instance.

## Using OpenAI API

If you have an OpenAI API key, you can enhance the application's capabilities by starting it with the following command:
```bash
plang --llmservice=openai
```

## Summary of Code

The application consists of several `.goal` files that define its functionality:

### 1. Setup.goal
- **Purpose:** Creates a table named `tasks` with columns for text and due date.

### 2. Start.goal
- **Purpose:** Manages the application's main functionality including syncing tasks between devices.
- **Key Functions:**
  - **ListenForMessage:** Listens for new messages from the other device and processes them.
  - **PrintOutMyPubAddress:** Displays the public address for messaging.
  - **ShowList:** Displays all tasks.
  - **AskForTask:** Prompts the user to enter a new task.
  - **Sync:** Handles the synchronization of tasks.
  - **ProcessMessage:** Processes incoming messages.
  - **AddTask:** Adds a new task to the database and triggers sync.
  - **SetOtherDevicePublicKey:** Sets the public key for the other device to enable secure communication.

## Support and Contributions

- **Questions and Discussions:** If you have questions or need help, join the discussion board at [PLang Discussions](https://github.com/PLangHQ/apps/discussions).
- **Contributing:** Help develop Plang further by visiting the [Plang Repository](https://github.com/PLangHQ) and the [Plang Website](https://plang.is).

Enjoy using SimpleSyncDemo and exploring the capabilities of Plang!