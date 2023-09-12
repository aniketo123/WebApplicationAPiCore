using System;
using System.Collections.Generic;

namespace WebApplicationAPiCore.DataDB;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPhoneNumber { get; set; }

    public string? UserEmail { get; set; }
}
