using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Statistics>> GetUserStatistics();
    }
}
