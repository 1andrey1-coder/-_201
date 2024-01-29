using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class User
{
    public int Userid { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserFather { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int UserRoleId { get; set; }

    public virtual Role UserRole { get; set; } = null!;
}
