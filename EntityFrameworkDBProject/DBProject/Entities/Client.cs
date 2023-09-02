using System;
using System.Collections.Generic;

namespace DBProject.Entities;

/// <summary>
/// Справочник типов валют
/// </summary>
public partial class Client
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество клиента
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// Дата рождения клиента
    /// </summary>
    public DateOnly BirthDate { get; set; }

    /// <summary>
    /// Гражданство клиента
    /// </summary>
    public int Nationality { get; set; }

    /// <summary>
    /// Тип клиента
    /// </summary>
    public int ClientType { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual DictClientType ClientTypeNavigation { get; set; } = null!;

    public virtual DictNationality NationalityNavigation { get; set; } = null!;
}
