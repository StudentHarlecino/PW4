using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

/// <summary>
/// Каталог продукции компании
/// </summary>
public partial class Product
{
    public short Id { get; set; }

    public short IdTypeOfProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Article { get; set; } = null!;

    public decimal MinimalPrice { get; set; }

    public virtual TypesOfProduct IdTypeOfProductNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
