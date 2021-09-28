FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BlogAsp/BlogAsp.csproj", "BlogAsp/"]
RUN dotnet restore "BlogAsp/BlogAsp.csproj"
COPY . .
WORKDIR "/src/BlogAsp"
RUN dotnet build "BlogAsp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogAsp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogAsp.dll"]
