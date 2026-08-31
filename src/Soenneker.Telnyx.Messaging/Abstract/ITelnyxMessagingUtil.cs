using Soenneker.Telnyx.OpenApiClient.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Telnyx.Messaging.Abstract;

/// <summary>
/// Sends Telnyx SMS and MMS messages and retrieves messages by ID.
/// </summary>
public interface ITelnyxMessagingUtil
{
    /// <summary>
    /// Sends an outbound SMS message using Telnyx.
    /// </summary>
    /// <param name="from">The sender's phone number in E.164 format.</param>
    /// <param name="to">The recipient's phone number in E.164 format.</param>
    /// <param name="text">The body of the SMS message.</param>
    /// <param name="messagingProfileId">The messaging profile ID to use for sending.</param>
    /// <param name="webhookUrl">An optional webhook URL for message status callbacks.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created message payload if successful; otherwise, <see langword="null"/>.</returns>
    ValueTask<MessagingOutboundMessagePayload?> Send(string from, string to, string text, string messagingProfileId, string? webhookUrl = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an outbound MMS message with media attachments using Telnyx.
    /// </summary>
    /// <param name="from">The sender's phone number in E.164 format.</param>
    /// <param name="to">The recipient's phone number in E.164 format.</param>
    /// <param name="text">The body of the MMS message.</param>
    /// <param name="mediaUrls">The media URLs to include in the message.</param>
    /// <param name="messagingProfileId">The messaging profile ID to use for sending.</param>
    /// <param name="webhookUrl">An optional webhook URL for message status callbacks.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created message payload if successful; otherwise, <see langword="null"/>.</returns>
    ValueTask<MessagingOutboundMessagePayload?> SendMms(string from, string to, string text, List<string> mediaUrls, string messagingProfileId,
        string? webhookUrl = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a message by its Telnyx message ID.
    /// </summary>
    /// <param name="messageId">The message ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The message response if successful; otherwise, <see langword="null"/>.</returns>
    ValueTask<GetMessage200Response?> Get(string messageId, CancellationToken cancellationToken = default);
}
