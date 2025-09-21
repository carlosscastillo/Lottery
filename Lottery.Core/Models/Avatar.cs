using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class Avatar
{
    public int IdAvatar { get; set; }

    public string? Path { get; set; }

    public string? AvatarName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
