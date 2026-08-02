using Soenneker.Telnyx.Messaging.Abstract;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Telnyx.ClientUtil.Abstract;
using Soenneker.Telnyx.OpenApiClient;
using Soenneker.Telnyx.OpenApiClient.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Telnyx.Messaging;

/// <inheritdoc cref="ITelnyxMessagingUtil"/>
public sealed class TelnyxMessagingUtil : ITelnyxMessagingUtil
{
    private readonly ITelnyxClientUtil _telnyxClientUtil;
    private readonly ILogger<TelnyxMessagingUtil> _logger;

    public TelnyxMessagingUtil(ITelnyxClientUtil telnyxClientUtil, ILogger<TelnyxMessagingUtil> logger)
    {
        _telnyxClientUtil = telnyxClientUtil;
        _logger = logger;
    }

    public async ValueTask<OutboundMessagePayload?> Send(string from, string to, string text, string messagingProfileId, string? webhookUrl = null,
        Dictionary<string, string>? webhookHeaders = null, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Sending message from {From} to {To}", from, to);

            TelnyxOpenApiClient client = await _telnyxClientUtil.Get(cancellationToken).NoSync();

            var request = new CreateMessageRequest
            {
                From = from,
                To = to,
                Text = text,
                MessagingProfileId = messagingProfileId,
                WebhookUrl = webhookUrl
            };

            SendMessage200Response? response = await client.Messages.PostAsync(request, cancellationToken: cancellationToken).NoSync();

            _logger.LogInformation("Successfully sent message from {From} to {To}", from, to);
            return response?.Data;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error sending message from {From} to {To}", from, to);
            return null;
        }
    }

    public async ValueTask<OutboundMessagePayload?> SendMms(string from, string to, string text, List<string> mediaUrls, string messagingProfileId,
        string? webhookUrl = null, Dictionary<string, string>? webhookHeaders = null, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Sending MMS message from {From} to {To}", from, to);

            TelnyxOpenApiClient client = await _telnyxClientUtil.Get(cancellationToken).NoSync();

            var request = new CreateMessageRequest
            {
                From = from,
                To = to,
                Text = text,
                MediaUrls = mediaUrls,
                MessagingProfileId = messagingProfileId,
                WebhookUrl = webhookUrl
            };

            SendMessage200Response? response = await client.Messages.PostAsync(request, cancellationToken: cancellationToken).NoSync();

            _logger.LogInformation("Successfully sent MMS message from {From} to {To}", from, to);
            return response?.Data;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error sending MMS message from {From} to {To}", from, to);
            return null;
        }
    }

    public async ValueTask<GetMessage200Response?> Get(string messageId, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Getting message {MessageId}", messageId);

            TelnyxOpenApiClient client = await _telnyxClientUtil.Get(cancellationToken).NoSync();

            GetMessage200Response? response = await client.Messages[Guid.Parse(messageId)].GetAsync(cancellationToken: cancellationToken).NoSync();

            _logger.LogInformation("Successfully retrieved message {MessageId}", messageId);
            return response;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error getting message {MessageId}", messageId);
            return null;
        }
    }
}
