using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;

namespace YasminaaiApi.Test.Unit.MockServer.OtPs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RequestOtpForIssuingPolicyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "email": "someone@example.com",
              "phone": "0501234567",
              "owner_id": "1012345678",
              "quote_request_id": 123,
              "quote_reference_id": "550e8400-e29b-41d4-a716-446655440000",
              "quote_price_id": "550e8400-e29b-41d4-a716-446655440001"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/issue-otp")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.OtPs.RequestOtpForIssuingPolicyAsync(
                new PostIssueOtpRequest
                {
                    Email = "someone@example.com",
                    Phone = "0501234567",
                    OwnerId = "1012345678",
                    QuoteRequestId = 123,
                    QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
                    QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
                }
            )
        );
    }
}
