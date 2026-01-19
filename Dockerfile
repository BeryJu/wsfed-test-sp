FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG TARGETARCH
WORKDIR /source

# Copy project file and restore as distinct layers
COPY --link *.csproj .
RUN dotnet restore -a $TARGETARCH

# Copy source code and publish app
COPY --link . .
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
RUN apt-get update && \
    apt-get install -y --no-install-recommends curl && \
    apt-get clean
WORKDIR /app
COPY --link --from=build /app .
USER $APP_UID
HEALTHCHECK --interval=5s --start-period=1s CMD curl --fail http://localhost:8080/healthz || exit 1
ENTRYPOINT ["./WsfedTestSP"]
