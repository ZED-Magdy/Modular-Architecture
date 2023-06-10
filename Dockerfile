# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY src/ConnectionPoint.Gateway/ConnectionPoint.Gateway.csproj ./ConnectionPoint.Gateway/
COPY src/Core/ConnectionPoint.Core.Application/ConnectionPoint.Core.Application.csproj ./Core/ConnectionPoint.Core.Application/
COPY src/Core/ConnectionPoint.Core.Domain/ConnectionPoint.Core.Domain.csproj ./Core/ConnectionPoint.Core.Domain/
COPY src/Core/ConnectionPoint.Core.Infrastructure/ConnectionPoint.Core.Infrastructure.csproj ./Core/ConnectionPoint.Core.Infrastructure/
COPY src/Inventory/ConnectionPoint.Inventory.Application/ConnectionPoint.Inventory.Application.csproj ./Inventory/ConnectionPoint.Inventory.Application/
COPY src/Inventory/ConnectionPoint.Inventory.Domain/ConnectionPoint.Inventory.Domain.csproj ./Inventory/ConnectionPoint.Inventory.Domain/
COPY src/Inventory/ConnectionPoint.Inventory.Infrastructure/ConnectionPoint.Inventory.Infrastructure.csproj ./Inventory/ConnectionPoint.Inventory.Infrastructure/
#COPY src/ConnectionPoint.Gateway/NuGet.Config ./ConnectionPoint.Gateway/   # If you have a custom NuGet.Config file

WORKDIR /app/ConnectionPoint.Gateway
RUN dotnet restore

# Copy the project files and build the application
COPY src/ConnectionPoint.Gateway/. ./ 
COPY src/Core/. ../Core/
COPY src/Inventory/. ../Inventory/
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/ConnectionPoint.Gateway/out ./
ENTRYPOINT ["dotnet", "ConnectionPoint.Gateway.dll"]