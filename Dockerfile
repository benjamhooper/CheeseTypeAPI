FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CheeseTypeAPI.csproj", ""]
RUN dotnet restore "./CheeseTypeAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CheeseTypeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheeseTypeAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheeseTypeAPI.dll"]