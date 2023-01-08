FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/3-Clients/Dashboard/Dashboard.csproj", "src/3-Clients/Dashboard/"]
COPY ["src/1-BuildingBlocks/Contracts/Contracts.csproj", "src/1-BuildingBlocks/Contracts/"]

RUN dotnet restore "src/3-Clients/Dashboard/Dashboard.csproj"
COPY . .
RUN dotnet build "src/3-Clients/Dashboard/Dashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/3-Clients/Dashboard/Dashboard.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
EXPOSE 80
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY src/3-Clients/Dashboard/nginx.conf /etc/nginx/nginx.conf