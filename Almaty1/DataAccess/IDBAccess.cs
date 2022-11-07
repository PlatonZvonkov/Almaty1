using AlmatyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmatyApi.DataAccess
{
    public interface IDBAccess
    {
        Task<ICollection<MoovedGoods>> GetAllMovedGoodsAsync(int take);
        Task PostMovedGoods(MoovedGoods entity);
        void DeleteMoovedGoods(MoovedGoods moovedGoods);
        Task<Nomenclature> GetNomenclatureById(int id);

    }
}
