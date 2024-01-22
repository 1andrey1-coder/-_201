using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class User
{
    public static object Logged { get; internal set; }
    public int Userid { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserFather { get; set; } = null!;

    public string UserPosition { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public byte[]? UserPhoto { get; set; }
}
