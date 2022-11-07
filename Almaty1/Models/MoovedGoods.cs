using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AlmatyApi.Models
{
    public class MoovedGoods
    {
        public int NomenclatureId { get; set; }
        public int WarehouseFromId { get; set; }
        public int WarehouseToId { get; set; }
        public int Ammount { get; set; }
        public DateTime Date { get; set; }
    }
}
