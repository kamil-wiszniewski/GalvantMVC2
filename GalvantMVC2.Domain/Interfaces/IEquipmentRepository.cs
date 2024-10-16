using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = GalvantMVC2.Domain.Model.File;

namespace GalvantMVC2.Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        int AddEquipment(Equipment equipment);

        int AddFile(File file);

        int AddForklift(Forklift forklift);

        int AddGantry(Gantry gantry);

        int AddHoist(Hoist hoist);

        int AddCrane(Crane crane);

        int AddTank(Tank tank);

        IQueryable<Model.Type> GetAllTypes();        

        IQueryable<Location2> GetAllLocations2();

        IQueryable<Equipment> GetAllActiveEquipment();        

        string GetTypeNameById(int typeId);

        string GetLocation2NameById(int? locationId);

        Forklift GetForkliftByEquipmentId(int equipmentId);

        Gantry GetGantryByEquipmentId(int equipmentId);

        Hoist GetHoistByEquipmentId(int equipmentId);

        Crane GetCraneByEquipmentId(int equipmentId);

        Tank GetTankByEquipmentId(int equipmentId);

        Equipment GetEquipmentById(int equipmentId);

        IQueryable<Category> GetAllCategories();

        IQueryable<File> GetAllFiles();

        File GetFileByFileId(int fileId);

        void DeleteFile(int fileId);
    }
}
