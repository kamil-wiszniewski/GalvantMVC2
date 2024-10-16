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

            switch (model.TypeId)
            {
                case 1:
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

                    break;

                case 2:
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

                    break;

                case 3:
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

                    break;

                case 4:
                    var crane = new Crane
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
                    _equipmentRepo.AddCrane(crane);

                    break;

                case 5:
                    var tank = new Tank
                    {
                        EquipmentId = equipment.EquipmentId,
                        Type = additionalFieldsModell.Type,
                        Producer = additionalFieldsModell.Producer,
                        ProductionYear = additionalFieldsModell.ProductionYear,
                        FactoryNumber = additionalFieldsModell.FactoryNumber,
                        UDTNumber = additionalFieldsModell.UDTNumber,
                        InventoryNumber = additionalFieldsModell.InventoryNumber,
                        Capacity = additionalFieldsModell.Capacity,
                        PermissiblePressure = additionalFieldsModell.PermissiblePressure,
                        UDTExpiryDate = additionalFieldsModell.UDTExpiryDate,
                        ElectricalExpiryDate = additionalFieldsModell.ElectricalExpiryDate,
                        ResursDate = additionalFieldsModell.ResursDate
                    };
                    _equipmentRepo.AddTank(tank);

                    break;
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

                switch (item.TypeId)
                {
                    case 1:
                        var forklift = _equipmentRepo.GetForkliftByEquipmentId(item.EquipmentId);
                        equipVm.InventoryNumber = forklift.InventoryNumber;

                    break;

                    case 2:
                        var gantry = _equipmentRepo.GetGantryByEquipmentId(item.EquipmentId);
                        equipVm.InventoryNumber = gantry.InventoryNumber;

                    break;

                    case 3:
                        var hoist = _equipmentRepo.GetHoistByEquipmentId(item.EquipmentId);
                        equipVm.InventoryNumber = hoist.InventoryNumber;

                    break;

                    case 4:
                        var crane = _equipmentRepo.GetCraneByEquipmentId(item.EquipmentId);
                        equipVm.InventoryNumber = crane.InventoryNumber;

                    break;

                    case 5:
                        var tank = _equipmentRepo.GetTankByEquipmentId(item.EquipmentId);
                        equipVm.InventoryNumber = tank.InventoryNumber;

                    break;
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
            if (typeId == 4)
                return "_CraneAdditionalFields";
            if (typeId == 5)
                return "_TankAdditionalFields";

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

            switch (equipment.TypeId)
            {
                case 1:
                    var forklift = _equipmentRepo.GetForkliftByEquipmentId(id);
                    var forkliftAdditionalFieldsVm = new AdditionalFieldsVm()
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
                    return forkliftAdditionalFieldsVm;

                case 2:
                    var gantry = _equipmentRepo.GetGantryByEquipmentId(id);
                    var gantryAdditionalFieldsVm = new AdditionalFieldsVm()
                    {
                        Type = gantry.Type,
                        Producer = gantry.Producer,
                        ProductionYear = gantry.ProductionYear,
                        FactoryNumber = gantry.FactoryNumber,
                        UDTNumber = gantry.UDTNumber,
                        InventoryNumber = gantry.InventoryNumber,
                        LiftingCapacity = gantry.LiftingCapacity,
                        Range = gantry.Range,
                        RaisingHeight = gantry.RaisingHeight,
                        WorkloadGroup = gantry.WorkloadGroup,
                        Weight = gantry.Weight,
                        UDTExpiryDate = gantry.UDTExpiryDate,
                        ElectricalExpiryDate = gantry.ElectricalExpiryDate,
                        ResursDate = gantry.ResursDate
                    };
                    return gantryAdditionalFieldsVm;

                default:                    
                    throw new InvalidOperationException("Nieznany typ urządzenia");
            }
        }

        public EquipmentDetailsSharedVm GetEquipmentSharedFieldsForDetails(int equipmentId)
        {
            var equipment = _equipmentRepo.GetEquipmentById(equipmentId);

            var equipmentDetailsVm = new EquipmentDetailsSharedVm
            {
                EquipmentId = equipment.EquipmentId,
                Location1 = equipment.Location1,
                Location2Name = _equipmentRepo.GetLocation2NameById(equipmentId),
                Location3 = equipment.Location3,
                TypeId= equipment.TypeId,
                TypeName = _equipmentRepo.GetTypeNameById(equipment.TypeId),
                Notes = equipment.Notes
            };
            return equipmentDetailsVm;
        }        
    }
}
