FROM microsoft/aspnetcore-build:2.0 AS builder
WORKDIR /source

COPY tests/NOTranscoder.TestServer/NOTranscoder.TestServer.csproj ./tests/NOTranscoder.TestServer/
RUN dotnet restore tests/NOTranscoder.TestServer/NOTranscoder.TestServer.csproj

COPY ./tests/NOTranscoder.TestServer ./tests/NOTranscoder.TestServer
RUN dotnet publish --output /app/ --configuration=Debug tests/NOTranscoder.TestServer/NOTranscoder.TestServer.csproj

FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=builder /app .
RUN mkdir assets
COPY tests/NOTranscoder.TestServer/assets/test01.flac ./assets/test01.flac
ENTRYPOINT ["dotnet", "NOTranscoder.TestServer.dll"]
