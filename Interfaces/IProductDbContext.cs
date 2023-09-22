using FlipkartApi.Entites;
using Microsoft.EntityFrameworkCore;

namespace FlipkartApi.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; set; }
        void SaveData();
    }
}
