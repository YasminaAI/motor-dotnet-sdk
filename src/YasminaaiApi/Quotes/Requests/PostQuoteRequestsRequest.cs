using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record PostQuoteRequestsRequest
{
    /// <summary>
    /// Owner ID must be 10 digits starting with 1, 2, or 7
    /// </summary>
    [JsonPropertyName("owner_id")]
    public required string OwnerId { get; set; }

    /// <summary>
    /// Email address must be valid and belongs to the customer
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Phone number must start with 05 and be 10 digits
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// Birthdate in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("birthdate")]
    public required DateOnly Birthdate { get; set; }

    /// <summary>
    /// Car sequence number must be 8 or 9 digits
    /// </summary>
    [JsonPropertyName("car_sequence_number")]
    public required string CarSequenceNumber { get; set; }

    /// <summary>
    /// Indicates if the ownership is being transferred
    /// </summary>
    [JsonPropertyName("is_ownership_transfer")]
    public bool? IsOwnershipTransfer { get; set; }

    /// <summary>
    /// Required if is_ownership_transfer is true; 10 digits starting with 1,2,7
    /// </summary>
    [JsonPropertyName("current_car_owner_id")]
    public string? CurrentCarOwnerId { get; set; }

    /// <summary>
    /// Estimated cost of the car
    /// </summary>
    [JsonPropertyName("car_estimated_cost")]
    public required double CarEstimatedCost { get; set; }

    /// <summary>
    /// Car model year between 1950 and next year
    /// </summary>
    [JsonPropertyName("car_model_year")]
    public int? CarModelYear { get; set; }

    /// <summary>
    /// Desired policy start date in YYYY-MM-DD. Must be between tomorrow and 28 days from today (inclusive). The platform validates this range server-side.
    /// </summary>
    [JsonPropertyName("start_date")]
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// List of drivers for the vehicle. When provided, the sum of all driving_percentage values must equal 100, and the owner must be included among the drivers.
    /// </summary>
    [JsonPropertyName("drivers")]
    public IEnumerable<PostQuoteRequestsRequestDriversItem>? Drivers { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
