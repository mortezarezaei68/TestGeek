using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persist.InMemory.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Add(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user.Id;
        }

        public async Task<User> GetById(int id)=>
            await _appDbContext.Users.Include(a => a.Scores).FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddPoint(int userId, int point)
        {
            var user=await _appDbContext.Users.Include(a => a.Scores).FirstOrDefaultAsync(a => a.Id == userId);
            user.AddPoint(point);
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdatePoint(int userId, int point)
        {
            var user=await _appDbContext.Users.Include(a => a.Scores).FirstOrDefaultAsync(a => a.Id == userId);
            user.UpdatePoint(point);
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}