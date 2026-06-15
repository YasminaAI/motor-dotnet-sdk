using NUnit.Framework;
using YasminaaiApi;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Quotes;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RequestQuotesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "owner_id": "owner_id",
              "phone": "phone",
              "birthdate": "2023-01-15",
              "car_sequence_number": "car_sequence_number",
              "car_estimated_cost": 1.1
            }
            """;

        const string mockResponse = """
            {
              "owner_id": 1,
              "phone": "phone",
              "birthdate": "2023-01-15",
              "car_sequence_number": 1,
              "is_ownership_transfer": true,
              "car_estimated_cost": 1.1,
              "car_model_year": 1,
              "start_date": "2023-01-15",
              "drivers": [
                {
                  "owner_id": "owner_id",
                  "birthdate": "2023-01-15",
                  "driving_percentage": 1
                }
              ],
              "quotes": [
                {
                  "company_name": "company_name",
                  "prices": [
                    {
                      "vat_percentage": 15
                    }
                  ],
                  "benefits": [
                    {}
                  ]
                }
              ],
              "client_id": "client_id",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "created_at": "2024-01-15T09:30:00.000Z",
              "id": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/quote-requests")
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

        var response = await Client.Quotes.RequestQuotesAsync(
            new PostQuoteRequestsRequest
            {
                OwnerId = "owner_id",
                Phone = "phone",
                Birthdate = new DateOnly(2023, 1, 15),
                CarSequenceNumber = "car_sequence_number",
                CarEstimatedCost = 1.1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
