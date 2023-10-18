using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly Context _context;
        public EquipmentRepository(Context context)
        {
            _context = context;
        }

        public int AddEquipment(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return equipment.EquipmentId;
        }

        public int AddForklift(Forklift forklift)
        {
            _context.Forklifts.Add(forklift);
            _context.SaveChanges();
            return forklift.ForkliftId;
        }

        public int AddGantry(Gantry gantry)
        {
            _context.Gantries.Add(gantry);
            _context.SaveChanges();
            return gantry.GantryId;
        }

        public int AddHoist(Hoist hoist)
        {
            _context.Hoists.Add(hoist);
            _context.SaveChanges();
            return hoist.HoistId;
        }

        public IQueryable<Location2> GetAllLocations2()
        {
            var locations = _context.Location2s;
            return locations;
        }

        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }        

        public IQueryable<Equipment> GetAllActiveEquipment()
        {
            var equipment = _context.Equipment;
            return equipment;
        }

        /*public IQueryable<Forklift> GetAllActiveForklifts()
        {
            var forklifts = _context.Forklifts;
            return forklifts;   
        }*/

        public string GetTypeNameById(int typeId)
        {
            var type = _context.Types.FirstOrDefault(t => t.TypeId == typeId);
            return type.TypeName;
        }

        public string GetLocation2NameById(int? location2Id)
        {
            var location2 = _context.Location2s.FirstOrDefault(l => l.Location2Id == location2Id);
            return location2.Location2Name;
        }

        public Forklift GetForkliftByEquipmentId(int equipmentId)
        {
            var forklift = _context.Forklifts.FirstOrDefault(n => n.EquipmentId == equipmentId);
            return forklift;
        }

        public Gantry GetGantryByEquipmentId(int equipmentId)
        {
            var gantry = _context.Gantries.FirstOrDefault(n => n.EquipmentId == equipmentId);
            return gantry;
        }

        public Hoist GetHoistByEquipmentId(int equipmentId)
        {
            var hoist = _context.Hoists.FirstOrDefault(n => n.EquipmentId == equipmentId);
            return hoist;
        }

        public Equipment GetEquipmentById(int equipmentId)
        {
            var equipment = _context.Equipment.FirstOrDefault(i => i.EquipmentId == equipmentId);
            return equipment;
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }


    }
}
