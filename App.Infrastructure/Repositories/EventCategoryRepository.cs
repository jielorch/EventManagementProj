using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Helper;
using App.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Infrastructure.Repositories
{
    public class EventCategoryRepository(IAppDbContext context) : RepositoryBase<EventCategory>(context), IEventCategoryRepository
    {
        private readonly IAppDbContext _context = context;
        public async Task<IReadOnlyList<EventCategory>> GetAllAsync()
        {
            if (_context.Database.IsSqlServer())
            {
                var result = await QueryAsync<EventCategory>(StoredProcedures.EventCategorySP.GetEventCategories, null, commandType: CommandType.StoredProcedure);
                return [.. result];
            }
            else
            {
                return await _context.EventCategories.ToListAsync();
            }
        }
    }
}
