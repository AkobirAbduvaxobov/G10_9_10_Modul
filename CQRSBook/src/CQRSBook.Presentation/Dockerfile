# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all projects
COPY ["CQRSBook.Presentation/CQRSBook.Presentation.csproj", "CQRSBook.Presentation/"]
COPY ["CQRSBook.Application/CQRSBook.Application.csproj", "CQRSBook.Application/"]
COPY ["CQRSBook.Infrastructure/CQRSBook.Infrastructure.csproj", "CQRSBook.Infrastructure/"]
COPY ["CQRSBook.Domain/CQRSBook.Domain.csproj", "CQRSBook.Domain/"]

# Restore dependencies
RUN dotnet restore "CQRSBook.Presentation/CQRSBook.Presentation.csproj"

# Copy everything and build
COPY . .
WORKDIR "/src/CQRSBook.Presentation"
RUN dotnet publish "CQRSBook.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CQRSBook.Presentation.dll"]