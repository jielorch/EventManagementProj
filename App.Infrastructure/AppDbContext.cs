using App.Domain.Entities;
using App.Infrastructure.Config;
using App.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace App.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
        public IDbConnection Connection => Database.GetDbConnection();

        public DbSet<EventCategory> EventCategories { get; set; }

        public async Task<int> ExecuteScalarAsync(string storedProcedure, DynamicParameters? parameters, CommandType commandType)
        {
            return await Connection.ExecuteScalarAsync<int>(storedProcedure, parameters, null, 90, commandType);
        }

        public async Task<int> ExecuteSqlRawAsync(string storedProcedure, List<SqlParameter> parameters)
        {
            return await Database.ExecuteSqlRawAsync(storedProcedure, parameters);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string storedProcedure, DynamicParameters? parameters, CommandType commandType)
        {
            var results = await Connection.QueryAsync<T>(storedProcedure, parameters, null, 90, commandType);
            return results.AsList();
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string storedProcedure, DynamicParameters? parameters, CommandType commandType)
        {
            return await Connection.QueryMultipleAsync(storedProcedure, parameters, null, 90, commandType);
        }

        public async Task<T?> QuerySingleOrDefaultAsync<T>(string storedProcedure, DynamicParameters? parameters, CommandType commandType)
        {
            return await Connection.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, null, 90, commandType);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EventCategoryConfiguration());
        }

    }
}
