using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

public partial class ViewProduct
{
    public short? Id { get; set; }

    public string? TypeOfProduct { get; set; }

    public string? Name { get; set; }

    public string? Article { get; set; }

    public decimal? MinimalPrice { get; set; }

    public long? TotalSales { get; set; }
}
