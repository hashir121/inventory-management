namespace InventoryProjectBackend.DTOs.Purchase
{
    public class GetPaginatedPurchase
    {
        public long Id { get; set; }

        public long? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string? ProductName { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
