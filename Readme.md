# School API

This project is a demo training for Protoss Technology for newcomers.
This project is base on .NET 6

### Build Project
```shell
$ dotnet build
```

### Start Project at local
```shell
$ dotnet run
```

### Publish Project
```shell
$ dotnet publish -c Release
```
Build file will be in bin/Release/net6.0/

### Start with Container
```shell
$ docker build -t school-api .
$ docker run -p 8000:8000 --name school-api -d school-api:latest
```