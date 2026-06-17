using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[Serializable]
public record QuoteResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The owner’s national ID or Iqama ID
    /// </summary>
    [JsonPropertyName("owner_id")]
    public int? OwnerId { get; set; }

    /// <summary>
    /// The owner's phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The owner's birthdate. Hijri for Saudi nationals, Gregorian for others
    /// </summary>
    [JsonPropertyName("birthdate")]
    public DateOnly? Birthdate { get; set; }

    /// <summary>
    /// The car sequence number from 9 digits
    /// </summary>
    [JsonPropertyName("car_sequence_number")]
    public int? CarSequenceNumber { get; set; }

    /// <summary>
    /// Custom car number for newly imported cars (present when `custom_number` was used in the request)
    /// </summary>
    [JsonPropertyName("custom_number")]
    public string? CustomNumber { get; set; }

    /// <summary>
    /// Whether it was a car transfer or not
    /// </summary>
    [JsonPropertyName("is_ownership_transfer")]
    public bool? IsOwnershipTransfer { get; set; }

    /// <summary>
    /// The estimated cost of the car
    /// </summary>
    [JsonPropertyName("car_estimated_cost")]
    public double? CarEstimatedCost { get; set; }

    /// <summary>
    /// The car model year
    /// </summary>
    [JsonPropertyName("car_model_year")]
    public int? CarModelYear { get; set; }

    /// <summary>
    /// Requested policy start date in YYYY-MM-DD. Returned if provided in the quote request.
    /// </summary>
    [JsonPropertyName("start_date")]
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// List of drivers associated with this quote request. Returned if drivers were provided in the request.
    /// </summary>
    [JsonPropertyName("drivers")]
    public IEnumerable<QuoteResponseDriversItem>? Drivers { get; set; }

    /// <summary>
    /// An array representing each insurance company quote. Each item has the company name, the prices, and the benefits.
    /// </summary>
    [JsonPropertyName("quotes")]
    public IEnumerable<QuoteResponseQuotesItem>? Quotes { get; set; }

    /// <summary>
    /// Your own client ID
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// In case of an update on this quote, this date will change
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// When was the quote requested
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Yasmina ID for the quote. You can use it to delete items or showing it again to the customer
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

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
