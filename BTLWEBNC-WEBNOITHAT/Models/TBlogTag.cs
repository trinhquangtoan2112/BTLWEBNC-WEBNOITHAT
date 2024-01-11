using System;
using System.Collections.Generic;

namespace BTLWEBNC_WEBNOITHAT.Models;

public partial class TBlogTag
{
    public int Idtag { get; set; }

    public string? Tag { get; set; }

    public virtual ICollection<TBlog> TBlogs { get; set; } = new List<TBlog>();
}
