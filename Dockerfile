FROM microsoft/aspnetcore-build:latest AS build-env
WORKDIR /frontend

COPY *.csproj ./
RUN dotnet restore

COPY "/Software Management Course Website/*.csproj" ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore:latest
WORKDIR /frontend
COPY --from=build-env /frontend/out

ENTRYPOINT ["dotnet", "Software Management Course Website.dll"]
