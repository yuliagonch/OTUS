using System;
using System.Collections.Generic;

namespace DBProject.Entities;

/// <summary>
/// Справочник типов клиентов
/// </summary>
public partial class DictClientType
{
    /// <summary>
    /// Код значения справочника
    /// </summary>
    public int IdCode { get; set; }

    /// <summary>
    /// Значение справочника сокращенное
    /// </summary>
    public string? ValueShort { get; set; }

    /// <summary>
    /// Значение справочника полное
    /// </summary>
    public string? ValueFull { get; set; }

    /// <summary>
    /// Комментарии
    /// </summary>
    public string? Remarks { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
