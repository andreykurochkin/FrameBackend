using Frame.Contracts.V1.Requests;

namespace FrameBackend.IntegrationTests.Helpers;
public static class UserLoginRequests
{
    public static UserLoginRequest UserNotFound => new UserLoginRequest
    {
        Email = "undefined@test.com",
        Password = "3386O^BqA$3#",
    };
}
