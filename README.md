# PowerPlant Production Plan System

## Overview

The PowerPlant Production Plan System is a robust and efficient solution for managing and calculating production plans for various types of power plants. It employs a modular and flexible architecture, likely influenced by principles of Clean Architecture, to ensure separation of concerns, scalability, and maintainability.

## Architecture

The system's architecture encompasses several layers and components, each with distinct responsibilities:

1. **Controller Layer (`ProductionPlanController`)**: Serves as the entry point for HTTP requests, orchestrating the flow of data between the client and the application.
2. **Service Layer (`MeritOrderCalculationService`)**: Handles business logic and decision-making processes. It selects the appropriate strategy based on input data.
3. **Strategy Layer**: Comprises specific strategies (`HighWindStrategy`, `LowCostFuelStrategy`, `HighDemandStrategy`) for different production scenarios. Each strategy is optimized for certain conditions.
4. **Core Strategy (`MeritOrderStrategy`)**: An abstract base class providing a common interface and shared functionalities for different strategies.

This architecture demonstrates characteristics of Clean Architecture with its emphasis on separation of concerns, where each layer has a distinct responsibility and communicates with each other in a well-defined manner.

## Strategy Diagram

                           [Controller]
                                |
                         [Service Layer]
                                |
                ---------------------------------
                |               |               |
       [HighWindStrategy] [LowCostFuelStrategy] [HighDemandStrategy]


## Exception Handling

The `ExceptionHandlingMiddleware` class intercepts exceptions in the request pipeline. It logs the exceptions using Serilog and returns a structured problem detail response to the client. This approach ensures that unhandled exceptions do not disrupt the system's stability and provides meaningful feedback to the client.
This middleware is an essential part of the system, enhancing its robustness by managing unexpected scenarios gracefully.

## Docker Implementation

### Dockerfile

The Dockerfile for the PowerPlant Production Plan System is designed to create a lightweight and efficient Docker image. It uses a multi-stage build process with the .NET 6.0 SDK for building the application and the .NET 6.0 runtime for the final image, ensuring a smaller image size and reduced attack surface.

### Docker Compose

The docker-compose.yml file simplifies the deployment of the PowerPlant Production Plan System. It defines the configuration for building and running the application in a Docker container, including port mapping, environment variables, and volume management for logs.

## Setup Instructions

To get started with the PowerPlant Production Plan System, follow these steps:

1. **Install Docker**: Download and install the latest version of Docker from [Docker Installation Guide](https://docs.docker.com/engine/install/).
2. **Install API Client**: Download and install an API client like Postman from [Postman Downloads](https://www.postman.com/downloads/).
3. **Download Source Files**: Clone or download the project's source files to your local machine.
4. **Navigate to Docker Compose File**: Open a terminal window and navigate to the directory containing the `docker-compose.yml` file.
5. **Build Docker Image**: Run the command `docker-compose build` to create a Docker image of the application.
6. **Run Application in Docker**: Execute `docker-compose up -d` to start running the application in a Docker container.
7. **Test POST Request**: Use Postman to create a POST request to `http://localhost:8888/productionplan`.
8. **Test GET Request**: In Postman, create a GET request to `http://localhost:8888/exception`.
9. **Check Logs**: Monitor the application's performance and issues by checking the logs folder.