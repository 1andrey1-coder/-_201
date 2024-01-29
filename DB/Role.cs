using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleTitle { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
