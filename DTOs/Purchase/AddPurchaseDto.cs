namespace InventoryProjectBackend.DTOs.Purchase
{
    public class AddPurchaseDto
    {
        public long? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
