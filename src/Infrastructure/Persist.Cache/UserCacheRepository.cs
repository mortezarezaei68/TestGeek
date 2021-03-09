using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Persist.Cache
{
    public class UserCacheRepository:IUserRepository
    {
        private readonly IMemoryCache _memoryCache;
        private List<User> _users;

        public UserCacheRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public int Add(User user)
        {
            if (!_memoryCache.TryGetValue(CacheKeys.UserCacheKey, out _users))
            {
                user.AddInCache(0);
                
                _users = new List<User> {user};
                
                _memoryCache.Set(CacheKeys.UserCacheKey, _users, TimeSpan.FromHours(12));
                return user.Id;
            }
            
            _memoryCache.TryGetValue(CacheKeys.UserCacheKey, out _users);
            var existUser=_users.FirstOrDefault(a => a.FirstName == user.FirstName && a.LastName == user.LastName);
            if (existUser is not null)
                return existUser.Id;

            var lastUser = _users.Last();
            user.AddInCache(lastUser.Id);
            _users.Add(user);
            return user.Id;
        }

        public Task<User> GetById(int id)
        {
            if (_memoryCache.TryGetValue(CacheKeys.UserCacheKey, out _users))
            {
                var user= _users.FirstOrDefault(a => a.Id == id);
                return Task.FromResult(user);
            }

            return Task.FromResult(new User());
        }

        public Task AddPoint(int userId, int point)
        {
            if (_memoryCache.TryGetValue(CacheKeys.UserCacheKey, out _users))
            {
                var user= _users.FirstOrDefault(a => a.Id == userId);
                user.AddPoint(point);
            }

            return Task.FromResult(false);
        }

        public Task UpdatePoint(int userId, int point)
        {
            if (_memoryCache.TryGetValue(CacheKeys.UserCacheKey, out _users))
            {
                var user= _users.FirstOrDefault(a => a.Id == userId);
                user?.UpdatePoint(point);
            }
            return Task.FromResult(false); 
        }
    }
}