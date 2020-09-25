#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Atez.Personal.Api/Atez.Personal.Api.csproj Atez.Personal.Api/
COPY Atez.Personal.Service/Atez.Personal.Service.csproj Atez.Personal.Service/
COPY Atez.Personal.Data/Atez.Personal.Data.csproj Atez.Personal.Data/
RUN dotnet restore "Atez.Personal.Api/Atez.Personal.Api.csproj"
COPY . .
WORKDIR "/src/Atez.Personal.Api"
RUN dotnet build "Atez.Personal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atez.Personal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atez.Personal.Api.dll"]
