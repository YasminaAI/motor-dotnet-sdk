using global::System.Text.Json;
using YasminaaiApi.Core;

namespace YasminaaiApi;

public partial class PoliciesClient : IPoliciesClient
{
    private readonly RawClient _client;

    internal PoliciesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<Policy>> ShowPolicyAsyncCore(
        GetPoliciesCarPolicyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new YasminaaiApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "policies/{0}",
                        ValueConvert.ToPathParameterString(request.CarPolicy)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Policy>(responseBody)!;
                return new WithRawResponse<Policy>()
                {
                    Data = responseData,
                    RawResponse = new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new YasminaaiApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new YasminaaiApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new YasminaaiApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<PaginatedPolicyResponse>> ListPoliciesAsyncCore(
        GetPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new YasminaaiApi.Core.QueryStringBuilder.Builder(capacity: 13)
            .Add("quote_request_id", request.QuoteRequestId)
            .Add("quote_price_id", request.QuotePriceId)
            .Add("provider_policy_id", request.ProviderPolicyId)
            .Add("car_sequence_number", request.CarSequenceNumber)
            .Add("new_owner_id", request.NewOwnerId)
            .Add("previous_owner_id", request.PreviousOwnerId)
            .Add("status", request.Status)
            .Add("min_price", request.MinPrice)
            .Add("max_price", request.MaxPrice)
            .Add("per_page", request.PerPage)
            .Add("date_from", request.DateFrom)
            .Add("date_to", request.DateTo)
            .Add("include_aggregates", request.IncludeAggregates)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new YasminaaiApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "policies",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PaginatedPolicyResponse>(responseBody)!;
                return new WithRawResponse<PaginatedPolicyResponse>()
                {
                    Data = responseData,
                    RawResponse = new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new YasminaaiApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new YasminaaiApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new YasminaaiApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new YasminaaiApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Policy>> IssuePolicyAsyncCore(
        PostPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new YasminaaiApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "policies",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Policy>(responseBody)!;
                return new WithRawResponse<Policy>()
                {
                    Data = responseData,
                    RawResponse = new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new YasminaaiApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new YasminaaiApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new YasminaaiApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody),
                            rawResponse: new YasminaaiApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new YasminaaiApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new YasminaaiApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Show a specific policy
    /// </summary>
    /// <example><code>
    /// await client.Policies.ShowPolicyAsync(new GetPoliciesCarPolicyRequest { CarPolicy = 1 });
    /// </code></example>
    public WithRawResponseTask<Policy> ShowPolicyAsync(
        GetPoliciesCarPolicyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Policy>(
            ShowPolicyAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Listing requested policies
    /// </summary>
    /// <example><code>
    /// await client.Policies.ListPoliciesAsync(
    ///     new GetPoliciesRequest
    ///     {
    ///         DateFrom = new DateOnly(2026, 6, 1),
    ///         DateTo = new DateOnly(2026, 6, 30),
    ///         IncludeAggregates = true,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PaginatedPolicyResponse> ListPoliciesAsync(
        GetPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedPolicyResponse>(
            ListPoliciesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// For issuing a new policy
    /// </summary>
    /// <example><code>
    /// await client.Policies.IssuePolicyAsync(
    ///     new PostPoliciesRequest
    ///     {
    ///         Otp = "123456",
    ///         QuoteRequestId = 123,
    ///         QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
    ///         QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Policy> IssuePolicyAsync(
        PostPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Policy>(
            IssuePolicyAsyncCore(request, options, cancellationToken)
        );
    }
}
