namespace InventoryProjectBackend.DTOs.Product
{
    public class UpdateProductDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
