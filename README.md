# wsfed-test-sp

![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/beryju/wsfed-test-sp/ci-build.yml?branch=main&style=for-the-badge)

A small application for testing WS-Federation identity providers. WS Fed is implemented using `Microsoft.AspNetCore.Authentication.WsFederation`.

## Configuration

- `WSFED_TEST_SP_METADATA`: URL to fetch the metadata from. HTTP and HTTPS URLs are accepted.
- `WSFED_TEST_SP_WTREALM`: Value for `wtrealm`

## Running

This service is intended to run in a docker container

```
docker pull ghcr.io/beryju/wsfed-test-sp
docker run -d --rm \
    -p 8080:8080 \
    -e WSFED_TEST_SP_WTREALM=wsfed-test-sp \
    -e WSFED_TEST_SP_METADATA=https://... \
    ghcr.io/beryju/wsfed-test-sp
```

Or if you want to use docker-compose, use this in your `docker-compose.yaml`.

```yaml
version: '3.5'

services:
  wsfed-test-sp:
    image: ghcr.io/beryju/wsfed-test-sp
    ports:
      - 8080:8080
    environment:
      WSFED_TEST_SP_METADATA: http://some.site.tld/saml/metadata
      WSFED_TEST_SP_WTREALM: wsfed-test-sp
```
