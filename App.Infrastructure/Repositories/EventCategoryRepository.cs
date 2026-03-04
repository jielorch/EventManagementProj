using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Infrastructure.Repositories
{
    public class EventCategoryRepository(IAppDbContext context) : RepositoryBase<EventCategory>(context), IEventCategoryRepository
    {
        public async Task<IReadOnlyList<EventCategory>> GetAllAsync()
        {
            var result = await QueryAsync<EventCategory>("GetEventCategories", null, commandType: CommandType.StoredProcedure);
            return [..result];

        }
    }
}
