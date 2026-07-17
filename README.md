[![](https://img.shields.io/nuget/v/soenneker.telnyx.messaging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.telnyx.messaging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.telnyx.messaging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.telnyx.messaging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.telnyx.messaging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.telnyx.messaging/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Telnyx.Messaging
### A resilient .NET utility for Telnyx Messaging.

## Installation

```
dotnet add package Soenneker.Telnyx.Messaging
```

## Registration

```csharp
using Soenneker.Telnyx.Messaging.Registrars;

services.AddTelnyxMessagingUtilAsScoped();
```

The registrar also adds the Telnyx client utility. Configure it with your Telnyx token:

```json
{
  "Telnyx": {
    "Token": "your-api-token"
  }
}
```

Inject `ITelnyxMessagingUtil` to send SMS or MMS messages and retrieve a message by ID.
