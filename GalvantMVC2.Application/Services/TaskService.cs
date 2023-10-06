using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using Microsoft.EntityFrameworkCore;
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
                CreationDate = DateTime.Now,
                TagId = model.TagId,
                Description = model.Description,
                Equipment = model.Equipment,
                DueDate = model.DueDate
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
                        CreationDate = task.CreationDate,
                        TagName = tagName,
                        Description = task.Description,
                        Equipment = task.Equipment,
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
                    CreationDate = task.CreationDate,
                    TagName = tagName,
                    Description = task.Description,
                    Equipment = task.Equipment,
                    DueDate = task.DueDate
                };

                result.Add(taskVm);
            }
            return result;            
        }
    }
}
