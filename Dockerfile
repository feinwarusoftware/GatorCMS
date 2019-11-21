FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["GatorCMS.Core/GatorCMS.Core.csproj", "GatorCMS.Core/"]
RUN dotnet restore "GatorCMS.Core/GatorCMS.Core.csproj"
COPY . .
WORKDIR /src/GatorCMS.Core
RUN dotnet build "GatorCMS.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GatorCMS.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GatorCMS.Core.dll"]
