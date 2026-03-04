using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventCategories.Queries.GetAllEventCategories
{
    public class GetAllEventCategoriesQueryHandler(IEventCategoryRepository eventCategoryRepository) : IRequestHandler<GetAllEventCategoriesQuery, IReadOnlyList<EventCategory>>
    { 
        private readonly IEventCategoryRepository _eventCategoryRepository = eventCategoryRepository;

        public async Task<IReadOnlyList<EventCategory>> Handle(GetAllEventCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _eventCategoryRepository.GetAllAsync();
        }
    }
}
