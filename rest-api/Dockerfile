# Use the official image as a parent image for .NET Core 3.1
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
# Expose port 5000
EXPOSE 5000

# Use environment variable to set ASP.NET Core to listen on port 5000
ENV ASPNETCORE_URLS=http://+:5000

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
# Assuming the .csproj file is in the root of your project, change the COPY path
COPY ["./rest-api.csproj", "./"]
RUN dotnet restore "rest-api.csproj"
# Copying from the current directory
COPY . .
WORKDIR "/src"
# Make sure to use your actual project name in the following lines
RUN dotnet build "rest-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rest-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rest-api.dll"]
