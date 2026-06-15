namespace YasminaaiApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(
    Dictionary<string, object?> body,
    YasminaaiApi.RawResponse? rawResponse = null
) : YasminaaiApiApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Dictionary<string, object?> Body => body;
}
