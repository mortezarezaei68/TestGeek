using System.Threading.Tasks;

namespace Domain.Models
{
    public interface IUserRepository
    {
        int Add(User user);
        Task<User> GetById(int id);
        Task AddPoint(int userId, int point);
        Task UpdatePoint(int userId, int point);
        
    }
}