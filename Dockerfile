FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "FinanceiroApi/FinanceiroApi.csproj"

WORKDIR "/src/FinanceiroApi"
RUN dotnet build "FinanceiroApi.csproj" -c Release -o /app/build
RUN dotnet publish "FinanceiroApi.csproj" -c Release -o /app/publish

FROM base AS final
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add tzdata
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FinanceiroApi.dll"]
