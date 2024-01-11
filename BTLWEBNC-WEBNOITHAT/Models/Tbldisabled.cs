using System;
using System.Collections.Generic;

namespace BTLWEBNC_WEBNOITHAT.Models;

public partial class Tbldisabled
{
    public string FkT2 { get; set; } = null!;

    public bool? Disabled { get; set; }

    public DateTime? Longtime { get; set; }

    public virtual TDanhMucSp FkT2Navigation { get; set; } = null!;
}
