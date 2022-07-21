using FluentAssertions;
using Frame.Contracts.V1;
using Frame.Contracts.V1.Requests;
using Frame.UnitTests.Fixtures;
using FrameBackend.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Frame.IntegrationTests.IdentityController;
public class IdentityControllerLoginTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _fixture;
    private readonly HttpClient _httpClient;

    public IdentityControllerLoginTests(WebApplicationFactory<Program> fixture)
    {
        _fixture = fixture;
        _httpClient = _fixture.CreateClient();
    }
    
    [Fact]
    public async Task LoginShould_ReturnBadRequest_WhenUserIsNotFoundInPersistent()
    {
        HttpContent httpContent = CreateHttpContentWhenUserNotFound();

        var response = await _httpClient.PostAsync(ApiRoutes.Identity.Login, httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    private static HttpContent CreateHttpContentWhenUserNotFound()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(UserLoginRequests.UserNotFound);
        HttpContent httpContent = new StringContent(json, encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
        return httpContent;
    }
}
