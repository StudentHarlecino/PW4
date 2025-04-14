using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

public partial class ViewPartner
{
    public short? Id { get; set; }

    public string? TypeOfPartner { get; set; }

    public string? Name { get; set; }

    public string? LegalAddress { get; set; }

    public string? Inn { get; set; }

    public string? NameOfDirector { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public short? Rating { get; set; }

    public long? TotalPurchases { get; set; }
}
