using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

/// <summary>
/// Информация о партнерах компании
/// </summary>
public partial class Partner
{
    public short Id { get; set; }

    public short IdTypeOfPartner { get; set; }

    public string Name { get; set; } = null!;

    public string LegalAddress { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string NameOfDirector { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public short? Rating { get; set; }

    public virtual TypesOfPartner IdTypeOfPartnerNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
