using GoodHamburger.Infrastructure.Persistence;
public interface ISeeder
{
    Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default);
}