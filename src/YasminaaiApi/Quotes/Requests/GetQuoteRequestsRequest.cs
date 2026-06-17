using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record GetQuoteRequestsRequest
{
    /// <summary>
    /// Inclusive lower bound for quote request creation date.
    /// </summary>
    [JsonIgnore]
    public DateOnly? DateFrom { get; set; }

    /// <summary>
    /// Inclusive upper bound for quote request creation date.
    /// </summary>
    [JsonIgnore]
    public DateOnly? DateTo { get; set; }

    /// <summary>
    /// Number of quote requests to return per page.
    /// </summary>
    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <summary>
    /// When true, includes quote request totals and monthly buckets for the filtered result set.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeAggregates { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
