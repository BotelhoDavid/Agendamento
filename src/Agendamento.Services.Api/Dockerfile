# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Agendamento.Services.Api/Agendamento.Services.Api.csproj", "src/Agendamento.Services.Api/"]
COPY ["src/Agendamento.Application/Agendamento.Application.csproj", "src/Agendamento.Application/"]
COPY ["src/Agendamento.Domain/Agendamento.Domain.csproj", "src/Agendamento.Domain/"]
COPY ["src/Agendamento.Infra.CrossCutting.ExceptionHandler/Agendamento.Infra.CrossCutting.ExceptionHandler.csproj", "src/Agendamento.Infra.CrossCutting.ExceptionHandler/"]
COPY ["src/Agendamento.Domain.Core/Agendamento.Domain.Core.csproj", "src/Agendamento.Domain.Core/"]
COPY ["src/Agendamento.Infra.CrossCutting.Chain/Agendamento.Infra.CrossCutting.Chain.csproj", "src/Agendamento.Infra.CrossCutting.Chain/"]
COPY ["src/Agendamento.Infra.CrossCutting.Swagger/Agendamento.Infra.CrossCutting.Swagger.csproj", "src/Agendamento.Infra.CrossCutting.Swagger/"]
RUN dotnet restore "./src/Agendamento.Services.Api/Agendamento.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/Agendamento.Services.Api"
RUN dotnet build "./Agendamento.Services.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Agendamento.Services.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agendamento.Services.Api.dll"]