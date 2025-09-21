using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class Banned
{
    public int IdBanned { get; set; }

    public int IdUser { get; set; }

    public string BanType { get; set; } = null!;

    public string Reason { get; set; } = null!;

    public DateTime BannedAt { get; set; }

    public DateTime? UnbannedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
