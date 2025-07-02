# Use the .NET 8 SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY . ./

# Restore dependencies
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Run the app
ENTRYPOINT ["dotnet", "BakasuraAddaFoodStreet.dll"]
