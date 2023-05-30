using BlackRose.Data;
using BlackRose.Interfaces;
using BlackRose.Models;
using BlackRose.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BlackRose.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public readonly ApplicationDbContext _db;
        public EquipmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Equipment> Equipment => _db.Equipmentes.Where(x => x.Availability);
        public async Task<bool> Create(EquipmentModel model)
        {
            Equipment equip = new Equipment
            {
                Name = model.Name,
                ShortDesc = model.ShortDesc,
                LongDesc = model.LongDesc,
                Price = model.Price,
                Availability = model.Availability,
                DateReturn = model.DateReturn,
                CategoryEquips = model.CategoryEquips,
            };
            if (model.Image != null)
            {
                byte[] imageDataA = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                {
                    imageDataA = binaryReader.ReadBytes((int)model.Image.Length);
                }
                // установка массива байтов
                equip.Image = imageDataA;
            }
            await _db.Equipmentes.AddAsync(equip);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Equipment entity)
        {
            _db.Equipmentes.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Equipment> Get(int id)
        {
            return await _db.Equipmentes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Equipment>> Select()
        {
            return await _db.Equipmentes.ToListAsync();
        }

        public async Task<Equipment> Updated(int id, EquipmentModel model)
        {
            var events = await _db.Equipmentes.FirstOrDefaultAsync(x => x.Id == id);

            events.Id = id;
            events.Name = model.Name;
            events.ShortDesc = model.ShortDesc;
            events.LongDesc = model.LongDesc;
            events.Price = model.Price;
            events.Availability = model.Availability;
            events.DateReturn = model.DateReturn;
            events.CategoryEquips = model.CategoryEquips;

            if (model.Image != null)
            {
                byte[] imageDataA = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                {
                    imageDataA = binaryReader.ReadBytes((int)model.Image.Length);
                }
                // установка массива байтов
                events.Image = imageDataA;
            }

            _db.Equipmentes.Update(events);
            await _db.SaveChangesAsync();
            return events;
        }
    }
}
