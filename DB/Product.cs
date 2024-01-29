using System;
using System.Collections.Generic;

namespace Билет_20.DB;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductArticle { get; set; } = null!;

    public string ProductTitle { get; set; } = null!;

    public string ProductPoint { get; set; } = null!;

    public decimal ProductCost { get; set; }

    public int ProductMaxDiscount { get; set; }

    public int ProductManufactuerId { get; set; }

    public int ProductProviderId { get; set; }

    public int ProductCategoryId { get; set; }

    public int ProductCurrentDiscount { get; set; }

    public int ProductCount { get; set; }

    public string ProductDiscription { get; set; } = null!;

    public byte[]? ProductPhoto { get; set; }

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Manufactuer ProductManufactuer { get; set; } = null!;

    public virtual Provider ProductProvider { get; set; } = null!;
}
