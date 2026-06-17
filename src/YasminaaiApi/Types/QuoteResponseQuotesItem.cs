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
    /// Arabic name of the insurance company. Use this field instead of `company_name` when rendering Arabic UIs.
    /// </summary>
    [JsonPropertyName("company_name_ar")]
    public string? CompanyNameAr { get; set; }

    /// <summary>
    /// Normalised insurance category used to group and filter quotes. Always one of `TPL`, `TPL +`, or `Comprehensive`.
    /// </summary>
    [JsonPropertyName("type")]
    public QuoteResponseQuotesItemType? Type { get; set; }

    /// <summary>
    /// The insurance type label exactly as the insurance provider intends it to be displayed. While `type` normalises all non-TPL / non-Comprehensive values into `TPL +`, this field preserves the original provider string (e.g. "TPL Plus", "Third Party Plus") and should be shown in the UI wherever the provider's own wording is preferred.
    /// </summary>
    [JsonPropertyName("insurance_type_display")]
    public string? InsuranceTypeDisplay { get; set; }

    /// <summary>
    /// Arabic translation of `insurance_type_display`. Use this field for Arabic UIs. Falls back to the English value for provider-specific types that do not have a translation.
    /// </summary>
    [JsonPropertyName("insurance_type_display_ar")]
    public string? InsuranceTypeDisplayAr { get; set; }

    /// <summary>
    /// CDN URL for the insurance company's logo.
    /// </summary>
    [JsonPropertyName("company_logo_url")]
    public string? CompanyLogoUrl { get; set; }

    /// <summary>
    /// CDN URL for the insurance company's square logo.
    /// </summary>
    [JsonPropertyName("square_company_logo_url")]
    public string? SquareCompanyLogoUrl { get; set; }

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
