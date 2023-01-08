#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/2-Services/Consumptions.Client/Api/Consumptions.Client.Api/Consumptions.Client.Api.csproj", "src/2-Services/Consumptions.Client/Api/Consumptions.Client.Api/"]
RUN dotnet restore "src/2-Services/Consumptions.Client/Api/Consumptions.Client.Api/Consumptions.Client.Api.csproj"
COPY . .
WORKDIR "/src/src/2-Services/Consumptions.Client/Api/Consumptions.Client.Api"
RUN dotnet build "Consumptions.Client.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consumptions.Client.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumptions.Client.Api.dll"]