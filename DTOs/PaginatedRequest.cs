namespace InventoryProjectBackend.DTOs
{
    public class PaginatedRequest
    {
        public int PageNumber { get; set; } = 1;      
        public int PageSize { get; set; } = 15;       
        public string? SearchText { get; set; }
        public string SortBy { get; set; } = "createdDate";          
        public string SortDirection { get; set; } = "Desc";  
    }
}
