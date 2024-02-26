FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GrpcPractice2Client/GrpcPractice2Client.csproj", "GrpcPractice2Client/"]
RUN dotnet restore "GrpcPractice2Client/GrpcPractice2Client.csproj"
COPY . .
WORKDIR "/src/GrpcPractice2Client"
RUN dotnet build "GrpcPractice2Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcPractice2Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcPractice2Client.dll"]
