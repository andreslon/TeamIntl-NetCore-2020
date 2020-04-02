FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["lab1/lab1.csproj", "lab1/"]
RUN dotnet restore "lab1/lab1.csproj"
COPY . .
WORKDIR "/src/lab1"
RUN dotnet build "lab1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab1.dll"]
