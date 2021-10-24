# LERN

Aplikacja, która wpomaga naukę języków obcych poprzez szybsze dodawanie słówek, sprawdzenia wymowy, łatwego udostępniania w grupie zestawów.

### Jak uruchomić aplikację

* .NET >= 5.0
* NodeJS >= 14.X

backend:
```bash
$ cd backend
$ dotnet ef database update --project src/Lern.Infrastructure
$ dotnet build -c Release
$ dotnet run src/Lern.Api/bin/Release/Lern.Api.dll
```

frontend:
```bash
$ cd app
$ yarn start
```