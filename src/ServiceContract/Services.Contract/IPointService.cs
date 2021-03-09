using System.Threading.Tasks;
using Service.Contract.Models;

namespace Services.Contract
{
    public interface IPointService
    {
        Task AddPoint(PointViewModel pointViewModel);
    }
}