using Microsoft.EntityFrameworkCore;

namespace TourOfHeroesApi.Domain;

public class HeroDataContext : DbContext
{
    public HeroDataContext(DbContextOptions<HeroDataContext> options) : base(options)
    {
        
    }

    public virtual DbSet<HeroEntity> Heroes { get; set; } = null!;
}
