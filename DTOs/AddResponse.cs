namespace InventoryProjectBackend.DTOs
{
    public class AddResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }

        public AddResponse()
        {
            Success = true;
        }
        public AddResponse(string itemName)
        {
            Success = true;
            Message = $"{itemName} has been added successfully.";
        }
    }
}
