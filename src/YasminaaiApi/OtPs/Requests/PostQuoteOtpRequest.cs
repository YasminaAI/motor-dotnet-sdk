using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record PostQuoteOtpRequest
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
