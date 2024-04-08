# README for ElevenLabs Application

## Introduction

Welcome to the ElevenLabs application! This app allows you to convert text into sound using the ElevenLabs API [- You need API key](https://elevenlabs.io/). It's a simple yet powerful tool that can generate audio files from your stories or any text you wish to hear spoken aloud. Whether you're creating content, learning through auditory methods, or just having fun, this app is designed to be easy to use, even for computer novices.

## Before you run

Before you can run the ElevenLabs application, you need to have Plang installed on your computer. Plang is the programming language used to develop this app. If you haven't installed Plang yet, please follow the installation guide available at:

[Plang Installation Guide](https://github.com/PLangHQ/plang/blob/main/Documentation/Install.md)

## How to run

To run the ElevenLabs application, follow these steps:

1. Open your terminal or command prompt.
2. Navigate to the folder where the ElevenLabs application is located.
3. Execute the command `plang`.

If you encounter any issues running the app, please ensure you have correctly installed Plang as per the instructions in the "Before you run" section.

## How to build

If the application does not run as expected, you may need to rebuild it. To rebuild the ElevenLabs application, use the following command in your terminal or command prompt:

```bash
plang build
```

This command compiles the application and prepares it for execution.

## Github Repository

For more information, source code, or if you have questions, you can visit the ElevenLabs application repository on GitHub:

[ElevenLabs Application Repository](https://github.com/PLangHQ/apps/tree/main/ElevenLabs)

If you have questions or need help, feel free to join the Discussion board at:

[Discussion Board](https://github.com/PLangHQ/apps/discussions)

## Help with Plang

Interested in developing with Plang or contributing to its growth? Visit the Plang repository and website for more information:

- [Plang Repository](https://github.com/PLangHQ)
- [Plang Website](https://plang.is)

## Summary of Code

The ElevenLabs application consists of a single goal file, `Start.goal`, which orchestrates the process of converting text to speech using the ElevenLabs API. Here's a breakdown of its functionality:

1. **Setup**: The application sets default values for the path (`%path%`) and filename (`%fileName%`) of the generated sound file. It checks if the file already exists to avoid overwriting.
2. **Voice Selection**: It reads a list of voices from `voices.json` and selects a default voice, "Paul". However, this can be customized.
3. **Text Processing**: The application cleans the input text (`%story%`) by removing specific formatting characters.
4. **API Request**: It sends a request to the ElevenLabs API with the processed text and selected voice settings, receiving an audio file in response.
5. **File Handling**: The app creates a folder named 'sound' if it doesn't exist and saves the received audio file to this folder.
6. **Playback**: Finally, it automatically opens the generated audio file using the default media player on the user's operating system.

This goal file is designed to be straightforward and user-friendly, ensuring that even those new to programming or command-line tools can successfully use the application.