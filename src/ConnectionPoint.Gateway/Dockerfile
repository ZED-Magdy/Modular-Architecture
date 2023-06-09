FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ConnectionPoint.Gateway/ConnectionPoint.Gateway.csproj", "ConnectionPoint.Gateway/"]
RUN dotnet restore "ConnectionPoint.Gateway/ConnectionPoint.Gateway.csproj"
COPY . .
WORKDIR "/src/ConnectionPoint.Gateway"
RUN dotnet build "ConnectionPoint.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConnectionPoint.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConnectionPoint.Gateway.dll"]
