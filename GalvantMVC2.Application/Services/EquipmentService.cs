using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepo;        

        public EquipmentService(IEquipmentRepository equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;            
        }

        public int AddEquipment(AddEquipmentVm model, AdditionalFieldsVm additionalFieldsModell)
        {
            var equipment = new Equipment
            {
                Location1 = model.Location1,
                Location2Id = model.Location2Id,
                Location3 = model.Location3,
                TypeId = model.TypeId,
                Notes = model.Notes,
            };
            _equipmentRepo.AddEquipment(equipment);

            if (model.TypeId == 1)
            {
                var forklift = new Forklift
                {
                    EquipmentId = equipment.EquipmentId,
                    Type = additionalFieldsModell.Type,
                    Producer = additionalFieldsModell.Producer,
                    ProductionYear = additionalFieldsModell.ProductionYear,
                    FactoryNumber = additionalFieldsModell.FactoryNumber,
                    UDTNumber = additionalFieldsModell.UDTNumber,
                    InventoryNumber = additionalFieldsModell.InventoryNumber,
                    LiftingCapacity = additionalFieldsModell.LiftingCapacity,
                    RaisingHeight = additionalFieldsModell.RaisingHeight,
                    FuelType = additionalFieldsModell.FuelType,
                    Weight = additionalFieldsModell.Weight,
                    UDTExpiryDate = additionalFieldsModell.UDTExpiryDate,
                    ElectricalExpiryDate = additionalFieldsModell.ElectricalExpiryDate,
                    ResursDate = additionalFieldsModell.ResursDate
                };
                _equipmentRepo.AddForklift(forklift);
            }

            if (model.TypeId == 2)
            {
                var gantry = new Gantry
                {
                    EquipmentId = equipment.EquipmentId,
                    Type = additionalFieldsModell.Type,
                    Producer = additionalFieldsModell.Producer,
                    ProductionYear = additionalFieldsModell.ProductionYear,
                    FactoryNumber = additionalFieldsModell.FactoryNumber,
                    UDTNumber = additionalFieldsModell.UDTNumber,
                    InventoryNumber = additionalFieldsModell.InventoryNumber,
                    LiftingCapacity = additionalFieldsModell.LiftingCapacity,
                    Range = additionalFieldsModell.Range,
                    RaisingHeight = additionalFieldsModell.RaisingHeight,
                    WorkloadGroup = additionalFieldsModell.WorkloadGroup,
                    Weight = additionalFieldsModell.Weight,
                    UDTExpiryDate = additionalFieldsModell.UDTExpiryDate,
                    ElectricalExpiryDate = additionalFieldsModell.ElectricalExpiryDate,
                    ResursDate = additionalFieldsModell.ResursDate
                };
                _equipmentRepo.AddGantry(gantry);
            }

            if (model.TypeId == 3)
            {
                var hoist = new Hoist
                {
                    EquipmentId = equipment.EquipmentId,
                    Type = additionalFieldsModell.Type,
                    Producer = additionalFieldsModell.Producer,
                    ProductionYear = additionalFieldsModell.ProductionYear,
                    FactoryNumber = additionalFieldsModell.FactoryNumber,
                    UDTNumber = additionalFieldsModell.UDTNumber,
                    InventoryNumber = additionalFieldsModell.InventoryNumber,
                    LiftingCapacity = additionalFieldsModell.LiftingCapacity,                    
                    RaisingHeight = additionalFieldsModell.RaisingHeight,
                    WorkloadGroup = additionalFieldsModell.WorkloadGroup,
                    Weight = additionalFieldsModell.Weight,
                    UDTExpiryDate = additionalFieldsModell.UDTExpiryDate,
                    ElectricalExpiryDate = additionalFieldsModell.ElectricalExpiryDate,
                    ResursDate = additionalFieldsModell.ResursDate
                };
                _equipmentRepo.AddHoist(hoist);
            }

            return equipment.EquipmentId;
        }        

        public List<EquipmentListVm> GetAllEquipmentForList(string? selectedLocation1, int? selectedType, int? selectedLocation2)
        {
            var equipment = _equipmentRepo.GetAllActiveEquipment();
            var filteredEquipment = equipment;
            List<EquipmentListVm> result = new List<EquipmentListVm>();

            if (!string.IsNullOrEmpty(selectedLocation1))
            {
                filteredEquipment = filteredEquipment.Where(d => d.Location1 == selectedLocation1);
            }

            if (selectedType.HasValue)
            {
                filteredEquipment = filteredEquipment.Where(d => d.TypeId == selectedType);
            }

            if (selectedLocation2.HasValue)
            {
                filteredEquipment = filteredEquipment.Where(d => d.Location2Id == selectedLocation2);
            }

            foreach (var item in filteredEquipment)
            {
                var typeName = _equipmentRepo.GetTypeNameById(item.TypeId);
                var location2Name = _equipmentRepo.GetLocation2NameById(item.Location2Id);

                var equipVm = new EquipmentListVm()
                {
                    EquipmentId = item.EquipmentId,
                    Type = typeName,
                    Location1 = item.Location1,
                    Location2 = location2Name,
                    Location3 = item.Location3,
                };

                if (item.TypeId == 1)
                {
                    var forklift = _equipmentRepo.GetForkliftByEquipmentId(item.EquipmentId);
                    equipVm.InventoryNumber = forklift.InventoryNumber;
                }

                if (item.TypeId == 2)
                {
                    var gantry = _equipmentRepo.GetGantryByEquipmentId(item.EquipmentId);
                    equipVm.InventoryNumber = gantry.InventoryNumber;
                }

                if (item.TypeId == 3)
                {
                    var hoist = _equipmentRepo.GetHoistByEquipmentId(item.EquipmentId);
                    equipVm.InventoryNumber = hoist.InventoryNumber;
                }

                result.Add(equipVm);
            }            
            return result;
        }

        public string GetProperAdditionalFieldsPartialViewName(int typeId)
        {
            if (typeId == 1)
                return "_ForkliftAdditionalFields";
            if (typeId == 2)
                return "_GantryAdditionalFields";
            if (typeId == 3)
                return "_HoistAdditionalFields";

            return null;
        }        

        public AddEquipmentVm GetEquipmentSharedFieldsForEdit(int id)
        {
            var equipment = _equipmentRepo.GetEquipmentById(id);                        

            var addEquipmentVm = new AddEquipmentVm
            {
                EquipmentId = equipment.EquipmentId,
                Location1 = equipment.Location1,
                Location2Id = equipment.Location2Id,
                Location3 = equipment.Location3,
                TypeId = equipment.TypeId,
                Notes = equipment.Notes
            };            

            return addEquipmentVm;
        }

        public AdditionalFieldsVm GetEquipmenmtAdditionalFieldsForEdit(int id)
        {
            var equipment = _equipmentRepo.GetEquipmentById(id);

            if (equipment.TypeId == 1)
            {
                var forklift = _equipmentRepo.GetForkliftByEquipmentId(id);
                var additionalFieldsVm = new AdditionalFieldsVm()
                {                    
                    Type = forklift.Type,
                    Producer = forklift.Producer,
                    ProductionYear = forklift.ProductionYear,
                    FactoryNumber = forklift.FactoryNumber,
                    UDTNumber = forklift.UDTNumber,
                    InventoryNumber = forklift.InventoryNumber,
                    LiftingCapacity = forklift.LiftingCapacity,
                    RaisingHeight = forklift.RaisingHeight,
                    FuelType = forklift.FuelType,
                    Weight = forklift.Weight,
                    UDTExpiryDate = forklift.UDTExpiryDate,
                    ElectricalExpiryDate = forklift.ElectricalExpiryDate,
                    ResursDate = forklift.ResursDate
                };
                return additionalFieldsVm;
            }
            else
            {
                throw new NotSupportedException("Typ wyposażenia nie jest obsługiwany.");
            }
        }
    }
}
