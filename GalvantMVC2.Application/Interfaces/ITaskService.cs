﻿using GalvantMVC2.Application.Services;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Interfaces
{
    public interface ITaskService
    {
        int AddTask(AddTaskVm model);

        List<TasksListVm> GetAllTasksForList();

        List<TasksListVm> GetFilteredTasksForList(string tag);

        List<Location2Vm> GetDataForSecondDropdown(string firstDropdownVal);

        List<TypesVm> GetDataForThirdDropdown(string firstDropdownVal, int secondDropdownVal);

        List<EquipmentForCascadeSearchVm> GetDataForFourthDropdown(string firstDropdownVal, int secondDropdownVal, int thirdDropdownVal);

        List<StatusesVm> GetAllStatuses();

        List<TasksSearchResultVm> Search(string location1, int type, int location2, int status, int tag, string priority, int pageNumber, int pageSize);
    }
}
