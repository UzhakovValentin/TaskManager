﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Shared;
using TaskManager.Shared.Infos;
using TaskManager.Shared.ViewModels;

namespace TaskManager.Core.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Guid> Register(UserRegistrationInfo info);
        Task<UserAuthorizeView> Authorize(UserAuthorizeInfo info);
    }
}
