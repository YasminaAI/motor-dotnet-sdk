using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record QuoteResponseDriversItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Driver's national ID (10 digits starting with 1, 2, or 7)
    /// </summary>
    [JsonPropertyName("owner_id")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// Driver's birthdate in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("birthdate")]
    public DateOnly? Birthdate { get; set; }

    /// <summary>
    /// Percentage of driving for this driver (25, 50, 75, or 100)
    /// </summary>
    [JsonPropertyName("driving_percentage")]
    public int? DrivingPercentage { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
