using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

/// <summary>
/// Returned only when include_aggregates is true.
/// </summary>
[Serializable]
public record PolicyAggregates : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("total_count")]
    public int? TotalCount { get; set; }

    [JsonPropertyName("total_price")]
    public float? TotalPrice { get; set; }

    /// <summary>
    /// Monthly policy counts and sales totals keyed by YYYY-MM. For issued policies (`status=1`), buckets use `uploaded_at` and fall back to `created_at`.
    /// </summary>
    [JsonPropertyName("by_month")]
    public Dictionary<string, PolicyMonthAggregate>? ByMonth { get; set; }

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
