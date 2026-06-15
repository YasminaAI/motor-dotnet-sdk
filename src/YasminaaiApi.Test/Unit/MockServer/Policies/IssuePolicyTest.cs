using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Policies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IssuePolicyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "quote_request_id": 123,
              "quote_reference_id": "550e8400-e29b-41d4-a716-446655440000",
              "quote_price_id": "550e8400-e29b-41d4-a716-446655440001"
            }
            """;

        const string mockResponse = """
            {
              "id": 1,
              "meta_data": {
                "key": "value"
              },
              "start_date": "start_date",
              "provider_policy_id": 1,
              "provider_policy": "provider_policy",
              "order_status": 1,
              "approval_status": 1,
              "end_date": "end_date",
              "is_claimed": true,
              "created_at": "created_at",
              "updated_at": "updated_at",
              "client_id": "client_id",
              "canceled_at": "canceled_at",
              "invoice": "invoice",
              "cancellation_document": "cancellation_document"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/policies")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Policies.IssuePolicyAsync(
            new PostPoliciesRequest
            {
                QuoteRequestId = 123,
                QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
                QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
