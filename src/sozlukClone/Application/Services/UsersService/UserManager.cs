﻿using Application.Features.Users.Rules;
using Application.Services.RegisterAudits;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Security.Hashing;
using System.Linq.Expressions;

namespace Application.Services.UsersService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IRegisterAuditService _registerAuditService;

    public UserManager(IUserRepository userRepository, UserBusinessRules userBusinessRules, IRegisterAuditService registerAuditService)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _registerAuditService = registerAuditService;
    }

    public async Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>?> GetListAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _userRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);

        return deletedUser;
    }

    public async Task<User> Register(UserForRegisterDto request)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);

        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User newUser =
            new()
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
        User createdUser = await _userRepository.AddAsync(newUser);

        RegisterAudit registerAudit = new()
        {
            Ip = "",
            Location = "",
            UserId = createdUser.Id,
            Email = createdUser.Email,
        };

        await _registerAuditService.AddAsync(registerAudit);

        return createdUser;
    }
}
