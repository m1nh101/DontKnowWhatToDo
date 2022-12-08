#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/MVCNew/MVCNew.csproj", "src/MVCNew/"]
RUN dotnet restore "src/MVCNew/MVCNew.csproj"
COPY . .
WORKDIR "/src/src/MVCNew"
RUN dotnet build "MVCNew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVCNew.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCNew.dll"]