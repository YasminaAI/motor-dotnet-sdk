namespace YasminaaiApi;

public partial interface IOtPsClient
{
    /// <summary>
    /// This endpoint sends a one-time password (OTP) to the provided email and phone number for quote verification. It should be called before creating a quote request.
    /// </summary>
    WithRawResponseTask RequestOtpForQuoteVerificationAsync(
        PostQuoteOtpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint sends a one-time password (OTP). It should be called before issuing a policy.
    /// </summary>
    WithRawResponseTask RequestOtpForIssuingPolicyAsync(
        PostIssueOtpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
