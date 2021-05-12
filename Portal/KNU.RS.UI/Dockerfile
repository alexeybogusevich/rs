#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Portal/KNU.RS.UI/KNU.RS.UI.csproj", "Portal/KNU.RS.UI/"]
COPY ["Portal/KNU.RS.Logic/KNU.RS.Logic.csproj", "Portal/KNU.RS.Logic/"]
COPY ["Shared/KNU.RS.Data/KNU.RS.Data.csproj", "Shared/KNU.RS.Data/"]
COPY ["Shared/KNU.RS.PlatformExtensions/KNU.RS.PlatformExtensions.csproj", "Shared/KNU.RS.PlatformExtensions/"]
RUN dotnet restore "Portal/KNU.RS.UI/KNU.RS.UI.csproj"
COPY . .
WORKDIR "/src/Portal/KNU.RS.UI"
RUN dotnet build "KNU.RS.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KNU.RS.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KNU.RS.UI.dll"]