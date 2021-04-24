#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
#COPY ["SpacePark/SpacePark.csproj", "SpacePark/"]
COPY ["SpacePark.csproj", "./"]
#RUN dotnet restore "SpacePark/SpacePark.csproj"
RUN dotnet restore "SpacePark.csproj"
COPY . .
#WORKDIR "/src/SpacePark"
WORKDIR "/src/."
RUN dotnet build "SpacePark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpacePark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
