using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Tasks;
using GalvantMVC2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITaskRepository _taskRepository;

        public TagService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TagsVm> GetAllTags()
        {
            var tags = _taskRepository.GetAllTags();
            var tagsVmList = new List<TagsVm>();
            foreach (var tag in tags)
            {
                var tagsVm = new TagsVm
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                };
                tagsVmList.Add(tagsVm);
            }
            return tagsVmList;
        }
    }
}

