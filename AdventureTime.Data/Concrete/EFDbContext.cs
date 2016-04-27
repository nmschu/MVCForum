using AdventureTime.Data.Entities;
using System.Data.Entity;

namespace AdventureTime.Data.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<AdventureTime_Story> Stories { get; set; }
        public DbSet<AdventureTime_Paragraph> Paragraphs { get; set; }

    }
}
