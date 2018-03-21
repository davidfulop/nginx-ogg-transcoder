FROM microsoft/aspnetcore-build
WORKDIR /source

COPY tests/NOTranscoder.SmokeTests/NOTranscoder.SmokeTests.csproj ./tests/NOTranscoder.SmokeTests/
RUN dotnet restore tests/NOTranscoder.SmokeTests/NOTranscoder.SmokeTests.csproj

COPY ./tests/NOTranscoder.SmokeTests ./tests/NOTranscoder.SmokeTests

RUN dotnet build tests/NOTranscoder.SmokeTests/NOTranscoder.SmokeTests.csproj

ENTRYPOINT ["dotnet", "test", "tests/NOTranscoder.SmokeTests/NOTranscoder.SmokeTests.csproj", "--no-build"]
