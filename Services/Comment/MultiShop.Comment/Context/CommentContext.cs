using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442; Initial Catalog=MultiShopCommentDb; User=sa; Password=123456aA*;"); //Docker db bilgilerini ekledik.
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
