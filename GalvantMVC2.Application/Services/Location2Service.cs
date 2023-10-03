using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Services
{
    public class Location2Service : ILocation2Service
    {
        private readonly IEquipmentRepository _equipmentRepo;

        public Location2Service(IEquipmentRepository equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }

        public List<Location2Vm> GetAllLocations2()
        {
            var locations = _equipmentRepo.GetAllLocations2();
            var locationsVmList = new List<Location2Vm>();
            
            foreach (var location in locations)
            {
                var location2Vm = new Location2Vm
                {
                    Location2Id = location.Location2Id,
                    Location2Name = location.Location2Name,
                };
                locationsVmList.Add(location2Vm);
            }
            return locationsVmList;
        }
    }
}

