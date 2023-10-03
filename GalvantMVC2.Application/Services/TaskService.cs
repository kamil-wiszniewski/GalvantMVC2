using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
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
        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
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
