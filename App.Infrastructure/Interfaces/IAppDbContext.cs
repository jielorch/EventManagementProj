using App.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Infrastructure.Interfaces
{
    public interface IAppDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }

        public DbSet<EventCategory> EventCategories { get; set; }

        Task<int> ExecuteSqlRawAsync(string storedProcedure, List<SqlParameter> parameters);
        Task<int> ExecuteScalarAsync(string storedProcedure, DynamicParameters? parameters, CommandType commandType);
        Task<IReadOnlyList<T>> QueryAsync<T>(string storedProcedure, DynamicParameters? parameters, CommandType commandType);
        Task<T?> QuerySingleOrDefaultAsync<T>(string storedProcedure, DynamicParameters? parameters, CommandType commandType);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string storedProcedure, DynamicParameters? parameters, CommandType commandType);

    }
}
