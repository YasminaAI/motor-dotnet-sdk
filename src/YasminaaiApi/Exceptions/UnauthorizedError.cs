namespace YasminaaiApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, YasminaaiApi.RawResponse? rawResponse = null)
    : YasminaaiApiApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
