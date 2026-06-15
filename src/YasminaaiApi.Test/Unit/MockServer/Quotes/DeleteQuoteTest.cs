using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Quotes;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteQuoteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Quote deleted successfully."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/quote-requests/1")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Quotes.DeleteQuoteAsync(
            new DeleteQuoteRequestsIdRequest { Id = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
