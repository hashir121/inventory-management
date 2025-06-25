using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;
using InventoryProjectBackend.Utility;
using Microsoft.EntityFrameworkCore;

namespace InventoryProjectBackend.Repositories
{
    public class ProductRepository: GenericRepository<Product> , IProductRepository
    {
        public readonly InventoryProjectContext _dbContext;

        public ProductRepository(InventoryProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<GetPaginatedProduct>> GetAllProductPaginated(PaginatedRequest get)
        {
            var query = _dbContext.Products
                .AsNoTracking()
                .Where(x => !x.IsDeleted &&
                (string.IsNullOrWhiteSpace(get.SearchText) ||
                x.Id.ToString().Contains(get.SearchText) ||
                (x.Name ?? string.Empty).ToLower().Contains(get.SearchText.ToLower()) ||
                (x.Description ?? string.Empty).ToLower().Contains(get.SearchText.ToLower())))
                .Select(x => new GetPaginatedProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate
                });

            query = query.Sorting(get.SortBy, get.SortDirection);

            return await query.ToPagedListAsync(get.PageNumber, get.PageSize);
        }
        
    }
}
