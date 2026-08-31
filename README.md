[![](https://img.shields.io/nuget/v/soenneker.telnyx.messaging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.telnyx.messaging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.telnyx.messaging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.telnyx.messaging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.telnyx.messaging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.telnyx.messaging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.telnyx.messaging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.telnyx.messaging/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Telnyx.Messaging

Send SMS and MMS messages through Telnyx and retrieve previously created messages by ID.

## Installation

```bash
dotnet add package Soenneker.Telnyx.Messaging
```

## Configuration

```json
{
  "Telnyx": {
    "Token": "KEY..."
  }
}
```

## Usage

```csharp
using Soenneker.Telnyx.Messaging.Abstract;
using Soenneker.Telnyx.Messaging.Registrars;
using Soenneker.Telnyx.OpenApiClient.Models;

services.AddTelnyxMessagingUtilAsScoped();

MessagingOutboundMessagePayload? sent = await telnyxMessaging.Send(
    from: "+15557654321",
    to: "+15551234567",
    text: "Your verification code is 123456",
    messagingProfileId: "40017f2e-...",
    webhookUrl: "https://example.com/webhooks/telnyx",
    cancellationToken: cancellationToken);

MessagingOutboundMessagePayload? mms = await telnyxMessaging.SendMms(
    from: "+15557654321",
    to: "+15551234567",
    text: "See attached",
    mediaUrls: ["https://example.com/image.jpg"],
    messagingProfileId: "40017f2e-...",
    cancellationToken: cancellationToken);
```

Phone numbers should use E.164 format, and MMS media URLs must be reachable by Telnyx. `Send` and `SendMms` create billable outbound messages.

Telnyx/API failures are logged and returned as `null`; cancellation still propagates as `OperationCanceledException`. The optional webhook URL selects the message-status callback endpoint. Custom webhook headers are not supported by Telnyx's generated create-message request.
