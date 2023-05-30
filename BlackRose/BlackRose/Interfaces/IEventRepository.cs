using BlackRose.Models;
using BlackRose.ViewModel;

namespace BlackRose.Interfaces
{
    public interface IEventRepository
    {
        Task<bool> Create(EventAirsoftModel entity);      
        Task<EventAirsoft> Get(int id);
        Task<List<EventAirsoft>> Select();
        Task<List<EventAirsoft>> GetFavEv();
        Task<EventAirsoft> Updated(int id, EventAirsoftModel entity);  
        Task<bool> Delete(EventAirsoft entity);
    }
}
