
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["IIS/IIS.csproj", "IIS/"]
COPY ["IIS.Application/IIS.Application.csproj", "IIS.Application/"]
COPY ["IIS.Domain/IIS.Domain.csproj", "IIS.Domain/"]
COPY ["IIS.Infrastructure/IIS.Infrastructure.csproj", "IIS.Infrastructure/"]
RUN dotnet restore "IIS/IIS.csproj"

COPY . .
WORKDIR "/src/IIS"
RUN dotnet publish "IIS.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IIS.dll"]