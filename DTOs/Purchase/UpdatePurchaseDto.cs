namespace InventoryProjectBackend.DTOs.Purchase
{
    public class UpdatePurchaseDto
    {
        public long? Id { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
