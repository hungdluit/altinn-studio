FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine AS build
WORKDIR Authorization/

COPY Authorization ./Authorization
WORKDIR Authorization/

RUN dotnet build Altinn.Platform.Authorization.csproj -c Release -o /app_output
RUN dotnet publish Altinn.Platform.Authorization.csproj -c Release -o /app_output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine AS final
EXPOSE 5030
WORKDIR /app
COPY --from=build /app_output .

# setup the user and group
# the user will have no password, using shell /bin/false and using the group dotnet
RUN addgroup -g 3000 dotnet && adduser -u 1000 -G dotnet -D -s /bin/false dotnet
# update permissions of files if neccessary before becoming dotnet user
USER dotnet
RUN mkdir /tmp/logtelemetry

ENTRYPOINT ["dotnet", "Altinn.Platform.Authorization.dll"]
