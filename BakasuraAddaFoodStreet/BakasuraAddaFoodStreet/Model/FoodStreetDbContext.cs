using Microsoft.EntityFrameworkCore;
using BakasuraAddaFoodStreet.Model;

namespace BakasuraAddaFoodStreet.Model
{
    public class FoodStreetDbContext:DbContext
    {
        public FoodStreetDbContext(DbContextOptions<FoodStreetDbContext> options) : base(options) { }
        //public DbSet<BakasuraAddaFoodStreet.Model.LocalFoodStreet> LocalFoodStreet { get; set; } = default!;
        public DbSet<LocalFoodStreet> LocalFoodStreet { get; set; }
        public DbSet<MasterUser> MasterUser { get; set; }

    }
}
