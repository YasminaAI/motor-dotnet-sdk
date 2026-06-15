using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record PostIssueOtpRequest
{
    /// <summary>
    /// Email address of the car owner
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// Phone number starting with 05 and containing 10 digits
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// National ID or Iqama ID of the car owner (10 digits)
    /// </summary>
    [JsonPropertyName("owner_id")]
    public required string OwnerId { get; set; }

    /// <summary>
    /// ID of the car quote request
    /// </summary>
    [JsonPropertyName("quote_request_id")]
    public required int QuoteRequestId { get; set; }

    /// <summary>
    /// Unique identifier for the quote reference ID (coming from POST /quote-requests)
    /// </summary>
    [JsonPropertyName("quote_reference_id")]
    public required string QuoteReferenceId { get; set; }

    /// <summary>
    /// Unique identifier for the quote price ID that exists inside a quote item (coming from POST /quote-requests)
    /// </summary>
    [JsonPropertyName("quote_price_id")]
    public required string QuotePriceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
