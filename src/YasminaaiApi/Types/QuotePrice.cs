using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record QuotePrice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("quote_price_id")]
    public string? QuotePriceId { get; set; }

    [JsonPropertyName("deductible")]
    public double? Deductible { get; set; }

    [JsonPropertyName("subtotal")]
    public double? Subtotal { get; set; }

    [JsonPropertyName("vat_percentage")]
    public double? VatPercentage { get; set; }

    [JsonPropertyName("vat")]
    public double? Vat { get; set; }

    [JsonPropertyName("total")]
    public double? Total { get; set; }

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
