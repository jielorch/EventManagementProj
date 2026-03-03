using App.Domain.Entities;

namespace App.Application.Interfaces
{
    public interface IEventCategoryRepository
    {
        Task<IReadOnlyList<EventCategory>> GetAllAsync();
    }
}
