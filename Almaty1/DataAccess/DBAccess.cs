using AlmatyApi.Context;
using AlmatyApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmatyApi.DataAccess
{
    public class DBAccess : IDBAccess
    {
        private SQLLocalDBContext context;

        public DBAccess(SQLLocalDBContext context)
        {
            this.context = context;
        }

        public void DeleteMoovedGoods(MoovedGoods moovedGoods)
        {
            try
            {
                context.MoovedGoods.Remove(moovedGoods);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<MoovedGoods>> GetAllMovedGoodsAsync(int take)
        {
            return await context.MoovedGoods.Take(take).OrderBy(x => x).ToListAsync();
        }

        public async Task<Nomenclature> GetNomenclatureById(int id)
        {
            var result = await context.Nomenclature.FindAsync(id);
            return result;
        }

        public async Task PostMovedGoods(MoovedGoods entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
