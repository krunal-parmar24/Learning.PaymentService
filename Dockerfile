# STAGE 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ./Learning.PaymentService.slnx ./

# Copy the rest of the source
COPY . .

# Restore dependencies
RUN dotnet restore Learning.PaymentService.API/Learning.PaymentService.API.csproj

# Build and publish
WORKDIR /src/Learning.PaymentService.API
RUN dotnet publish -c Release -o /app/publish

# STAGE 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Set ASP.NET Core to listen on port 8082
ENV ASPNETCORE_URLS=http://+:8082

# Set environment to Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Copy published output
COPY --from=build /app/publish .

# Expose port 8082
EXPOSE 8082

# Run the API
ENTRYPOINT ["dotnet", "Learning.PaymentService.API.dll"]