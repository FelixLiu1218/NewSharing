using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NewProject.Core;

namespace Relational
{
    /// <summary>
    /// The database context for the client data store
    /// </summary>
    public class ClientDataStoreDbContext :DbContext
    {
        #region DbSets 

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        #endregion

        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) {}

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            // Configure LoginCredentials
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);
        }

        #endregion
    }
}
