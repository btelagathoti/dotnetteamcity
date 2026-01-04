# 1. Base image (ASP.NET runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 2. Copy published output
COPY out/ ./

# 3. Expose port
EXPOSE 5000

# 4. Run the app
ENTRYPOINT ["dotnet", "TodoApp.dll"]
