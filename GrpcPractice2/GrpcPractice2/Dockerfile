﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GrpcPractice2/GrpcPractice2.csproj", "GrpcPractice2/"]
RUN dotnet restore "GrpcPractice2/GrpcPractice2.csproj"
COPY . .
WORKDIR "/src/GrpcPractice2"
RUN dotnet build "GrpcPractice2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcPractice2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcPractice2.dll"]
