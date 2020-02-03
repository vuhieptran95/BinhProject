using BinhProjectMain.Models;

namespace BinhProjectMain.Services
{
    public interface ICategoryServices
    {
        Categories AddCategory(Categories category);
    }
    
    public class CategoryServices: ICategoryServices
    {
        private readonly NorthwindContext _context;

        public CategoryServices(NorthwindContext context)
        {
            _context = context;
        }
        public Categories AddCategory(Categories category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }
    }

    public interface IProductServices
    {
        int AddProduct(Products product);
    }
    
    public class ProductServices: IProductServices
    {
        private readonly NorthwindContext _context;

        public ProductServices(NorthwindContext context)
        {
            _context = context;
        }
        public int AddProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return 1;
        }
    }
}