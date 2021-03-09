using System.Threading.Tasks;
using Domain.Models;
using Service.Contract.Models;

namespace Services.Contract
{
    public class PointService:IPointService
    {
        private readonly IUserRepository _userRepository;

        public PointService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddPoint(PointViewModel pointViewModel)
        {
            await _userRepository.AddPoint(pointViewModel.UserId, pointViewModel.Point);
        }
    }
}