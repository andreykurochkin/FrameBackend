using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Frame.IntegrationTests.IdentityController;
public class IdentityControllerLoginTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program>? _fixture; // remove null-coalescing

    public IdentityControllerLoginTests(WebApplicationFactory<Program> fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public Task<IActionResult> LoginShould_ReturnOkResponse_WhenDataIsValid()
    {
        throw new NotImplementedException();
    }
}
