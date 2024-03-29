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

COPY src/Taxing/ConnectionPoint.Taxing.Application/ConnectionPoint.Taxing.Application.csproj ./Taxing/ConnectionPoint.Taxing.Application/
COPY src/Taxing/ConnectionPoint.Taxing.Domain/ConnectionPoint.Taxing.Domain.csproj ./Taxing/ConnectionPoint.Taxing.Domain/
COPY src/Taxing/ConnectionPoint.Taxing.Infrastructure/ConnectionPoint.Taxing.Infrastructure.csproj ./Taxing/ConnectionPoint.Taxing.Infrastructure/

COPY src/Voucher/ConnectionPoint.Voucher.Application/ConnectionPoint.Voucher.Application.csproj ./Voucher/ConnectionPoint.Voucher.Application/
COPY src/Voucher/ConnectionPoint.Voucher.Domain/ConnectionPoint.Voucher.Domain.csproj ./Voucher/ConnectionPoint.Voucher.Domain/
COPY src/Voucher/ConnectionPoint.Voucher.Infrastructure/ConnectionPoint.Voucher.Infrastructure.csproj ./Voucher/ConnectionPoint.Voucher.Infrastructure/

#COPY src/ConnectionPoint.Gateway/NuGet.Config ./ConnectionPoint.Gateway/   # If you have a custom NuGet.Config file

WORKDIR /app/ConnectionPoint.Gateway
RUN dotnet restore

# Copy the project files and build the application
COPY src/ConnectionPoint.Gateway/. ./ 
COPY src/Core/. ../Core/
COPY src/Inventory/. ../Inventory/
COPY src/Taxing/. ../Taxing/
COPY src/Voucher/. ../Voucher/

RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/ConnectionPoint.Gateway/out ./
ENTRYPOINT ["dotnet", "ConnectionPoint.Gateway.dll"]