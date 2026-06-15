using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record Policy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("meta_data")]
    public Dictionary<string, object?>? MetaData { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("provider_policy_id")]
    public int? ProviderPolicyId { get; set; }

    [JsonPropertyName("provider_policy")]
    public string? ProviderPolicy { get; set; }

    [JsonPropertyName("order_status")]
    public int? OrderStatus { get; set; }

    [JsonPropertyName("approval_status")]
    public int? ApprovalStatus { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("is_claimed")]
    public bool? IsClaimed { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    [JsonPropertyName("invoice")]
    public string? Invoice { get; set; }

    [JsonPropertyName("cancellation_document")]
    public string? CancellationDocument { get; set; }

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
