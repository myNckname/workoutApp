using DAL.Models;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDietsService:IDefaultService<Diet>
    {
        Task<Diet> GetUsersDiet();
    }
}
