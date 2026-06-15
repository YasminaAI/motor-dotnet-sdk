using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record GetPoliciesRequest
{
    [JsonIgnore]
    public int? QuoteRequestId { get; set; }

    [JsonIgnore]
    public string? QuotePriceId { get; set; }

    [JsonIgnore]
    public int? ProviderPolicyId { get; set; }

    [JsonIgnore]
    public string? CarSequenceNumber { get; set; }

    [JsonIgnore]
    public string? NewOwnerId { get; set; }

    [JsonIgnore]
    public string? PreviousOwnerId { get; set; }

    [JsonIgnore]
    public int? Status { get; set; }

    [JsonIgnore]
    public double? MinPrice { get; set; }

    [JsonIgnore]
    public double? MaxPrice { get; set; }

    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
