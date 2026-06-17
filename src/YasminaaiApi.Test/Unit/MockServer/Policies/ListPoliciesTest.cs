using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Policies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPoliciesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "current_page": 1,
              "data": [
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
                  "uploaded_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "updated_at",
                  "client_id": "client_id",
                  "canceled_at": "canceled_at",
                  "invoice": "invoice",
                  "cancellation_document": "cancellation_document"
                }
              ],
              "first_page_url": "first_page_url",
              "from": 1,
              "last_page": 1,
              "last_page_url": "last_page_url",
              "links": [
                {
                  "url": "url",
                  "label": "label",
                  "active": true
                }
              ],
              "next_page_url": "next_page_url",
              "path": "path",
              "per_page": 1,
              "prev_page_url": "prev_page_url",
              "to": 1,
              "total": 1,
              "aggregates": {
                "total_count": 12,
                "total_price": 42850.75,
                "by_month": {
                  "2026-06": {
                    "count": 12,
                    "total_price": 42850.75
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/policies")
                    .WithParam("date_from", "2026-06-01")
                    .WithParam("date_to", "2026-06-30")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Policies.ListPoliciesAsync(
            new GetPoliciesRequest
            {
                DateFrom = new DateOnly(2026, 6, 1),
                DateTo = new DateOnly(2026, 6, 30),
                IncludeAggregates = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
