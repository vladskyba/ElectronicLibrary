using ElectronicLibrary.DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.DAO
{
    public static class DataInitiallizer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<LibraryContext>();

            // Check database exiting
           // var isExists = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator
            //               && await databaseCreator.ExistsAsync();

            // Automatically migrate
            await context!.Database.MigrateAsync();
        }
    }
}
