FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["grpcPractice2JwtClient/grpcPractice2JwtClient.csproj", "grpcPractice2JwtClient/"]
RUN dotnet restore "grpcPractice2JwtClient/grpcPractice2JwtClient.csproj"
COPY . .
WORKDIR "/src/grpcPractice2JwtClient"
RUN dotnet build "grpcPractice2JwtClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "grpcPractice2JwtClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "grpcPractice2JwtClient.dll"]
