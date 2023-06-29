#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Authentication.Services.Api/Authentication.Services.Api.csproj", "Authentication.Services.Api/"]
RUN dotnet restore "Authentication.Services.Api/Authentication.Services.Api.csproj"
COPY . .
WORKDIR "/src/Authentication.Services.Api"
RUN dotnet build "Authentication.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.Services.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.Services.Api.dll"]