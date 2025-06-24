using System;
using System.Collections.Generic;

namespace InventoryProjectBackend.Entities;

public partial class Sale
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Product? Product { get; set; }
}
