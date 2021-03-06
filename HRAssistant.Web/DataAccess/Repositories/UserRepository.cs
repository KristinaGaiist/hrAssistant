﻿using System;
using System.Linq;
using System.Threading.Tasks;
using HRAssistant.Web.DataAccess.Core;
using HRAssistant.Web.Domain;
using LiteGuard;
using Microsoft.EntityFrameworkCore;

namespace HRAssistant.Web.DataAccess.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            Guard.AgainstNullArgument(nameof(context), context);

            _context = context;
        }

        public void Add(UserEntity user)
        {
            Guard.AgainstNullArgument(nameof(user), user);

            _context.Users.Add(user);
        }

        public Task<bool> Exists(Guid userId)
        {
            return _context.Users.AnyAsync(u => u.Id == userId);
        }

        public Task<bool> ExistsByUsername(string username, Guid? excludeUserId = null)
        {
            Guard.AgainstNullArgument(nameof(username), username);

            return _context.Users.AnyAsync(u => u.Username == username && (!excludeUserId.HasValue || excludeUserId.Value != u.Id));
        }

        public async Task<UserEntity> Get(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with id '{userId}' was not found.");
            }

            return user;
        }

        public IQueryable<UserEntity> Search() => _context.Users;
    }
}
