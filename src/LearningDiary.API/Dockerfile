#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/LearningDiary.API/LearningDiary.API.csproj", "src/LearningDiary.API/"]
RUN dotnet restore "src/LearningDiary.API/LearningDiary.API.csproj"
COPY . .
WORKDIR "/src/src/LearningDiary.API"
RUN dotnet build "LearningDiary.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningDiary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningDiary.API.dll"]