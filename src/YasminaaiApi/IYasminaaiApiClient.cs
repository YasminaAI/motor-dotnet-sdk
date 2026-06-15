namespace YasminaaiApi;

public partial interface IYasminaaiApiClient
{
    public IQuotesClient Quotes { get; }
    public IPoliciesClient Policies { get; }
    public IOtPsClient OtPs { get; }
}
