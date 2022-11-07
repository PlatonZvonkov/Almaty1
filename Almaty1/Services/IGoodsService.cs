using AlmatyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmatyApi.Services
{
    public interface IGoodsService
    {
        Task<List<MovedGoodsView>> GetAllMovedGoodsAsync(int take);
        void DeleteMovedGoodsByModel(MoovedGoods movedGoods);
        Task PostNewMovedGoodsAsync(MoovedGoods moovedGoods);
    }
}
