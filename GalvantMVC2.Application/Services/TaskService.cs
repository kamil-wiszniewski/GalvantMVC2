using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using GalvantMVC2.Domain.Enums;
using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IEquipmentRepository _equipmentRepo;
        public TaskService(ITaskRepository taskRepo, IEquipmentRepository equipmentRepository)
        {
            _taskRepo = taskRepo;
            _equipmentRepo = equipmentRepository;
        }

        public int AddTask(AddTaskVm model)
        {
            var task = new Domain.Model.Task
            {                
                CreatedAt = DateTime.Now,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,                 
                Cost = model.Cost,
                Notes = model.Notes,
                StatusId = model.StatusId,
                EquipmentId = model.EquipmentId,
                TagId = model.TagId
            };
            _taskRepo.AddTask(task);

            return task.TaskId;
        }

        public List<TasksListVm> GetAllTasksForList()
        {
            var tasks = _taskRepo.GetAllTasks();    
                List<TasksListVm> result = new List<TasksListVm>();                

                foreach (var task in tasks)
                {
                    var tagName = _taskRepo.GetTagNameById(task.TagId);                    

                    var taskVm = new TasksListVm()
                    {
                        TaskId = task.TaskId,                        
                        TagName = tagName,
                        Description = task.Description,                        
                        DueDate = task.DueDate
                    };                   

                    result.Add(taskVm);
                }
                return result;            
        }        

        public List<Location2Vm> GetDataForSecondDropdown(string firstDropdownVal)
        {
            List<Equipment> equipment = _equipmentRepo.GetAllActiveEquipment()
                              .Where(e => e.Location1 == firstDropdownVal)
                              .ToList();

            List<int?> location2Ids = equipment.Select(e => e.Location2Id).Distinct().ToList();

            List<Location2Vm> data = _equipmentRepo.GetAllLocations2()
                               .Where(l => location2Ids.Contains(l.Location2Id))
                               .Select(l => new Location2Vm
                               {
                                   Location2Id = l.Location2Id,
                                   Location2Name = l.Location2Name
                               })
                               .ToList();

            return data;
        }

        public List<TypesVm> GetDataForThirdDropdown(string firstDropdownVal, int secondDropdownVal)
        {
            List<Equipment> equipment = _equipmentRepo.GetAllActiveEquipment()
                              .Where(e => e.Location1 == firstDropdownVal &&
                                          e.Location2Id == secondDropdownVal)
                              .ToList();

            List<int> typeIds = equipment.Select(e => e.TypeId).Distinct().ToList();

            List<TypesVm> data = _equipmentRepo.GetAllTypes()
                               .Where(l => typeIds.Contains(l.TypeId))
                               .Select(l => new TypesVm
                               {
                                   TypeId = l.TypeId,
                                   TypeName = l.TypeName,
                               })
                               .ToList();

            return data;
        }

        public List<EquipmentForCascadeSearchVm> GetDataForFourthDropdown(string firstDropdownVal, int secondDropdownVal, int thirdDropdownVal)
        {
            List<Equipment> equipment = _equipmentRepo.GetAllActiveEquipment()
                              .Where(e => e.Location1 == firstDropdownVal &&
                                          e.Location2Id == secondDropdownVal &&
                                          e.TypeId == thirdDropdownVal)
                              .ToList();

            List<EquipmentForCascadeSearchVm> data = new List<EquipmentForCascadeSearchVm>();

            foreach (var e in equipment)
            {
                EquipmentForCascadeSearchVm equ = new()
                {
                    EquipmentId = e.EquipmentId
                };

                switch (e.TypeId)
                {
                    case 1:
                        Forklift forklift = _equipmentRepo.GetForkliftByEquipmentId(e.EquipmentId);
                        equ.EquipmentCascade = "Nr inwentarzowy: " + forklift.InventoryNumber;
                        break;

                    case 2:
                        Gantry gantry = _equipmentRepo.GetGantryByEquipmentId(e.EquipmentId);
                        equ.EquipmentCascade = "Nr inwentarzowy: " + gantry.InventoryNumber;
                        break;

                    case 3:
                        Hoist hoist = _equipmentRepo.GetHoistByEquipmentId(e.EquipmentId);
                        equ.EquipmentCascade = "Nr inwentarzowy: " + hoist.InventoryNumber;
                        break;
                }
                data.Add(equ);
            }
            return data;
        }

        public List<TasksListVm> GetFilteredTasksForList(string tag)
        {
            var allTasks = _taskRepo.GetAllTasks();
            var filteredTasks = allTasks;
            List<TasksListVm> result = new List<TasksListVm>();

            if (tag == "wszystkie")
            {
                filteredTasks = allTasks;
            }
            else
            {
                if (_taskRepo.GetTagIdByTagName(tag) == 1)
                {
                    filteredTasks = allTasks.Where(t => t.TagId == 1);
                }
                if (_taskRepo.GetTagIdByTagName(tag) == 2)
                {
                    filteredTasks = allTasks.Where(t => t.TagId == 2);
                }
                if (_taskRepo.GetTagIdByTagName(tag) == 4)
                {
                    filteredTasks = allTasks.Where(t => t.TagId == 4);
                }
            }

            foreach (var task in filteredTasks)
            {
                var tagName = _taskRepo.GetTagNameById(task.TagId);

                var taskVm = new TasksListVm()
                {
                    TaskId = task.TaskId,                    
                    TagName = tagName,
                    Description = task.Description,                    
                    DueDate = task.DueDate
                };

                result.Add(taskVm);
            }
            return result;            
        }

        public List<StatusesVm> GetAllStatuses()
        {
            var statuses = _taskRepo.GetAllStatuses();
                var statusesVmList = new List<StatusesVm>();
                foreach (var status in statuses)
                {
                    var statusVm = new StatusesVm
                    {
                        StatusId = status.StatusId,
                        StatusName = status.StatusName
                    };
                statusesVmList.Add(statusVm);
                }
                return statusesVmList;            
        }       

        public List<TasksSearchResultVm> Search(string location1, int type, int location2, int status, int tag, string priority, int pageNumber, int pageSize)
        {
            var result = new List<TasksSearchResultVm>();
            Enum.TryParse<PriorityEnum>(priority, ignoreCase: true, out var priorityEnum);

            var query = _taskRepo.GetTasksIncludingEquipment()
                        .Where(t => (string.IsNullOrEmpty(location1) || t.Equipment.Location1 == location1) &&
                                    (type == 0 || t.Equipment.TypeId == type) &&
                                    (location2 == 0 || t.Equipment.Location2Id == location2) &&
                                    (status == 0 || t.StatusId == status) &&
                                    (tag == 0 || t.TagId == tag) &&
                                    (t.Priority == priorityEnum || priorityEnum == default))         
                        .OrderByDescending(t => t.CreatedAt)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            foreach (var task in query)
            {
                TasksSearchResultVm vm = new()
                {
                    TaskId = task.TaskId,
                    Type = _equipmentRepo.GetTypeNameById(task.Equipment.TypeId),
                    Location2 = _equipmentRepo.GetLocation2NameById(task.Equipment.Location2Id),
                    Tag = _taskRepo.GetTagNameById(task.TagId),
                    Status = _taskRepo.GetStatusNameById(task.StatusId),
                    DueDate = task.DueDate,
                    Title = task.Title
                };
                result.Add(vm);
            }
            return result;
        }
    }
}
