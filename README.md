# Chatbot API

This is a .NET 8.0 application with Swagger UI running inside a Docker container. This guide will walk you through the steps to build, run, and access the application.

## Prerequisites

- Docker installed on your machine
- .NET SDK installed

## Getting Started

### 1. Clone the Repository

Clone the repository to your local machine:

```sh
git clone <repository-url>
cd <repository-directory>

### 2. Build the Docker Image
## Use the following command to build the Docker image:

docker build -t chatbot-api .

### 3. Run the Docker Container
## Run the Docker container with the following command:

docker run -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development chatbot-api

4. Access Swagger UI
Open your browser and go to:

bash
Copy code
http://localhost:8080/swagger
You should see the Swagger UI for the Chatbot API.

Project Structure
Program.cs: The entry point of the application.
Startup.cs: Configures services and the app's request pipeline.
Controllers/: Contains the API controllers.
Models/: Contains the data models.
Data/: Contains the database context.
Services/: Contains the business logic.
Dockerfile
Here's the Dockerfile used to build the application:

dockerfile
Copy code
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ChatbotAPI.csproj", "."]
RUN dotnet restore "./ChatbotAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./ChatbotAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ChatbotAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatbotAPI.dll"]
Troubleshooting
Issue: Application Not Starting
If the application is not starting or you encounter errors, ensure that:

The .NET SDK and Docker are correctly installed.
All dependencies in the csproj file are correctly referenced.
Issue: Swagger UI Not Accessible
Ensure that the Docker container is running and accessible on the specified port. Check your Docker logs for any errors during startup.

License
This project is licensed under the MIT License.