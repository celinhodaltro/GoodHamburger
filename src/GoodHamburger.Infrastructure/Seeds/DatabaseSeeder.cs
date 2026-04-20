using GoodHamburger.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GoodHamburger.Infrastructure.Seeds;
public static class DatabaseSeeder
{
    public static async Task ApplySeedAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.EnsureCreatedAsync();

        var seeders = GetSeeders();

        foreach (var seederType in seeders)
        {
            var seeder = (ISeeder)Activator.CreateInstance(seederType)!;

            await seeder.SeedAsync(context);
        }

        await context.SaveChangesAsync();
    }

    private static IEnumerable<Type> GetSeeders()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type =>
                typeof(ISeeder).IsAssignableFrom(type) &&
                type is { IsInterface: false, IsAbstract: false });
    }
}