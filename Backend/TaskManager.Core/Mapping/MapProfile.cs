﻿using AutoMapper;
using System;
using TaskManager.Domain.Models;
using TaskManager.Shared.Infos;
using TaskManager.Shared.Infos.SubTasks;
using TaskManager.Shared.Infos.TaskFolders;
using TaskManager.Shared.Infos.ToDoTasks;
using TaskManager.Shared.ShortViewModels;
using TaskManager.Shared.ViewModels;

namespace TaskManager.Core.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region ToDoTask mappings
            CreateMap<CreateTodoTaskInfo, ToDoTask>();
            CreateMap<ToDoTask, ToDoTaskView>()
                .ForMember(t => t.CreationDate, p => p.MapFrom(r => r.CreationDate.ToString("f")))
                .ForMember(t => t.ModificationDate, p => p.MapFrom(r =>
                    r.ModificationDate.HasValue ? r.ModificationDate.Value.ToString("f") : null))
                .ForMember(t => t.EndDate, p => p.MapFrom(r =>
                    r.EndDate.HasValue ? r.EndDate.Value.ToString("f") : null));

            CreateMap<UpdateToDoTaskInfo, ToDoTask>()
                .BeforeMap((s, c) =>
                {
                    if (s.DeleteEndDate)
                    {
                        c.EndDate = null;
                    }
                    else
                    {
                        s.EndDate ??= c.EndDate.ToString();
                    }
                })
                .AfterMap((s, c) => c.ModificationDate = DateTime.Now)
                .ForMember(t => t.Id, o => o.Ignore())
                .ForAllMembers(o => o.Condition((src, dest, member) => member is not null));

            CreateMap<ToDoTask, ToDoTaskShortView>();
            #endregion

            #region TaskFolder mappings
            CreateMap<CreateTaskFolderInfo, TaskFolder>();
            CreateMap<TaskFolder, TaskFolderView>();
            #endregion

            #region SubTask mappings
            CreateMap<SubTaskCreateInfo, SubTask>();
            CreateMap<UpdateSubTaskInfo, SubTask>();
            #endregion

            #region User mappings
            CreateMap<UserRegistrationInfo, User>()
                .ForMember(u => u.UserName, o => o.MapFrom(i => i.Email));

            #endregion
        }
    }
}
