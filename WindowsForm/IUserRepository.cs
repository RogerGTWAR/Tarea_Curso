﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm
{
    public interface IUserRepository
    {
        Task<string> AuthenticateUserAsync(string username, string password);
    }
}
