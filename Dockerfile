FROM mcr.microsoft.com/dotnet/sdk:6.0.302-alpine3.15-amd64 as builder
USER root

RUN ["mkdir", "-p", "/opt/dotnetcore"]

WORKDIR /opt/dotnetcore

ADD . .

RUN ["rm", "global.json"]

RUN ["dotnet", "publish", "-c", "Release"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0.7-alpine3.15-amd64

# Add dotnet core env for enable swagger 
ENV ASPNETCORE_ENVIRONMENT=Development

USER root

# RUN apt-get update && apt-get upgrade
# RUN apt install -y curl
# RUN apt install -y lsof

RUN ["mkdir", "-p", "/opt/app-root/publish"]

WORKDIR /opt/app-root/publish

EXPOSE 8000

COPY --from=builder /opt/dotnetcore/bin/Release/net6.0/publish .
ENTRYPOINT ["dotnet", "SchoolAPI.dll"]