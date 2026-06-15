namespace YasminaaiApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, YasminaaiApi.RawResponse? rawResponse = null)
    : YasminaaiApiApiException("NotFoundError", 404, body, rawResponse: rawResponse);
