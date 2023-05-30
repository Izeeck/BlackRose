using BlackRose.Models;
using BlackRose.ViewModel;

namespace BlackRose.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<bool> Create(EquipmentModel entity);      
        Task<Equipment> Get(int id);
        Task<List<Equipment>> Select();
        IEnumerable<Equipment> Equipment { get; }
        Task<Equipment> Updated(int id, EquipmentModel entity); 
        Task<bool> Delete(Equipment entity);
    }
}
