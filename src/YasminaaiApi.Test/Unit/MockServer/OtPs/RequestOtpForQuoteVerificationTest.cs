using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;

namespace YasminaaiApi.Test.Unit.MockServer.OtPs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RequestOtpForQuoteVerificationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "email": "someone@example.com",
              "phone": "0501234567",
              "owner_id": "1012345678"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/quote-otp")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.OtPs.RequestOtpForQuoteVerificationAsync(
                new PostQuoteOtpRequest
                {
                    Email = "someone@example.com",
                    Phone = "0501234567",
                    OwnerId = "1012345678",
                }
            )
        );
    }
}
