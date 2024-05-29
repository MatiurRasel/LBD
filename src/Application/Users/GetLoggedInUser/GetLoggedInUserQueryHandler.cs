﻿using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Entities.Abstractions;

namespace Application.Users.GetLoggedInUser;
internal sealed class GetLoggedInUserQueryHandler : IQueryHandler<GetLoggedInUserQuery,UserResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;
    public GetLoggedInUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserContext userContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<UserResponse>> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM users
            WHERE identity_id = @IdentityId
            """;

        return await connection.QuerySingleOrDefaultAsync<UserResponse>(
            sql,
            new
            {
                _userContext.IdentityId
            });
    }
}
