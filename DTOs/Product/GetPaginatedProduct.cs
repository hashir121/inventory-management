namespace InventoryProjectBackend.DTOs.Product
{
    public class GetPaginatedProduct
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
