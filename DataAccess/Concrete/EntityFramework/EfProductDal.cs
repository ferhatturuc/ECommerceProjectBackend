using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId

                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryId = p.CategoryId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitPrice,
                                 ProductImages = context.ProductImages.Where(pi => pi.ProductId == p.ProductId).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<ProductDetailDto> GetProductDetailsByCategoryId(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             where c.CategoryId == categoryId

                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryId = p.CategoryId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitPrice,
                                 ProductImages = context.ProductImages.Where(pi => pi.ProductId == p.ProductId).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
