#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/LearningDiary.WebUI/LearningDiary.WebUI.csproj", "src/LearningDiary.WebUI/"]
RUN dotnet restore "src/LearningDiary.WebUI/LearningDiary.WebUI.csproj"
COPY . .
WORKDIR "/src/src/LearningDiary.WebUI"
RUN dotnet build "LearningDiary.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningDiary.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningDiary.WebUI.dll"]