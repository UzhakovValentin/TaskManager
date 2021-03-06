﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using TaskManager.Domain.Models.Abstracts;

namespace TaskManager.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IList<ToDoTask> Tasks { get; } = new List<ToDoTask>();
        public List<TaskFolder> TaskFolders { get; set; } = new List<TaskFolder>();
        public IList<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
