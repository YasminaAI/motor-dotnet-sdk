using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record QuoteResponseQuotesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// An array representing each price. This will have the premium and the deductible
    /// </summary>
    [JsonPropertyName("prices")]
    public IEnumerable<QuotePrice>? Prices { get; set; }

    /// <summary>
    /// An array representing the different benefits offered by the company. Some of them are free and comes with the insurance, some are paid and optional
    /// </summary>
    [JsonPropertyName("benefits")]
    public IEnumerable<Benefit>? Benefits { get; set; }

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
