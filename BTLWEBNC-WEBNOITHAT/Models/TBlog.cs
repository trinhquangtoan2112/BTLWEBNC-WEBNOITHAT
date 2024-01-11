using System;
using System.Collections.Generic;

namespace BTLWEBNC_WEBNOITHAT.Models;

public partial class TBlog
{
    public int Idblog { get; set; }

    public string? TacGia { get; set; }

    public DateTime? NgayDang { get; set; }

    public string? TieuDe { get; set; }

    public string? Scontent { get; set; }

    public string? Content { get; set; }

    public string? TenFileAnh { get; set; }

    public int? Idtag { get; set; }

    public virtual TBlogTag? IdtagNavigation { get; set; }
}
