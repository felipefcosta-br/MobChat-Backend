FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MobChat.Microservices.IamMicroservice.Admin/MobChat.Microservices.IamMicroservice.Admin.csproj", "src/MobChat.Microservices.IamMicroservice.Admin/"]
COPY ["src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.Shared/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/MobChat.Microservices.IamMicroservice.Shared/MobChat.Microservices.IamMicroservice.Shared.csproj", "src/MobChat.Microservices.IamMicroservice.Shared/"]
COPY ["src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.MySql/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/MobChat.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/MobChat.Microservices.IamMicroservice.Admin/MobChat.Microservices.IamMicroservice.Admin.csproj"
COPY . .
WORKDIR "/src/src/MobChat.Microservices.IamMicroservice.Admin"
RUN dotnet build "MobChat.Microservices.IamMicroservice.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobChat.Microservices.IamMicroservice.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "MobChat.Microservices.IamMicroservice.Admin.dll"]