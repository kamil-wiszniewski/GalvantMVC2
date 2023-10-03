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
    public class TypeService : ITypeService
    {
        private readonly IEquipmentRepository _equipmentRepo;       

        public TypeService(IEquipmentRepository equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;            
        }

        public List<TypesVm> GetAllTypes()
        {
            var types = _equipmentRepo.GetAllTypes();
            var typesVmList = new List<TypesVm>();
            foreach (var type in types)
            {
                var typesVm = new TypesVm
                {
                    TypeId = type.TypeId,
                    TypeName = type.TypeName
                };
                typesVmList.Add(typesVm);
            }
            return typesVmList;
        }
    }
}
