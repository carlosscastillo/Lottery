using System;
using System.Collections.Generic;

namespace Lottery.Core.Models;

public partial class Game
{
    public int IdGame { get; set; }

    public string IdWinner { get; set; } = null!;
}
