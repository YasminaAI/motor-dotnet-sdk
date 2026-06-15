using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Policies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ShowPolicyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/policies/1").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Policies.ShowPolicyAsync(
            new GetPoliciesCarPolicyRequest { CarPolicy = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
