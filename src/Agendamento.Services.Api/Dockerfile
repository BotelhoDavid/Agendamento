FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Agendamento.Services.Api/Agendamento.Services.Api.csproj", "Agendamento.Services.Api/"]
COPY ["Agendamento.Application/Agendamento.Application.csproj", "Agendamento.Application/"]
COPY ["Agendamento.Domain/Agendamento.Domain.csproj", "Agendamento.Domain/"]
COPY ["Agendamento.Infra.CrossCutting.ExceptionHandler/Agendamento.Infra.CrossCutting.ExceptionHandler.csproj", "Agendamento.Infra.CrossCutting.ExceptionHandler/"]
COPY ["Agendamento.Domain.Core/Agendamento.Domain.Core.csproj", "Agendamento.Domain.Core/"]
COPY ["Agendamento.Infrastructure/Agendamento.Infrastructure.csproj", "Agendamento.Infrastructure/"]
COPY ["Agendamento.Infra.CrossCutting.Dapper/Agendamento.Infra.CrossCutting.Dapper.csproj", "Agendamento.Infra.CrossCutting.Dapper/"]
COPY ["Agendamento.Infra.CrossCutting.Chain/Agendamento.Infra.CrossCutting.Chain.csproj", "Agendamento.Infra.CrossCutting.Chain/"]
COPY ["Agendamento.Infra.CrossCutting.IoC/Agendamento.Infra.CrossCutting.IoC.csproj", "Agendamento.Infra.CrossCutting.IoC/"]
COPY ["Agendamento.Infra.CrossCutting.Swagger/Agendamento.Infra.CrossCutting.Swagger.csproj", "Agendamento.Infra.CrossCutting.Swagger/"]

RUN dotnet restore "Agendamento.Services.Api/Agendamento.Services.Api.csproj"

COPY . .

WORKDIR "/src/Agendamento.Services.Api"
RUN dotnet build "Agendamento.Services.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Agendamento.Services.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agendamento.Services.Api.dll"]
