﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NeoForum.Models;
using NeoForum.Models.Enums;

namespace NeoForum.Areas.Identity.Data;

// Добавление данных профиля для пользователей приложения
public class NeoForumUser : IdentityUser
{
    public NeoForumUser()
    {
        Messages = new HashSet<Message>();
    }

    public virtual ICollection<Message> Messages { get; set; }

    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string? FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? LastName { get; set; } 

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? Image { get; set; }

    public Country Country { get; set; }

    [PersonalData]
    public int Age { get; set; }
}

