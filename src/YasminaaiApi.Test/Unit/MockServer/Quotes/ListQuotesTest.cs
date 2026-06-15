using NUnit.Framework;
using YasminaaiApi.Test.Unit.MockServer;
using YasminaaiApi.Test.Utils;

namespace YasminaaiApi.Test.Unit.MockServer.Quotes;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListQuotesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "current_page": 1,
              "data": [
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
                    {}
                  ],
                  "quotes": [
                    {
                      "prices": [
                        {
                          "vat_percentage": 15
                        }
                      ]
                    }
                  ],
                  "client_id": "client_id",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "id": 1
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
              "total": 1
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/quote-requests").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Quotes.ListQuotesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
