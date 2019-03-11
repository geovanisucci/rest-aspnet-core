FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Sample.BasicRestAspnetCore.Host/Sample.BasicRestAspnetCore.Host.csproj", "Sample.BasicRestAspnetCore.Host/"]
RUN dotnet restore "Sample.BasicRestAspnetCore.Host/Sample.BasicRestAspnetCore.Host.csproj"
COPY ./src .
WORKDIR "/src/Sample.BasicRestAspnetCore.Host"
RUN dotnet build "Sample.BasicRestAspnetCore.Host.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sample.BasicRestAspnetCore.Host.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sample.BasicRestAspnetCore.Host.dll"]



