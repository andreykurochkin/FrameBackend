using FluentAssertions;
using Frame.Contracts.V1;
using Frame.Contracts.V1.Requests;
using Frame.UnitTests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
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
    public async Task LoginShould_ReturnOkResponse_WhenUserIsNotFoundInPersistent()
    {
        UserLoginRequest userLoginRequest = new UserLoginRequest
        {
            Email = TokenSpecificFixture.Email,
            Password = TokenSpecificFixture.Password,
        };
        var json = System.Text.Json.JsonSerializer.Serialize(userLoginRequest);
        HttpContent httpContent = new StringContent(json, encoding: System.Text.Encoding.UTF8, mediaType: "application/json");


        //var path = "/api/v1/identity/login";
        var httpRequestMessage = new HttpRequestMessage(method: HttpMethod.Post, ApiRoutes.Identity.Login);
        httpRequestMessage.Content = httpContent;

        //var response = await _httpClient.SendAsync(httpRequestMessage);
        var response = await _httpClient.PostAsync(ApiRoutes.Identity.Login, httpContent);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }
}
