FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WebApi 3.0/WebApi 3.0.csproj", "WebApi 3.0/"]
RUN dotnet restore "WebApi 3.0/WebApi 3.0.csproj"
COPY . .
WORKDIR "/src/WebApi 3.0"
RUN dotnet build "WebApi 3.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi 3.0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi 3.0.dll"]