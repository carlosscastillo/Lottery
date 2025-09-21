using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class SocialMedium
{
    public int IdSocialMedia { get; set; }

    public int IdUser { get; set; }

    public string? FacebookUser { get; set; }

    public string? InstagramUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
