FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore ./ManageGameApi/ManageGameApi.csproj
RUN dotnet publish ./ManageGameApi/ManageGameApi.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out .
CMD dotnet ManageGameApi.dll