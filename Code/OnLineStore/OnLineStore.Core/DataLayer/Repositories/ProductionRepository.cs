using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Core.DataLayer.Contracts;
using OnLineStore.Core.EntityLayer.Production;

namespace OnLineStore.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(IUserInfo userInfo, OnLineStoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IQueryable<Product> GetProducts(int? productCategoryID = null)
        {
            var query = DbContext.Products.AsQueryable();

            if (productCategoryID.HasValue)
                query = query.Where(item => item.ProductCategoryID == productCategoryID);

            return query;
        }

        public async Task<Product> GetProductAsync(Product entity)
            => await DbContext.Products.FirstOrDefaultAsync(item => item.ProductID == entity.ProductID);

        public Product GetProductByName(string productName)
            => DbContext.Products.FirstOrDefault(item => item.ProductName == productName);

        public IQueryable<ProductCategory> GetProductCategories()
            => DbContext.ProductCategories;

        public ProductCategory GetProductCategory(ProductCategory entity)
            => DbContext.ProductCategories.FirstOrDefault(item => item.ProductCategoryID == entity.ProductCategoryID);

        public IQueryable<ProductInventory> GetProductInventories(int? productID = null, string warehouseID = null)
        {
            var query = DbContext.ProductInventories.AsQueryable();

            if (productID.HasValue)
                query = query.Where(item => item.ProductID == productID);

            if (!string.IsNullOrEmpty(warehouseID))
                query = query.Where(item => item.WarehouseID == warehouseID);

            return query;
        }

        public ProductInventory GetProductInventory(ProductInventory entity)
            => DbContext.ProductInventories.FirstOrDefault(item => item.ProductInventoryID == entity.ProductInventoryID);

        public IQueryable<Warehouse> GetWarehouses()
            => DbContext.Warehouses;

        public async Task<Warehouse> GetWarehouseAsync(Warehouse entity)
            => await DbContext.Warehouses.FirstOrDefaultAsync(item => item.WarehouseID == entity.WarehouseID);
    }
}
