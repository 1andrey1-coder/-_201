using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryTitle { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
