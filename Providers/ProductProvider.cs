using FlipkartApi.Entites;
using FlipkartApi.Interfaces;

namespace FlipkartApi.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductDbContext context;

        public ProductProvider(IProductDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id); ;
        }

        public Product Add(Product product)
        {
            Product p=context.Products.FirstOrDefault(p=>p.Id==product.Id);
            if(p==null)
            {
                context.Products.Add(product);
            }
            context.SaveData();
            return product;
        }
        public Product Update(Product product)
        {
            Product p=context.Products.FirstOrDefault(p=>p.Id == product.Id);
            if(p!=null)
            {
                p.Name=product.Name;
                p.Description=product.Description;
                p.Price=product.Price;
                p.Category=product.Category;
                context.Products.Update(p);
            }
            context.Products.Update(p);
            context.SaveData();
            return p;
            
        }
        public int Delete(int id)
        {
            //Product p=context.Products.FirstOrDefault(p=>p.Id==id);
            Product p=context.Products.Find(id);
            if(p==null)
                return -1;
            else
            context.Products.Remove(p);
            context.SaveData();
            return id;
        }
    }
}
