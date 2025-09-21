using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class Friendship
{
    public int IdUser1 { get; set; }

    public int IdUser2 { get; set; }

    public string? Status { get; set; }

    public virtual User IdUser1Navigation { get; set; } = null!;

    public virtual User IdUser2Navigation { get; set; } = null!;
}
