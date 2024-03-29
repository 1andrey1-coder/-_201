﻿using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string? ProviderTitle { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
