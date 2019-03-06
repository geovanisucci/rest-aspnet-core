FROM microsoft/dotnet:2.2-sdk AS builder
WORKDIR /source
COPY ./src .
RUN dotnet restore
RUN dotnet publish ./Sample.BasicRestAspnetCore.Host --output /app/

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine3.8
WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Sample.BasicRestAspnetCore.Host.dll"]