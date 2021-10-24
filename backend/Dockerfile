FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.14 AS build

ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Production"

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish src/Lern.Api -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine3.14

WORKDIR /app

COPY --from=build /app .

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Lern.Api.dll" ]