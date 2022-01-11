#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/JvA.Library.Api/JvA.Library.Api.csproj", "src/JvA.Library.Api/"]
COPY ["src/JvA.Library.Repository/JvA.Library.Persistence.csproj", "src/JvA.Library.Repository/"]
COPY ["src/JvA.Library.Core/JvA.Library.Application.csproj", "src/JvA.Library.Core/"]
COPY ["src/JvA.Library.Domain/JvA.Library.Domain.csproj", "src/JvA.Library.Domain/"]
RUN dotnet restore "src/JvA.Library.Api/JvA.Library.Api.csproj"
COPY . .
WORKDIR "/src/src/JvA.Library.Api"
RUN dotnet build "JvA.Library.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JvA.Library.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JvA.Library.Api.dll"]