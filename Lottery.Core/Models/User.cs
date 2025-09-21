using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdAvatar { get; set; }

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string PaternalLastName { get; set; } = null!;

    public string? MaternalLastName { get; set; }

    public int? Score { get; set; }

    public virtual Avatar IdAvatarNavigation { get; set; } = null!;

    public virtual ICollection<SocialMedium> SocialMedia { get; set; } = new List<SocialMedium>();
}
