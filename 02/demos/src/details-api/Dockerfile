FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100 AS builder

WORKDIR /src
COPY BookInfo.Details.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /out BookInfo.Details.csproj

# app image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

ENV ASPNETCORE_URLS=http://+:9080
EXPOSE 9080

WORKDIR /app
ENTRYPOINT ["dotnet", "BookInfo.Details.dll"]

COPY --from=builder /out/ .