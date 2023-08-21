using System;
using System.Collections.Generic;

namespace OtusHomework4;

public partial class Subcategory
{
    public int SubcategoryId { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();

    public virtual Category? Category { get; set; }
}
