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

    /// <summary>
    /// Inclusive lower bound for the policy date. For issued policies (`status=1`), this filters by `uploaded_at` (the provider policy issue timestamp) and falls back to `created_at` when `uploaded_at` is unavailable. For other statuses, this filters by `created_at`.
    /// </summary>
    [JsonIgnore]
    public DateOnly? DateFrom { get; set; }

    /// <summary>
    /// Inclusive upper bound for the policy date. For issued policies (`status=1`), this filters by `uploaded_at` (the provider policy issue timestamp) and falls back to `created_at` when `uploaded_at` is unavailable. For other statuses, this filters by `created_at`.
    /// </summary>
    [JsonIgnore]
    public DateOnly? DateTo { get; set; }

    /// <summary>
    /// When true, includes policy totals, total price, and monthly buckets for the filtered result set.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeAggregates { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
