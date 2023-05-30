using BlackRose.Data;
using BlackRose.Interfaces;
using BlackRose.Models;
using BlackRose.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuGet.ContentModel;
using System.Xml.Linq;

namespace BlackRose.Repositories
{
    public class EventAifsoftRepository : IEventRepository
    {
        public readonly ApplicationDbContext _db;
        public EventAifsoftRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(EventAirsoftModel model)
        {
            EventAirsoft eventAi = new EventAirsoft
            {
                Name = model.Name,
                ShortDesc = model.ShortDesc,
                LongDesc = model.LongDesc,
                Venuet = model.Venuet,
                PriceEvent = model.PriceEvent,
                IsFavorite = model.IsFavorite,
                NumberOfParticipants = model.NumberOfParticipants,
                DateStart = model.DateStart,
                DateFinish = model.DateFinish,
                Passed = model.Passed,
                Category = model.Category,
            };
            if (model.PhotoFile != null)
            {
                byte[] imageDataA = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(model.PhotoFile.OpenReadStream()))
                {
                    imageDataA = binaryReader.ReadBytes((int)model.PhotoFile.Length);
                }
                // установка массива байтов
                eventAi.PhotoFile = imageDataA;
            }
            await _db.EventAirsofts.AddAsync(eventAi);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(EventAirsoft entity)
        {
            _db.EventAirsofts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<EventAirsoft> Get(int id)
        {
            return await _db.EventAirsofts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EventAirsoft>> GetFavEv()
        {
            return await _db.EventAirsofts.Where(c=>c.IsFavorite).ToListAsync();
        }

        public async Task<List<EventAirsoft>> Select()
        {
            return await _db.EventAirsofts.ToListAsync();
        }

        public async Task<EventAirsoft> Updated(int id, EventAirsoftModel model)
        {
            var events = await _db.EventAirsofts.FirstOrDefaultAsync(x => x.Id == id);

            events.Id = id;
            events.Name = model.Name;
            events.ShortDesc = model.ShortDesc;
            events.LongDesc = model.LongDesc;
            events.Venuet = model.Venuet;
            events.PriceEvent = model.PriceEvent;
            events.IsFavorite = model.IsFavorite;
            events.NumberOfParticipants = model.NumberOfParticipants;
            events.DateStart = model.DateStart;
            events.DateFinish = model.DateFinish;
            events.Passed = model.Passed;
            events.Category = model.Category;
            if (model.PhotoFile != null)
            {
                byte[] imageDataA = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(model.PhotoFile.OpenReadStream()))
                {
                    imageDataA = binaryReader.ReadBytes((int)model.PhotoFile.Length);
                }
                // установка массива байтов
                events.PhotoFile = imageDataA;
            }

            _db.EventAirsofts.Update(events);
            await _db.SaveChangesAsync();
            return events;
        }
    }
}
