using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}
