using AlmatyApi.DataAccess;
using AlmatyApi.Models;
using AlmatyApi.WarehousesEnum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmatyApi.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly IDBAccess dBAccess;
        public GoodsService(IDBAccess dBAccess)
        {
            this.dBAccess = dBAccess;
        }
        /**
         <summary> Deletes specified movement of nomenclature </summary>
         */
        public void DeleteMovedGoodsByModel(MoovedGoods movedGoods)
        {
            try
            {
                dBAccess.DeleteMoovedGoods(movedGoods);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /**
         <summary> Returns List of all goods by specified ammount from db </summary>
         */
        public async Task<List<MovedGoodsView>> GetAllMovedGoodsAsync(int take)
        {
            List<MovedGoodsView> result = new List<MovedGoodsView>();
            var temp = dBAccess.GetAllMovedGoodsAsync(take).Result;
            foreach (var item in temp)
            {
                var nomenclatureName = await dBAccess.GetNomenclatureById(item.NomenclatureId);
                result.Add(
                    new MovedGoodsView()
                    {
                        NomenclatureName = nomenclatureName.Name,
                        WarehouseFrom = ((WarehouseEnum)item.WarehouseFromId).ToString(),
                        WarehouseTo = ((WarehouseEnum)item.WarehouseToId).ToString(),
                        Date = item.Date,
                        Ammount = item.Ammount
                    });
            }
            return result;
        }

        /**
         <summary> Creates new instance of Moved Nomenclature </summary>
         */
        public async Task PostNewMovedGoodsAsync(MoovedGoods moovedGoods)
        {
            await dBAccess.PostMovedGoods(moovedGoods);
        }
    }
}
