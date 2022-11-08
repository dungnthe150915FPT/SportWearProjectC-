using System;
using System.Collections.Generic;

namespace SportWearManage.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime AddedDate { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string SourceOfSupply { get; set; } = null!;
        public int CategoryId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
