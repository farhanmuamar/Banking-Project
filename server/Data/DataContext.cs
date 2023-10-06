using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Nasabah> Nasabah {get;set;}
        public DbSet<Transaksi> Transaksi {get;set;}
        public DbSet<Point> Point {get;set;}
    }
}