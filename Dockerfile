FROM microsoft/aspnetcore-build:latest AS build-env
WORKDIR /frontend

COPY /smcw/*.csproj ./
RUN dotnet restore

COPY . ./

RUN cd smcw && dotnet publish -c Release -o ../out

FROM microsoft/aspnetcore:latest
WORKDIR /frontend
COPY --from=build-env /frontend/out out/

ENTRYPOINT ["dotnet", "Software Management Course Website.dll"]
