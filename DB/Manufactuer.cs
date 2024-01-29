using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class Manufactuer
{
    public int ManufactuerId { get; set; }

    public string? ManufactuerTitle { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
