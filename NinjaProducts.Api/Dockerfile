#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NinjaProducts.Api/NinjaProducts.Api.csproj", "NinjaProducts.Api/"]
COPY ["NinjaProducts.Application/NinjaProducts.Application.csproj", "NinjaProducts.Application/"]
COPY ["NinjaProducts.Domain/NinjaProducts.Domain.csproj", "NinjaProducts.Domain/"]
RUN dotnet restore "NinjaProducts.Api/NinjaProducts.Api.csproj"
COPY . .
WORKDIR "/src/NinjaProducts.Api"
RUN dotnet build "NinjaProducts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NinjaProducts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NinjaProducts.Api.dll"]