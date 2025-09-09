# Use the official .NET 8 SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["BookConsumer.Api.csproj", "./"]
RUN dotnet restore "BookConsumer.Api.csproj"

# Copy the rest of the source code
COPY . .

# Build and publish the app in release mode
RUN dotnet publish "BookConsumer.Api.csproj" -c Release -o /app/publish

# Use ASP.NET runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose port (the same port as your app runs on in launchSettings.json, usually 5000/5001)
EXPOSE 8080
EXPOSE 8081

# Start the application
ENTRYPOINT ["dotnet", "BookConsumer.Api.dll"]
