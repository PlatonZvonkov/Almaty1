using System;

namespace AlmatyApi.Models
{
    public class MovedGoodsView
    {
        public string NomenclatureName { get; set; }
        public string WarehouseFrom { get; set; }
        public string WarehouseTo { get; set; }
        public int Ammount { get; set; }
        public DateTime Date { get; set; }
    }
}
