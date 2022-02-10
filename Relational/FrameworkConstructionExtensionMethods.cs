using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewProject.Core;

namespace Relational
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensionMethods 
    {
        public static FrameworkConstruction AddClientDataStore(this FrameworkConstruction construction)
        {
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                //Setup connection string
                //we can change to sql server by this line
                options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            }, contextLifetime: ServiceLifetime.Transient);

            construction.Services.AddTransient<IClientDataStore>(
                provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            return construction;
        }
    }
}
