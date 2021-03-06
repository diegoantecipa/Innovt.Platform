﻿// Company: INNOVT
// Project: Innovt.Domain
// Created By: Michel Borges
// Date: 2016/10/19

using System;
using Innovt.Domain.Core.Model;

namespace Innovt.Domain.Users
{
    public class BaseUser: Entity
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }
       
        public virtual string Password { get; set; }

        public virtual bool IsActive { get; set; }

        public DateTimeOffset? LastAccess { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }
}