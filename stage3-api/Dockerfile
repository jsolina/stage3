FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0
WORKDIR /app
COPY . .

RUN dotnet build -c Release

ENTRYPOINT ["dotnet", "run", "--no-launch-profile" ]