using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.DTOs.Purchase;
using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;
using InventoryProjectBackend.Utility;
using Microsoft.EntityFrameworkCore;

namespace InventoryProjectBackend.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public readonly InventoryProjectContext _dbContext;

        public PurchaseRepository(InventoryProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<PagedList<GetPaginatedPurchase>> GetAllPurchasePaginated(PaginatedRequest get)
        {
            var searchText = get.SearchText?.ToLower();
            var query = _dbContext.Purchases
                        .Include(x => x.Product)
                        .AsNoTracking()
                        .Where(x => !x.IsDeleted)
                        .Where(x =>
                        string.IsNullOrEmpty(searchText) ||
                        x.Id.ToString().Contains(searchText) ||
                        (x.Product != null && x.Product.Name.ToLower().Contains(searchText.ToLower())) ||
                        x.Quantity.ToString().Contains(searchText) ||
                        x.Price.ToString().Contains(searchText)
                        )
                        .Select(x => new GetPaginatedPurchase
                        {
                            Id = x.Id,
                            ProductId = x.ProductId,
                            ProductName = x.Product != null ? x.Product.Name : "",
                            CreatedDate = x.CreatedDate,
                            Quantity = x.Quantity,
                            Price = x.Price
                        });

            query = query.Sorting(get.SortBy, get.SortDirection);

            return await query.ToPagedListAsync(get.PageNumber, get.PageSize);
        }


        public async Task<List<ProductDropdownDto>> GetProductList()
        {
            var query = await _dbContext.Products
                                .AsNoTracking()
                                .Where(x => !x.IsDeleted)
                                .Select(x => new ProductDropdownDto
                                {
                                    Id= x.Id,
                                    Name  = x.Name,
                                }).ToListAsync();

            return query;
        }
    }
}
