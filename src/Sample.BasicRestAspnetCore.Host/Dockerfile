FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 4947
EXPOSE 44313

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY /src/Sample.BasicRestAspnetCore.Host/Sample.BasicRestAspnetCore.Host.csproj Sample.BasicRestAspnetCore.Host/
COPY /src/Sample.BasicRestAspnetCore.Data/Sample.BasicRestAspnetCore.Data.csproj Sample.BasicRestAspnetCore.Data/
COPY /src/Sample.BasicRestAspnetCore.DatabaseMigration/Sample.BasicRestAspnetCore.DatabaseMigration.csproj Sample.BasicRestAspnetCore.DatabaseMigration/
COPY /src/Sample.BasicRestAspnetCore.EntitiesDomain/Sample.BasicRestAspnetCore.EntitiesDomain.csproj Sample.BasicRestAspnetCore.EntitiesDomain/
COPY /src/Sample.BasicRestAspnetCore.Business/Sample.BasicRestAspnetCore.Business.csproj Sample.BasicRestAspnetCore.Business/
COPY /src/Sample.BasicRestAspnetCore.Authentication/Sample.BasicRestAspnetCore.Authentication.csproj Sample.BasicRestAspnetCore.Authentication/
RUN dotnet restore /src/Sample.BasicRestAspnetCore.Host/Sample.BasicRestAspnetCore.Host.csproj
COPY . .
WORKDIR /src/Sample.BasicRestAspnetCore.Host
RUN dotnet build Sample.BasicRestAspnetCore.Host.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Sample.BasicRestAspnetCore.Host.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sample.BasicRestAspnetCore.Host.dll"]
