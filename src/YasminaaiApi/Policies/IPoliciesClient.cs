namespace YasminaaiApi;

public partial interface IPoliciesClient
{
    /// <summary>
    /// Show a specific policy
    /// </summary>
    WithRawResponseTask<Policy> ShowPolicyAsync(
        GetPoliciesCarPolicyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Listing requested policies
    /// </summary>
    WithRawResponseTask<IEnumerable<Policy>> ListPoliciesAsync(
        GetPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For issuing a new policy
    /// </summary>
    WithRawResponseTask<Policy> IssuePolicyAsync(
        PostPoliciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
