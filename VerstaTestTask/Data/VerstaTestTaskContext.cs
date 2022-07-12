using Microsoft.EntityFrameworkCore;

namespace VerstaTestTask.Data
{
    public class VerstaTestTaskContext : DbContext
    {
        public VerstaTestTaskContext (DbContextOptions<VerstaTestTaskContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<VerstaTestTask.Models.DeliveryOrderForm>? DeliveryOrderForm { get; set; }
    }
}
