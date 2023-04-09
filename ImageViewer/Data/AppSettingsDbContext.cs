using ImageViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceOnLoan_WebApp.Data
{
    public class AppSettingsDbContext : DbContext
    {
        public DbSet<UI> Images { get; set; }

        public AppSettingsDbContext(DbContextOptions<AppSettingsDbContext> options) : base(options) { }
    }
}
