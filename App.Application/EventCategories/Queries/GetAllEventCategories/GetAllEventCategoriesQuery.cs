using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventCategories.Queries.GetAllEventCategories
{
    public record GetAllEventCategoriesQuery : IRequest<IReadOnlyList<EventCategory>>
    {
    }
}
