﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Shared.ShortViewModels
{
    public class ToDoTaskShortView
    {
        public string Title { get; set; }
        public string EndDate { get; set; }
        public string TaskPriority { get; set; }
        public string TaskStatus { get; set; }
    }
}
