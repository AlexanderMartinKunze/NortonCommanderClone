FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hamming/Hamming.csproj", "Hamming/"]
RUN dotnet restore "Hamming/Hamming.csproj"
COPY . .
WORKDIR "/src/Hamming"
RUN dotnet build "Hamming.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hamming.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hamming.dll"]
