using Application.Abstractions.Authentication;
using Domain.Entities.Users;
using Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace Infrastructure.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    private const string PasswordCredentialType = "password";
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        var userRepresentationModel = UserRepresentationModel.FromUser(user);

        userRepresentationModel.Credentials = new CredentialRepresentationModel[]
        {
            new()
            {
                Value = password,
                Temporary = false,
                Type = PasswordCredentialType
            }
        };

        var response = await _httpClient.PostAsJsonAsync(
            "users",
            userRepresentationModel,
            cancellationToken);

        return ExtractIdentityIdFromLocationHeader(response);
    }

    private string ExtractIdentityIdFromLocationHeader(HttpResponseMessage response)
    {
        const string usersSegmentName = "users/";
        var locationHeader = response.Headers.Location?.PathAndQuery;

        if (locationHeader is null) throw new InvalidOperationException("Location header can't be null");

        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);

        return locationHeader.Substring(
            userSegmentValueIndex + usersSegmentName.Length);

    }
}
