using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;
        public TaskRepository(Context context)
        {
            _context = context;
        }

        public int AddTask(Domain.Model.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.TaskId;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }

        public IQueryable<Domain.Model.Task> GetAllTasks()
        {
            var tasks = _context.Tasks;
            return tasks;
        }

        public IQueryable<Status> GetAllStatuses()
        {
            var statuses = _context.Statuses;
            return statuses;
        }

        public int GetTagIdByTagName(string tagName)
        {
            var tagId = _context.Tags.FirstOrDefault(t => t.TagName == tagName);
            return tagId.TagId;
        }

        public string GetTagNameById(int? tagId)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.TagId == tagId);
            return tag.TagName;
        }

        public string GetStatusNameById(int? statusId)
        {
            var status = _context.Statuses.FirstOrDefault(t => t.StatusId == statusId);
            return status.StatusName;
        }

        public IQueryable<Domain.Model.Task> GetTasksIncludingEquipment()
        {
            return _context.Tasks.Include(t => t.Equipment);
        }
    }
}
