using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

/// <summary>
/// Returned only when include_aggregates is true.
/// </summary>
[Serializable]
public record QuoteRequestAggregates : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("total_count")]
    public int? TotalCount { get; set; }

    /// <summary>
    /// Monthly quote request counts keyed by YYYY-MM.
    /// </summary>
    [JsonPropertyName("by_month")]
    public Dictionary<string, int>? ByMonth { get; set; }

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
