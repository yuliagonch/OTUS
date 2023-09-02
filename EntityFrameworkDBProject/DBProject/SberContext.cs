using System;
using System.Collections.Generic;
using DBProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBProject;

public partial class SberContext : DbContext
{
    public SberContext()
    {
    }

    public SberContext(DbContextOptions<SberContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DictClientType> DictClientTypes { get; set; }

    public virtual DbSet<DictCurrency> DictCurrencies { get; set; }

    public virtual DbSet<DictNationality> DictNationalities { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Sber;Username=postgres;Password=otus5");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("accounts_pkey");

            entity.ToTable("accounts", tb => tb.HasComment("Счета"));

            entity.Property(e => e.AccountId)
                .HasComment("Идентификатор счета")
                .HasColumnName("account_id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(60)
                .HasComment("Номер счета")
                .HasColumnName("account_number");
            entity.Property(e => e.ClientId)
                .HasComment("Идентификатор клиента")
                .HasColumnName("client_id");
            entity.Property(e => e.ClosingDate)
                .HasComment("Дата закрытия счета")
                .HasColumnName("closing_date");
            entity.Property(e => e.Currency)
                .HasComment("Валюта счета")
                .HasColumnName("currency");
            entity.Property(e => e.OpeningDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasComment("Дата открытия счета")
                .HasColumnName("opening_date");
            entity.Property(e => e.ProductId)
                .HasComment("Идентификатор продукта")
                .HasColumnName("product_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_client_id_fkey");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Currency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_currency_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_product_id_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("clients_pkey");

            entity.ToTable("clients", tb => tb.HasComment("Справочник типов валют"));

            entity.Property(e => e.ClientId)
                .HasComment("Идентификатор клиента")
                .HasColumnName("client_id");
            entity.Property(e => e.BirthDate)
                .HasComment("Дата рождения клиента")
                .HasColumnName("birth_date");
            entity.Property(e => e.ClientType)
                .HasComment("Тип клиента")
                .HasColumnName("client_type");
            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .HasComment("Имя клиента")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(120)
                .HasComment("Фамилия клиента")
                .HasColumnName("last_name");
            entity.Property(e => e.Nationality)
                .HasComment("Гражданство клиента")
                .HasColumnName("nationality");
            entity.Property(e => e.Surname)
                .HasMaxLength(120)
                .HasComment("Отчество клиента")
                .HasColumnName("surname");

            entity.HasOne(d => d.ClientTypeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clients_client_type_fkey");

            entity.HasOne(d => d.NationalityNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Nationality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clients_nationality_fkey");
        });

        modelBuilder.Entity<DictClientType>(entity =>
        {
            entity.HasKey(e => e.IdCode).HasName("dict_client_type_pkey");

            entity.ToTable("dict_client_type", tb => tb.HasComment("Справочник типов клиентов"));

            entity.Property(e => e.IdCode)
                .ValueGeneratedNever()
                .HasComment("Код значения справочника")
                .HasColumnName("id_code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(400)
                .HasComment("Комментарии")
                .HasColumnName("remarks");
            entity.Property(e => e.ValueFull)
                .HasMaxLength(120)
                .HasComment("Значение справочника полное")
                .HasColumnName("value_full");
            entity.Property(e => e.ValueShort)
                .HasMaxLength(60)
                .HasComment("Значение справочника сокращенное")
                .HasColumnName("value_short");
        });

        modelBuilder.Entity<DictCurrency>(entity =>
        {
            entity.HasKey(e => e.IdCode).HasName("dict_currency_pkey");

            entity.ToTable("dict_currency", tb => tb.HasComment("Справочник типов валют"));

            entity.Property(e => e.IdCode)
                .ValueGeneratedNever()
                .HasComment("Код значения справочника")
                .HasColumnName("id_code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(400)
                .HasComment("Комментарии")
                .HasColumnName("remarks");
            entity.Property(e => e.ValueFull)
                .HasMaxLength(120)
                .HasComment("Значение справочника полное")
                .HasColumnName("value_full");
            entity.Property(e => e.ValueShort)
                .HasMaxLength(60)
                .HasComment("Значение справочника сокращенное")
                .HasColumnName("value_short");
        });

        modelBuilder.Entity<DictNationality>(entity =>
        {
            entity.HasKey(e => e.IdCode).HasName("dict_nationality_pkey");

            entity.ToTable("dict_nationality", tb => tb.HasComment("Справочник типов гражданства"));

            entity.Property(e => e.IdCode)
                .ValueGeneratedNever()
                .HasComment("Код значения справочника")
                .HasColumnName("id_code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(400)
                .HasComment("Комментарии")
                .HasColumnName("remarks");
            entity.Property(e => e.ValueFull)
                .HasMaxLength(120)
                .HasComment("Значение справочника полное")
                .HasColumnName("value_full");
            entity.Property(e => e.ValueShort)
                .HasMaxLength(60)
                .HasComment("Значение справочника сокращенное")
                .HasColumnName("value_short");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products", tb => tb.HasComment("Продукты"));

            entity.Property(e => e.ProductId)
                .HasComment("Идентификатор продукта")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(120)
                .HasComment("Название продукта")
                .HasColumnName("product_name");
            entity.Property(e => e.Remarks)
                .HasMaxLength(400)
                .HasComment("Комментарии")
                .HasColumnName("remarks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
