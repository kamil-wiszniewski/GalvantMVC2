using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Interfaces
{
    public interface ITaskRepository
    {
        int AddTask(Model.Task task);

        IQueryable<Tag> GetAllTags();

        IQueryable<Model.Task> GetAllTasks();

        IQueryable<Status> GetAllStatuses();

        string GetTagNameById(int? tagId);

        int GetTagIdByTagName(string tagName);

        string GetStatusNameById(int? statusId);

        IQueryable<Model.Task> GetTasksIncludingEquipment();        
    }
}
