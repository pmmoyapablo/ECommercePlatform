#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ECommerce.Api.ProductCatalog/ECommerce.Api.ProductCatalog.csproj", "ECommerce.Api.ProductCatalog/"]
RUN dotnet restore "ECommerce.Api.ProductCatalog/ECommerce.Api.ProductCatalog.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api.ProductCatalog"
RUN dotnet build "ECommerce.Api.ProductCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.ProductCatalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.ProductCatalog.dll"]
