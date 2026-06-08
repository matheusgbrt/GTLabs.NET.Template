# GTLabs.NET.Template

Base template for GT Labs services.

## Configuration

Application configuration is loaded from Consul after `RegisterApp` sets the service `AppId`.

Keep `appsettings.json` and `appsettings.Development.json` limited to values that are required before Consul can be reached. Shared and service-specific runtime configuration belongs in Consul K/V.

Shared configuration is loaded from:

```text
General/*
```

Service-specific configuration is loaded from:

```text
<AppId>/*
```

Example service-specific K/V payload for `<AppId>/base`:

```json
{
  "RoutePrefix": "urlprefix-/my-service",
  "ServiceToken": "replace-with-service-token",
  "ConnectionStrings": {
    "DefaultConnection": "Host=postgres;Port=5432;Database=my_service;Username=gtlabs;Password=replace-with-password"
  }
}
```

Only `URL-CONSUL`, `SERVICE_ADVERTISE_HOST`, and `SERVICE_ADVERTISE_PORT` are expected as local launch environment values.
