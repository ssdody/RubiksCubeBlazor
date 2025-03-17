# RubiksCubeBlazor

RubiksCubeBlazor is a Blazor WebAssembly application that simulates a Rubik's Cube. The project aims to provide an interactive and educational tool for users to explore and manipulate a digital Rubik's Cube. It utilizes Blazor for the user interface and leverages C# for the logic behind the cube's functionality, such as face rotations and cube state management.

## Features

- **Interactive Rubik's Cube:** Users can interact with a digital representation of the Rubik's Cube and rotate the cube faces.
- **Cube State Display:** The app provides a live representation of the cube state, showing each face's color.
- **Rotation Controls:** Rotate the cube faces clockwise or anti-clockwise, simulating real Rubik's Cube moves.
- **Blazor WebAssembly:** Built with Blazor WebAssembly, making it a cross-platform web application with modern web technologies.

## Project Structure

This project is organized into the following key components:

- **WebApplicationAPI:** Contains the core logic of the Rubik's Cube, including the cube state management and rotation logic.
- **WebApplicationUI (Blazor Client):** Contains the Blazor components responsible for displaying the cube and interacting with the user.

### WebApplicationAPI

The `WebApplicationAPI` namespace includes:
- **RubiksCube:** The model representing the Rubik's Cube, with methods for rotating faces and managing the state of the cube.
- **IRubiksCube Interface:** Defines the required operations for manipulating a Rubik's Cube.

### WebApplicationUI

The Blazor front-end provides:
- A user interface with a visual representation of the cube.
- Rotation buttons and controls that update the cube's state by calling the appropriate methods from `WebApplicationAPI`.

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- A modern web browser (Chrome, Firefox, Edge)

Build and Run the Application
- dotnet restore
- dotnet build
- dotnet run
