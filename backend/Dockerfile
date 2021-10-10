FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.14 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish src/Lern.Api -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine3.14

WORKDIR /app

COPY --from=build /app .

EXPOSE 80
EXPOSE 433

ENTRYPOINT [ "dotnet", "Lern.Api.dll" ]