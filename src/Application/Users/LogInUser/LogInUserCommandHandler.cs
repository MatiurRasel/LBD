﻿using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Entities.Abstractions;
using Domain.Entities.Users;

namespace Application.Users.LogInUser
{
    internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
    {
        private readonly IJwtService _jwtService;

        public LogInUserCommandHandler(IJwtService jwtService) => _jwtService = jwtService;

        public async Task<Result<AccessTokenResponse>> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _jwtService.GetAccessTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

            if (result.IsFailure) return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);

            return new AccessTokenResponse(result.Value);
        }
    }
}
