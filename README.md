# Levi9 Cloud Challenge

A C# ASP.NET CORE Web API app for basketball players stats.

## Table of Contents

- [Environment Setup](#environment-setup)
- [Build Instructions](#build-instructions)
- [Running the App](#running-the-app)
- [Technologies Used](#technologies-used)

## Environment Setup

Ensure you have the following prerequisites installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Build Instructions

1. Clone the repository:

    ```bash
    git clone https://github.com/bigburek/CloudChallenge.git
    ```

2. Navigate to the project directory:

    ```bash
    cd CloudChallenge
    ```

3. Build the project:

    ```bash
    dotnet build
    ```
    
4.Running tests:
    ```bash
    dotnet test
    ```

## Running the App

To run the application, use the following command:

```bash
dotnet run

Visit http://localhost:{see port in console} in your web browser to access the application.
Use the /stats/player/{fullPlayerName} endpoint

## Techonologies Used
ASP NET CORE
Swagger
Json.NET library
CsvHelper library
Moq library
xUnit.net library

