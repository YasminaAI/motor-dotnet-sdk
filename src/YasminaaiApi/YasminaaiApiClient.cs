using YasminaaiApi.Core;

namespace YasminaaiApi;

public partial class YasminaaiApiClient : IYasminaaiApiClient
{
    private readonly RawClient _client;

    public YasminaaiApiClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "YasminaaiApi" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Yasmina.Motor.DotNet/0.0.61" },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Quotes = new QuotesClient(_client);
        Policies = new PoliciesClient(_client);
        OtPs = new OtPsClient(_client);
    }

    public IQuotesClient Quotes { get; }

    public IPoliciesClient Policies { get; }

    public IOtPsClient OtPs { get; }
}
