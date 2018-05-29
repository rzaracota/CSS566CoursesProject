FROM microsoft/aspnetcore-build:latest AS build-env
WORKDIR /frontend

COPY /smcw/*.csproj ./
RUN dotnet restore

COPY . ./

RUN cd "Software Management Course Website" && dotnet publish -c Release -o ../out

FROM microsoft/aspnetcore:latest
WORKDIR /frontend
COPY --from=build-env /frontend/out out/

ENTRYPOINT ["dotnet", "SoftwareManagementCourseWebsite.dll"]
