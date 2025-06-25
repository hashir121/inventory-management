namespace InventoryProjectBackend.DTOs
{
    public class PagedList<T>
    {
        public List<T> Records { get; set; } = new(); 
        public int TotalPages { get; set; }        
        public int PageNumber { get; set; }       
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

    }
}
