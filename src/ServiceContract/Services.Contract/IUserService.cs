using System.Threading.Tasks;
using Service.Contract.Models;

namespace Services.Contract
{
    public interface IUserService
    {
        int AddUser(UserViewModel userViewModel);
        Task<PointUserViewModel> AddPoint(PointViewModel pointViewModel);
        Task<UserViewModel> GetAllUserPoint(int userid);
        Task UpdateLastPoint(PointViewModel pointViewModel);
        Task<PointViewModel> GetLastPoint(int userId);
    }
}