using global::System.Text.Json;
using YasminaaiApi.Core;

namespace YasminaaiApi;

public partial class OtPsClient : IOtPsClient
{
    private readonly RawClient _client;

    internal OtPsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<RawResponse> RequestOtpForQuoteVerificationAsyncCore(
        PostQuoteOtpRequest request,
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
                    Path = "quote-otp",
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
            return new YasminaaiApi.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
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

    private async Task<RawResponse> RequestOtpForIssuingPolicyAsyncCore(
        PostIssueOtpRequest request,
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
                    Path = "issue-otp",
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
            return new YasminaaiApi.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
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

    /// <summary>
    /// This endpoint sends a one-time password (OTP) to the provided email and phone number for quote verification. It should be called before creating a quote request.
    /// </summary>
    /// <example><code>
    /// await client.OtPs.RequestOtpForQuoteVerificationAsync(
    ///     new PostQuoteOtpRequest
    ///     {
    ///         Email = "someone@example.com",
    ///         Phone = "0501234567",
    ///         OwnerId = "1012345678",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask RequestOtpForQuoteVerificationAsync(
        PostQuoteOtpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            RequestOtpForQuoteVerificationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint sends a one-time password (OTP). It should be called before issuing a policy.
    /// </summary>
    /// <example><code>
    /// await client.OtPs.RequestOtpForIssuingPolicyAsync(
    ///     new PostIssueOtpRequest
    ///     {
    ///         Email = "someone@example.com",
    ///         Phone = "0501234567",
    ///         OwnerId = "1012345678",
    ///         QuoteRequestId = 123,
    ///         QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
    ///         QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask RequestOtpForIssuingPolicyAsync(
        PostIssueOtpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            RequestOtpForIssuingPolicyAsyncCore(request, options, cancellationToken)
        );
    }
}
