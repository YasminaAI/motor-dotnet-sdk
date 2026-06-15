using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record PostPoliciesRequest
{
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

    /// <summary>
    /// List of benefit UUIDs
    /// </summary>
    [JsonPropertyName("benefits")]
    public IEnumerable<string>? Benefits { get; set; }

    /// <summary>
    /// Optional free-form object with additional fields. Total JSON-encoded size must not exceed 255 characters.
    /// </summary>
    [JsonPropertyName("extra_fields")]
    public Dictionary<string, object?>? ExtraFields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
