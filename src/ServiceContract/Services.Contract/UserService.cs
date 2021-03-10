using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Service.Contract.Models;

namespace Services.Contract
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(UserViewModel userViewModel)
        {
            var user = new User();
            user.Add(userViewModel.FirstName,userViewModel.LastName);
            var userId=_userRepository.Add(user);
            return userId;
        }

        public async Task<PointUserViewModel> AddPoint(PointViewModel pointViewModel)
        {
            await _userRepository.AddPoint(pointViewModel.UserId, pointViewModel.Point);
            var user=await _userRepository.GetById(pointViewModel.UserId);
            return new PointUserViewModel
            {
                Name = user.FirstName + user.LastName,
                Point = pointViewModel.Point
            };
        }

        public async Task<UserViewModel> GetAllUserPoint(int userid)
        {
            var user = await _userRepository.GetById(userid);
            return new UserViewModel
            {
                Points = user.Scores.Select(a => new PointViewModel
                {
                    UserId = user.Id,
                    Point = a.Point
                }).ToList(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task UpdateLastPoint(PointViewModel pointViewModel)
        {
            await _userRepository.UpdatePoint(pointViewModel.UserId, pointViewModel.Point);
        }

        public async Task<PointViewModel> GetLastPoint(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user is not null)
            {
                var lastScore = user.Scores.LastOrDefault();
                return new PointViewModel
                {
                    Point = lastScore.Point,
                    UserId = userId
                };
            }

            throw new ApplicationException("user not found");
        }
    }
}