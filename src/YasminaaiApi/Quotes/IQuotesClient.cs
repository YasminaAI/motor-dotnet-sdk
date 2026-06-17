namespace YasminaaiApi;

public partial interface IQuotesClient
{
    WithRawResponseTask<QuoteResponse> ShowQuoteAsync(
        GetQuoteRequestsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DeleteQuoteRequestsIdResponse> DeleteQuoteAsync(
        DeleteQuoteRequestsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<PaginatedQuoteResponse> ListQuotesAsync(
        GetQuoteRequestsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For getting prices with benefits.
    /// The Quote IDs can be used later to issue a policy
    /// </summary>
    WithRawResponseTask<QuoteResponse> RequestQuotesAsync(
        PostQuoteRequestsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
