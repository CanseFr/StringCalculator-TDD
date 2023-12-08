FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StringCalculator/StringCalculator.csproj", "StringCalculator/"]
RUN dotnet restore "StringCalculator/StringCalculator.csproj"
COPY . .
WORKDIR "/src/StringCalculator"
RUN dotnet build "StringCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StringCalculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StringCalculator.dll"]
