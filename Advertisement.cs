using System;
using System.Collections.Generic;

namespace OtusHomework4;

public partial class Advertisement
{
    public int AdId { get; set; }

    public int? UserId { get; set; }

    public int? SubcategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Subcategory? Subcategory { get; set; }

    public virtual User? User { get; set; }
}
